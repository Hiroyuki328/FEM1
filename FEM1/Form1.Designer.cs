namespace FEM1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.btn_cond = new System.Windows.Forms.Button();
            this.btn_simstart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_NOlock = new System.Windows.Forms.RadioButton();
            this.rb_Ylock = new System.Windows.Forms.RadioButton();
            this.rb_Xlock = new System.Windows.Forms.RadioButton();
            this.rb_XYlock = new System.Windows.Forms.RadioButton();
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_atrclear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_kapply = new System.Windows.Forms.Button();
            this.txt_damp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_gy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_gx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_weight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_kval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pb1.Location = new System.Drawing.Point(9, 42);
            this.pb1.Margin = new System.Windows.Forms.Padding(2);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(597, 723);
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            this.pb1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pb1_MouseDoubleClick);
            this.pb1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb1_MouseDown);
            this.pb1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb1_MouseMove);
            this.pb1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb1_MouseUp);
            // 
            // btn_cond
            // 
            this.btn_cond.Enabled = false;
            this.btn_cond.Location = new System.Drawing.Point(620, 42);
            this.btn_cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cond.Name = "btn_cond";
            this.btn_cond.Size = new System.Drawing.Size(107, 34);
            this.btn_cond.TabIndex = 1;
            this.btn_cond.Text = "境界条件";
            this.btn_cond.UseVisualStyleBackColor = true;
            this.btn_cond.Click += new System.EventHandler(this.btn_cond_Click);
            // 
            // btn_simstart
            // 
            this.btn_simstart.Enabled = false;
            this.btn_simstart.Location = new System.Drawing.Point(500, 2);
            this.btn_simstart.Margin = new System.Windows.Forms.Padding(2);
            this.btn_simstart.Name = "btn_simstart";
            this.btn_simstart.Size = new System.Drawing.Size(106, 34);
            this.btn_simstart.TabIndex = 3;
            this.btn_simstart.Text = "シミュレート開始";
            this.btn_simstart.UseVisualStyleBackColor = true;
            this.btn_simstart.Click += new System.EventHandler(this.btn_simstart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 10);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(410, 22);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_NOlock);
            this.groupBox1.Controls.Add(this.rb_Ylock);
            this.groupBox1.Controls.Add(this.rb_Xlock);
            this.groupBox1.Controls.Add(this.rb_XYlock);
            this.groupBox1.Controls.Add(this.btn_apply);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(620, 107);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(108, 138);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件設定";
            // 
            // rb_NOlock
            // 
            this.rb_NOlock.AutoSize = true;
            this.rb_NOlock.Location = new System.Drawing.Point(17, 77);
            this.rb_NOlock.Margin = new System.Windows.Forms.Padding(2);
            this.rb_NOlock.Name = "rb_NOlock";
            this.rb_NOlock.Size = new System.Drawing.Size(66, 16);
            this.rb_NOlock.TabIndex = 7;
            this.rb_NOlock.TabStop = true;
            this.rb_NOlock.Text = "拘束なし";
            this.rb_NOlock.UseVisualStyleBackColor = true;
            // 
            // rb_Ylock
            // 
            this.rb_Ylock.AutoSize = true;
            this.rb_Ylock.Location = new System.Drawing.Point(17, 57);
            this.rb_Ylock.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Ylock.Name = "rb_Ylock";
            this.rb_Ylock.Size = new System.Drawing.Size(54, 16);
            this.rb_Ylock.TabIndex = 6;
            this.rb_Ylock.TabStop = true;
            this.rb_Ylock.Text = "Y拘束";
            this.rb_Ylock.UseVisualStyleBackColor = true;
            // 
            // rb_Xlock
            // 
            this.rb_Xlock.AutoSize = true;
            this.rb_Xlock.Location = new System.Drawing.Point(17, 37);
            this.rb_Xlock.Margin = new System.Windows.Forms.Padding(2);
            this.rb_Xlock.Name = "rb_Xlock";
            this.rb_Xlock.Size = new System.Drawing.Size(54, 16);
            this.rb_Xlock.TabIndex = 5;
            this.rb_Xlock.TabStop = true;
            this.rb_Xlock.Text = "X拘束";
            this.rb_Xlock.UseVisualStyleBackColor = true;
            // 
            // rb_XYlock
            // 
            this.rb_XYlock.AutoSize = true;
            this.rb_XYlock.Location = new System.Drawing.Point(17, 17);
            this.rb_XYlock.Margin = new System.Windows.Forms.Padding(2);
            this.rb_XYlock.Name = "rb_XYlock";
            this.rb_XYlock.Size = new System.Drawing.Size(63, 16);
            this.rb_XYlock.TabIndex = 4;
            this.rb_XYlock.TabStop = true;
            this.rb_XYlock.Text = "X,Y拘束";
            this.rb_XYlock.UseVisualStyleBackColor = true;
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(17, 97);
            this.btn_apply.Margin = new System.Windows.Forms.Padding(2);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(71, 31);
            this.btn_apply.TabIndex = 2;
            this.btn_apply.Text = "適用";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(620, 2);
            this.btn_restart.Margin = new System.Windows.Forms.Padding(2);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(106, 34);
            this.btn_restart.TabIndex = 9;
            this.btn_restart.Text = "位置リセット";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_atrclear
            // 
            this.btn_atrclear.Location = new System.Drawing.Point(638, 81);
            this.btn_atrclear.Margin = new System.Windows.Forms.Padding(2);
            this.btn_atrclear.Name = "btn_atrclear";
            this.btn_atrclear.Size = new System.Drawing.Size(71, 22);
            this.btn_atrclear.TabIndex = 10;
            this.btn_atrclear.Text = "全解除";
            this.btn_atrclear.UseVisualStyleBackColor = true;
            this.btn_atrclear.Click += new System.EventHandler(this.btn_atrclear_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_kapply);
            this.groupBox2.Controls.Add(this.txt_damp);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_gy);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_gx);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_weight);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_kval);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(620, 269);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(106, 170);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "係数";
            // 
            // btn_kapply
            // 
            this.btn_kapply.Location = new System.Drawing.Point(17, 130);
            this.btn_kapply.Margin = new System.Windows.Forms.Padding(2);
            this.btn_kapply.Name = "btn_kapply";
            this.btn_kapply.Size = new System.Drawing.Size(71, 31);
            this.btn_kapply.TabIndex = 10;
            this.btn_kapply.Text = "適用";
            this.btn_kapply.UseVisualStyleBackColor = true;
            this.btn_kapply.Click += new System.EventHandler(this.btn_kapply_Click);
            // 
            // txt_damp
            // 
            this.txt_damp.Location = new System.Drawing.Point(55, 107);
            this.txt_damp.Margin = new System.Windows.Forms.Padding(2);
            this.txt_damp.Name = "txt_damp";
            this.txt_damp.Size = new System.Drawing.Size(42, 19);
            this.txt_damp.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "減衰";
            // 
            // txt_gy
            // 
            this.txt_gy.Location = new System.Drawing.Point(55, 85);
            this.txt_gy.Margin = new System.Windows.Forms.Padding(2);
            this.txt_gy.Name = "txt_gy";
            this.txt_gy.Size = new System.Drawing.Size(42, 19);
            this.txt_gy.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "gy";
            // 
            // txt_gx
            // 
            this.txt_gx.Location = new System.Drawing.Point(55, 62);
            this.txt_gx.Margin = new System.Windows.Forms.Padding(2);
            this.txt_gx.Name = "txt_gx";
            this.txt_gx.Size = new System.Drawing.Size(42, 19);
            this.txt_gx.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "gx";
            // 
            // txt_weight
            // 
            this.txt_weight.Location = new System.Drawing.Point(56, 40);
            this.txt_weight.Margin = new System.Windows.Forms.Padding(2);
            this.txt_weight.Name = "txt_weight";
            this.txt_weight.Size = new System.Drawing.Size(42, 19);
            this.txt_weight.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "質量";
            // 
            // txt_kval
            // 
            this.txt_kval.Location = new System.Drawing.Point(56, 18);
            this.txt_kval.Margin = new System.Windows.Forms.Padding(2);
            this.txt_kval.Name = "txt_kval";
            this.txt_kval.Size = new System.Drawing.Size(42, 19);
            this.txt_kval.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "弾性";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "モデル選択";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 774);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_atrclear);
            this.Controls.Add(this.btn_restart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_simstart);
            this.Controls.Add(this.btn_cond);
            this.Controls.Add(this.pb1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.Button btn_cond;
        private System.Windows.Forms.Button btn_simstart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.RadioButton rb_NOlock;
        private System.Windows.Forms.RadioButton rb_Ylock;
        private System.Windows.Forms.RadioButton rb_Xlock;
        private System.Windows.Forms.RadioButton rb_XYlock;
        private System.Windows.Forms.Button btn_atrclear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_kapply;
        private System.Windows.Forms.TextBox txt_damp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_gy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_gx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_weight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_kval;
        private System.Windows.Forms.Label label6;
    }
}

