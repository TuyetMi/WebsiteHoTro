namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_reset = new System.Windows.Forms.Button();
            this.txt_top5 = new System.Windows.Forms.Label();
            this.resultLabel4 = new System.Windows.Forms.Label();
            this.resultLabel3 = new System.Windows.Forms.Label();
            this.resultLabel2 = new System.Windows.Forms.Label();
            this.resultLabel1 = new System.Windows.Forms.Label();
            this.btn_themSV = new System.Windows.Forms.Button();
            this.txt_ma = new System.Windows.Forms.TextBox();
            this.txt_masv = new System.Windows.Forms.Label();
            this.btn_TimCN = new System.Windows.Forms.Button();
            this.txt_KT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_HDH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_MMT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_TT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_HQT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_NET = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_LT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_NM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_napdl = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 282);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1270, 373);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1295, 687);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_reset);
            this.tabPage1.Controls.Add(this.txt_top5);
            this.tabPage1.Controls.Add(this.resultLabel4);
            this.tabPage1.Controls.Add(this.resultLabel3);
            this.tabPage1.Controls.Add(this.resultLabel2);
            this.tabPage1.Controls.Add(this.resultLabel1);
            this.tabPage1.Controls.Add(this.btn_themSV);
            this.tabPage1.Controls.Add(this.txt_ma);
            this.tabPage1.Controls.Add(this.txt_masv);
            this.tabPage1.Controls.Add(this.btn_TimCN);
            this.tabPage1.Controls.Add(this.txt_KT);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txt_HDH);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txt_MMT);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txt_TT);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txt_HQT);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_CS);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_NET);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txt_LT);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt_CT);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_NM);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1287, 661);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(20, 238);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(126, 42);
            this.btn_reset.TabIndex = 54;
            this.btn_reset.Text = "RESET";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // txt_top5
            // 
            this.txt_top5.AutoSize = true;
            this.txt_top5.Location = new System.Drawing.Point(33, 299);
            this.txt_top5.Name = "txt_top5";
            this.txt_top5.Size = new System.Drawing.Size(43, 13);
            this.txt_top5.TabIndex = 53;
            this.txt_top5.Text = "kết quả";
            // 
            // resultLabel4
            // 
            this.resultLabel4.AutoSize = true;
            this.resultLabel4.Location = new System.Drawing.Point(1087, 18);
            this.resultLabel4.Name = "resultLabel4";
            this.resultLabel4.Size = new System.Drawing.Size(50, 13);
            this.resultLabel4.TabIndex = 52;
            this.resultLabel4.Text = "KHPTDL";
            // 
            // resultLabel3
            // 
            this.resultLabel3.AutoSize = true;
            this.resultLabel3.Location = new System.Drawing.Point(880, 18);
            this.resultLabel3.Name = "resultLabel3";
            this.resultLabel3.Size = new System.Drawing.Size(32, 13);
            this.resultLabel3.TabIndex = 51;
            this.resultLabel3.Text = "MMT";
            // 
            // resultLabel2
            // 
            this.resultLabel2.AutoSize = true;
            this.resultLabel2.Location = new System.Drawing.Point(655, 18);
            this.resultLabel2.Name = "resultLabel2";
            this.resultLabel2.Size = new System.Drawing.Size(36, 13);
            this.resultLabel2.TabIndex = 50;
            this.resultLabel2.Text = "HTTT";
            // 
            // resultLabel1
            // 
            this.resultLabel1.AutoSize = true;
            this.resultLabel1.Location = new System.Drawing.Point(397, 17);
            this.resultLabel1.Name = "resultLabel1";
            this.resultLabel1.Size = new System.Drawing.Size(38, 13);
            this.resultLabel1.TabIndex = 49;
            this.resultLabel1.Text = "CNPM";
            // 
            // btn_themSV
            // 
            this.btn_themSV.Location = new System.Drawing.Point(282, 238);
            this.btn_themSV.Name = "btn_themSV";
            this.btn_themSV.Size = new System.Drawing.Size(126, 51);
            this.btn_themSV.TabIndex = 48;
            this.btn_themSV.Text = "Thêm sinh viên";
            this.btn_themSV.UseVisualStyleBackColor = true;
            this.btn_themSV.Click += new System.EventHandler(this.btn_themSV_Click);
            // 
            // txt_ma
            // 
            this.txt_ma.Location = new System.Drawing.Point(119, 18);
            this.txt_ma.Name = "txt_ma";
            this.txt_ma.Size = new System.Drawing.Size(190, 20);
            this.txt_ma.TabIndex = 47;
            // 
            // txt_masv
            // 
            this.txt_masv.AutoSize = true;
            this.txt_masv.Location = new System.Drawing.Point(18, 21);
            this.txt_masv.Name = "txt_masv";
            this.txt_masv.Size = new System.Drawing.Size(95, 13);
            this.txt_masv.TabIndex = 46;
            this.txt_masv.Text = "Nhập mã sinh viên";
            // 
            // btn_TimCN
            // 
            this.btn_TimCN.Location = new System.Drawing.Point(150, 238);
            this.btn_TimCN.Name = "btn_TimCN";
            this.btn_TimCN.Size = new System.Drawing.Size(126, 50);
            this.btn_TimCN.TabIndex = 45;
            this.btn_TimCN.Text = "Tìm chuyên ngành";
            this.btn_TimCN.UseVisualStyleBackColor = true;
            this.btn_TimCN.Click += new System.EventHandler(this.btn_TimCN_Click_1);
            // 
            // txt_KT
            // 
            this.txt_KT.Location = new System.Drawing.Point(285, 203);
            this.txt_KT.Name = "txt_KT";
            this.txt_KT.Size = new System.Drawing.Size(55, 20);
            this.txt_KT.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(183, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Kiến trúc máy tính";
            // 
            // txt_HDH
            // 
            this.txt_HDH.Location = new System.Drawing.Point(285, 163);
            this.txt_HDH.Name = "txt_HDH";
            this.txt_HDH.Size = new System.Drawing.Size(55, 20);
            this.txt_HDH.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Hệ điều hành";
            // 
            // txt_MMT
            // 
            this.txt_MMT.Location = new System.Drawing.Point(285, 128);
            this.txt_MMT.Name = "txt_MMT";
            this.txt_MMT.Size = new System.Drawing.Size(55, 20);
            this.txt_MMT.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Mạng máy tính";
            // 
            // txt_TT
            // 
            this.txt_TT.Location = new System.Drawing.Point(285, 92);
            this.txt_TT.Name = "txt_TT";
            this.txt_TT.Size = new System.Drawing.Size(55, 20);
            this.txt_TT.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Trí tuệ nhân tạo";
            // 
            // txt_HQT
            // 
            this.txt_HQT.Location = new System.Drawing.Point(285, 58);
            this.txt_HQT.Name = "txt_HQT";
            this.txt_HQT.Size = new System.Drawing.Size(55, 20);
            this.txt_HQT.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Hệ quản trị";
            // 
            // txt_CS
            // 
            this.txt_CS.Location = new System.Drawing.Point(119, 203);
            this.txt_CS.Name = "txt_CS";
            this.txt_CS.Size = new System.Drawing.Size(53, 20);
            this.txt_CS.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Cơ sở dữ liệu";
            // 
            // txt_NET
            // 
            this.txt_NET.Location = new System.Drawing.Point(119, 167);
            this.txt_NET.Name = "txt_NET";
            this.txt_NET.Size = new System.Drawing.Size(53, 20);
            this.txt_NET.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Công nghệ NET";
            // 
            // txt_LT
            // 
            this.txt_LT.Location = new System.Drawing.Point(119, 129);
            this.txt_LT.Name = "txt_LT";
            this.txt_LT.Size = new System.Drawing.Size(53, 20);
            this.txt_LT.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Lập trình HDT";
            // 
            // txt_CT
            // 
            this.txt_CT.Location = new System.Drawing.Point(119, 94);
            this.txt_CT.Name = "txt_CT";
            this.txt_CT.Size = new System.Drawing.Size(53, 20);
            this.txt_CT.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Cấu trúc dl va gt";
            // 
            // txt_NM
            // 
            this.txt_NM.Location = new System.Drawing.Point(119, 58);
            this.txt_NM.Name = "txt_NM";
            this.txt_NM.Size = new System.Drawing.Size(53, 20);
            this.txt_NM.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nhập môn lập trình";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_load);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.btn_napdl);
            this.tabPage2.Controls.Add(this.listBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1287, 661);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(441, 69);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 58);
            this.btn_load.TabIndex = 49;
            this.btn_load.Text = "Load ";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click_1);
            // 
            // btn_napdl
            // 
            this.btn_napdl.Location = new System.Drawing.Point(441, 6);
            this.btn_napdl.Name = "btn_napdl";
            this.btn_napdl.Size = new System.Drawing.Size(75, 57);
            this.btn_napdl.TabIndex = 48;
            this.btn_napdl.Text = "Nạp dữ liệu";
            this.btn_napdl.UseVisualStyleBackColor = true;
            this.btn_napdl.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(11, 6);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(424, 264);
            this.listBox.TabIndex = 47;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 699);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_TimCN;
        private System.Windows.Forms.TextBox txt_KT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_HDH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_MMT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_TT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_HQT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_CS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_NET;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_LT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_NM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_napdl;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox txt_ma;
        private System.Windows.Forms.Label txt_masv;
        private System.Windows.Forms.Button btn_themSV;
        private System.Windows.Forms.Label resultLabel1;
        private System.Windows.Forms.Label resultLabel2;
        private System.Windows.Forms.Label resultLabel4;
        private System.Windows.Forms.Label resultLabel3;
        private System.Windows.Forms.Label txt_top5;
        private System.Windows.Forms.Button btn_reset;
    }
}

