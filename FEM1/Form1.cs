using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace FEM1
{
    public partial class Form1 : Form
    {
        //フィールド
        int gap = 600;
        public int xvol = 0, yvol = 0, segvol = 0, selectvol = 0;
        int area_x0, area_y0, area_x1, area_y1;
        int grabp = -1, grabp0=-1;
        bool act_flg = false, cond_flg=false, areaselect_flg=false, grab_flg=false;
        double kval, weight, gx, gy, damp;
        Bitmap bmp;
        //

        public struct Fact  //要素点定義
        {
            public double Mass, Xn, Yn, Xpos, Ypos, Xfrc, Yfrc, Xv, Yv;
            public int atrb;
            //public Fact(int m,int x, int y) { Mass = m; Xpos = x; Ypos = y; Xfrc = 0; Yfrc = 0; }
        }
        //Fact[,] fact = new Fact[20, 20];    //fact構造体フィールド作成
        Fact[] point = new Fact[1];
        
        public struct Seg   //セグメント定義
        {
            public double inilth;
            public int xn1, yn1;
            public int xn2, yn2;
            public int p1, p2;
        }
        Seg[] seg = new Seg[400];   //セグメント構造体フィールド作成

        public List<int> selectpoint = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_cond_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < yvol; y++)      //パラメータ初期化
            {
                for (int x = 0; x < xvol; x++)
                {
                    int i = y * xvol + x;
                    point[i].Xfrc = 0; point[i].Xv = 0;
                    point[i].Yfrc = 0; point[i].Yv = 0;
                    point[i].Xpos = x * gap;
                    point[i].Ypos = y * gap;
                    //point[i].atrb = 0;
                }
            }
            setcond("cond_start");
        }

        private void btn_simstart_Click(object sender, EventArgs e)
        {
            if (act_flg == false)
            {
                setcond("simstart");
            }
            else
            {
                setcond("simpause");
            }
        }

        public void segmake()
        {
            int segcnt = 0;
            for (int y = 0; y < yvol; y++)
            {
                for (int x = 0; x < xvol - 1; x++)
                {
                    int i = y * xvol + x;
                    if (point[i].Mass > 0)
                    {
                        int nx = x + 1;
                        while (nx < xvol)
                        {
                            i = y * xvol + x;
                            nx = x + 1;

                            int n = y * xvol + nx;
                            if (n < (xvol * yvol))
                            {
                                if (point[n].Mass > 0)   //横セグメント
                                {
                                    seg[segcnt].p1 = i;
                                    seg[segcnt].p2 = n;
                                    double xl = point[n].Xpos - point[i].Xpos;  //初期長設定
                                    double yl = point[n].Ypos - point[i].Ypos;
                                    seg[segcnt].inilth = Math.Sqrt(xl * xl + yl * yl);
                                    segcnt++;

                                    if (y < yvol-1 &&　x < xvol-1)
                                    {
                                        int nd = (y + 1) * xvol + nx;
                                        if (nd < (xvol * yvol))
                                        {
                                            if (point[nd].Mass > 0)   //斜めセグメント
                                            {
                                                seg[segcnt].p1 = i;
                                                seg[segcnt].p2 = nd;
                                                xl = point[nd].Xpos - point[i].Xpos;  //初期長設定
                                                yl = point[nd].Ypos - point[i].Ypos;
                                                seg[segcnt].inilth = Math.Sqrt(xl * xl + yl * yl);
                                                segcnt++;
                                            }
                                        }
                                    }
                                    x = nx;
                                }
                            }
                            nx++;
                        }
                    }
                }
            }

            for (int x = 0; x < xvol; x++)
            {
                for (int y = 0; y < yvol - 1; y++)
                {
                    int i = y * xvol + x;
                    if (point[i].Mass > 0)
                    {
                        int ny = y + 1;
                        while (ny <= yvol)
                        {
                            i = y * xvol + x;
                            ny = y + 1;
                            int nn = ny * xvol + x;
                            if (nn < xvol*yvol)
                            {
                                if (point[nn].Mass > 0)   //縦セグメント
                                {
                                    seg[segcnt].p1 = i;
                                    seg[segcnt].p2 = nn;
                                    double xl = point[nn].Xpos - point[i].Xpos;  //初期長設定
                                    double yl = point[nn].Ypos - point[i].Ypos;
                                    seg[segcnt].inilth = Math.Sqrt(xl * xl + yl * yl);
                                    segcnt++;
                                    y = ny;
                                }
                            }
                            ny++;
                        }
                    }
                }
            }
            segvol = segcnt;
        }

        public void factdraw()      //要素群描画
        {
            Graphics gra = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black, 1);
            SolidBrush sbrsbk = new SolidBrush(Color.FromArgb(255, 220, 220, 220));
            gra.FillRectangle(sbrsbk, 0,0,pb1.Width-1,pb1.Height-1);
            gra.DrawRectangle(pen, 0, 0, pb1.Width - 1, pb1.Height - 1);
            sbrsbk.Dispose();
            pen.Dispose();
            Color col;

            for (int i = 0; i < xvol * yvol; i++)
            {
                if (point[i].Mass != 0)
                {
                    switch (point[i].atrb)
                    {
                        case 1:
                            col = Color.FromArgb(255, 150, 150, 150);
                            break;
                        case 2:
                            col = Color.FromArgb(255, 50, 150, 100);
                            break;
                        case 3:
                            col = Color.FromArgb(255, 250, 100, 50);
                            break;
                        case 4:
                            col = Color.FromArgb(255, 70, 170, 220);
                            break;
                        case 5:
                            col = Color.FromArgb(255, 30, 30, 30);
                            break;
                        default:
                            col = Color.FromArgb(255, 200, 50, 100);
                            break;
                    }
                    SolidBrush sbrs = new SolidBrush(col);
                    gra.FillRectangle(sbrs, ((int)point[i].Xpos - xvol * gap / 2) / 20 + pb1.Width / 2,
                                            ((int)point[i].Ypos - yvol * gap / 2) / 20 + pb1.Height / 2, 10, 10);
                    sbrs.Dispose();
                }
            }

            for (int s=0; s<segvol; s++)
            {
                int mjn = 2;
                int x1 = (int)point[seg[s].p1].Xpos;
                int y1 = (int)point[seg[s].p1].Ypos;
                int x2 = (int)point[seg[s].p2].Xpos;
                int y2 = (int)point[seg[s].p2].Ypos;
                int sx = ((x1+x2) / 2 - xvol * gap / 2) / 20 + pb1.Width / 2 + mjn;
                int sy = ((y1+y2) / 2 - yvol * gap / 2) / 20 + pb1.Height / 2 + mjn;

                SolidBrush sbrss = new SolidBrush(Color.FromArgb(255, 100, 200, 50));
                gra.FillRectangle(sbrss, sx, sy, 5, 5);
                sbrss.Dispose();
            }

            if (areaselect_flg == true)   //条件設定時　範囲着色
            {
                SolidBrush cbrs = new SolidBrush(Color.FromArgb(50, 50, 100, 200));
                gra.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected;
                gra.FillRectangle(cbrs, area_x0,area_y0,area_x1-area_x0,area_y1-area_y0);
                cbrs.Dispose();
            }
            pb1.Image = bmp;
            gra.Dispose();
        }

        private void btn_kapply_Click(object sender, EventArgs e)
        {
            kval = Convert.ToDouble(txt_kval.Text);
            weight = Convert.ToDouble(txt_weight.Text);
            gx = Convert.ToDouble(txt_gx.Text);
            gy = Convert.ToDouble(txt_gy.Text);
            damp = Convert.ToDouble(txt_damp.Text);
        }

        private void pb1_MouseDown(object sender, MouseEventArgs e)     //pb1マウスイベント--------
        {
            if (cond_flg == true && areaselect_flg == false)
            {
                area_x0 = e.X; area_y0 = e.Y;
                areaselect_flg = true;
            }
        }

        private void pb1_MouseMove(object sender, MouseEventArgs e)
        {
            if (cond_flg == true && areaselect_flg == true)
            {
                area_x1 = e.X; area_y1 = e.Y;
                factdraw();
            }
            else
            if (grab_flg == true)
            {
                point[grabp].Xpos = 20*(e.X + xvol*gap/40 - pb1.Width/2);
                point[grabp].Ypos = 20*(e.Y + yvol*gap/40 - pb1.Height/2);
            }
        }

        private void pb1_MouseUp(object sender, MouseEventArgs e)
        {
            if (cond_flg == true && areaselect_flg == true)
            {
                area_x1 = e.X; area_y1 = e.Y;
                areaselect_flg = false;

                for (int i = 0; i < xvol * yvol; i++)
                {
                    double px = (point[i].Xpos - xvol * gap / 2) / 20 + pb1.Width / 2;
                    double py = (point[i].Ypos - yvol * gap / 2) / 20 + pb1.Height / 2;

                    if (px > area_x0 && px < area_x1 && py > area_y0 && py < area_y1)
                    {
                        point[i].atrb = 1;  //point selected
                        selectvol++;
                        selectpoint.Add(i);     //ジェネリックリストに登録
                    }
                    factdraw();
                }
                if (selectvol > 0)
                { groupBox1.Enabled = true; }
                else
                { areaselect_flg = false; }
            }
        }

        private void pb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //int grabp0 = grabp;
            for (int i = 0; i < xvol * yvol; i++)
            {
                double px = (point[i].Xpos - xvol * gap / 2) / 20 + pb1.Width / 2;
                double py = (point[i].Ypos - yvol * gap / 2) / 20 + pb1.Height / 2;
                var dx = Math.Abs(px - e.X);
                var dy = Math.Abs(py - e.Y);
                if (dx < 10 && dy < 10)
                {
                    grabp = i;
                }
            }

            if(grabp != grabp0)      //新しい点が選択された
            {
                point[grabp].atrb = 5;
                point[grabp].Xv = 0;
                point[grabp].Yv = 0;
                grab_flg = true;

                if (grabp0 != -1)   //前の選択点あり
                {
                    point[grabp0].atrb = 0;
                    point[grabp0].Xv = 0;
                    point[grabp0].Yv = 0;
                }
                else
                {
                    grab_flg = true;
                }

                grabp0 = grabp;
                setcond("simstart");
            }
            else
            {
                //同じ点が選択された
                point[grabp].atrb = 0;
                point[grabp].Xv = 0;
                point[grabp].Yv = 0;
                grab_flg = false;
                grabp = -1; grabp0 = -1;
            }
        }


        private void btn_restart_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < yvol; y++)      //パラメータ初期化
            {
                for (int x = 0; x < xvol; x++)
                {
                    int i = y * xvol + x;
                    point[i].Xfrc = 0; point[i].Xv = 0;
                    point[i].Yfrc = 0; point[i].Yv = 0;
                    point[i].Xpos = x * gap;
                    point[i].Ypos = y * gap;
                }
            }
            setcond("file_selected");
        }



        private void btn_atrclear_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < xvol * yvol; i++)
            {
                point[i].atrb = 0;
            }
            foreach(int i in selectpoint) { point[i].atrb = 0; }
            factdraw();
        }


        private void btn_apply_Click(object sender, EventArgs e)
        {
            int a = 1;
            foreach (int i in selectpoint)
            {
                if (rb_Xlock.Checked == true) { a = 2; }
                if (rb_Ylock.Checked == true) { a = 3; }
                if (rb_XYlock.Checked == true) { a = 4; }
                if (rb_NOlock.Checked == true) { a = 0; }
                point[i].atrb = a;
                point[i].Xv = 0; point[i].Yv = 0;
            }
            areaselect_flg = false;
            setcond("cond_apply");
        }


        private void calc()     //演算---------------------
        {
            for (int i=0; i<xvol*yvol; i++)
            {
                point[i].Xfrc = 0;
                point[i].Yfrc = 0;
            }

            for (int s =0; s < segvol; s++)     //セグメント応力
            {
                double xl = point[seg[s].p2].Xpos - point[seg[s].p1].Xpos;
                double yl = point[seg[s].p2].Ypos - point[seg[s].p1].Ypos;
                double reallenth = Math.Sqrt(xl * xl + yl * yl);
                double dl = seg[s].inilth - reallenth;
                double forcex = kval * xl * dl / reallenth * 1;
                double forcey = kval * yl * dl / reallenth * 1;
                point[seg[s].p1].Xfrc -= forcex;
                point[seg[s].p2].Xfrc += forcex;
                point[seg[s].p1].Yfrc -= forcey;
                point[seg[s].p2].Yfrc += forcey;
            }

            for (int i=0; i<xvol*yvol; i++)     //point運動演算
            {
                    double m = point[i].Mass * weight;
                    double fx = point[i].Xfrc;
                    double fy = point[i].Yfrc;
                    double vx = point[i].Xv;
                    double vy = point[i].Yv;

                    double ax = fx / m + gx;
                    double ay = fy / m + gy;
                    int a = point[i].atrb;
                    if (a != 2 && a != 4 && a != 5)
                    {
                        vx = (vx + ax) * damp;
                    }
                    if (a != 3 && a != 4 && a != 5)
                    {
                        vy = (vy + ay) * damp;
                    }
                    point[i].Xv = vx; point[i].Yv = vy;
                    point[i].Xpos += vx; point[i].Ypos += vy;
            }
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;     //状態リセット
            xvol = 0; yvol = 0; segvol = 0;
            cond_flg = false;


            string strFileName = comboBox1.Text;    //ファイル読み直し
            StreamReader rline = new StreamReader(strFileName);

            var masslist = new List<List<int>>();   //質量マップ:2次元ジェネリック

            while (rline.Peek() > -1)
            {
                string rl = rline.ReadLine();
                var values = rl.Split(',', '\r', '\n');
                xvol = values.Length;
                var list1 = new List<int>();

                for (int x = 0; x < xvol; x++)
                {
                    list1.Add(Convert.ToInt32(values[x]));
                }
                masslist.Add(list1);
                yvol++;
            }
            rline.Close();

            //point.CopyTo(point = new Fact[yvol * xvol], 0);    //factをリサイズ
            Array.Resize(ref point, xvol * yvol);

            for (int y = 0; y < yvol; y++)      //パラメータ初期化
            {
                for (int x = 0; x < xvol; x++)
                {
                    int i = y * xvol + x;
                    point[i].Mass = masslist[y][x];
                    point[i].Xfrc = 0; point[i].Xv = 0;
                    point[i].Yfrc = 0; point[i].Yv = 0;
                    point[i].Xn = x; point[i].Xpos = x * gap;
                    point[i].Yn = y; point[i].Ypos = y * gap;
                    point[i].atrb = 0;
                }
            }
            setcond("file_selected");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Assembly myAssembly = Assembly.GetEntryAssembly();
            //string path = myAssembly.Location;
            //string[] files = Directory.GetFiles(path);

            //string[] files = Directory.GetFiles(@"c:/FEMdata", "*.txt");
            string[] files = Directory.GetFiles(@"FEMdata", "*.txt");
            comboBox1.Items.AddRange(files);
            kval = 700;     txt_kval.Text = Convert.ToString(kval);
            weight = 3000;  txt_weight.Text = Convert.ToString(weight);
            gx = 0;         txt_gx.Text = Convert.ToString(gx);
            gy = 3;         txt_gy.Text = Convert.ToString(gy);
            damp = 0.988;   txt_damp.Text = Convert.ToString(damp);
            bmp = new Bitmap(pb1.Width, pb1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            calc();
            factdraw();
        }


        private void setcond(string str)
        {
            switch (str)
            {
                case "file_selected":
                    segmake();
                    factdraw();
                    btn_simstart.Enabled = true;
                    btn_simstart.Text = "シミュレート開始";
                    btn_cond.Enabled = true;
                    act_flg = false;    //非実行中
                    grab_flg = false;
                    areaselect_flg = false;
                    timer1.Enabled = false;
                    break;
                case "simstart":
                    btn_simstart.Text = "停止";
                    btn_cond.Enabled = false;
                    act_flg = true;
                    //grab_flg = false;
                    areaselect_flg = false;
                    cond_flg = false;
                    timer1.Enabled = true;
                    break;
                case "simpause":
                    btn_simstart.Text = "シミュレート開始";
                    btn_cond.Enabled = true;
                    act_flg = false;
                    grab_flg = false;
                    cond_flg = true;
                    timer1.Enabled = false;
                    break;
                case "simreset":
                    segmake();
                    factdraw();
                    grab_flg = false;
                    timer1.Enabled = false;
                    break;
                case "cond_start":
                    segmake();
                    factdraw();
                    btn_simstart.Enabled = false;
                    btn_restart.Enabled = false;
                    cond_flg = true;    //cond設定中
                    grab_flg = false;
                    areaselect_flg = false;
                    timer1.Enabled = false;
                    break;
                case "cond_apply":
                    factdraw();
                    btn_simstart.Enabled = true;
                    btn_restart.Enabled = true;
                    areaselect_flg = false;
                    grab_flg = false;
                    groupBox1.Enabled = false;
                    selectpoint.Clear();
                    //cond_flg = false;
                    break;

            }


        }

    }
}
