namespace AES_encrypt
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btGiaiMa = new System.Windows.Forms.Button();
            this.tbDKhoa = new System.Windows.Forms.TextBox();
            this.tbDBanRo = new System.Windows.Forms.TextBox();
            this.tbDBanMa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBanMa = new System.Windows.Forms.TextBox();
            this.btMaHoa = new System.Windows.Forms.Button();
            this.tbKhoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBanRo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd128 = new System.Windows.Forms.RadioButton();
            this.rd192 = new System.Windows.Forms.RadioButton();
            this.rd256 = new System.Windows.Forms.RadioButton();
            this.panelTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitle.Controls.Add(this.label1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(921, 75);
            this.panelTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(280, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Advanced Encryption Standard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btGiaiMa
            // 
            this.btGiaiMa.Location = new System.Drawing.Point(590, 284);
            this.btGiaiMa.Name = "btGiaiMa";
            this.btGiaiMa.Size = new System.Drawing.Size(75, 23);
            this.btGiaiMa.TabIndex = 27;
            this.btGiaiMa.Text = "Giải Mã";
            this.btGiaiMa.UseVisualStyleBackColor = true;
            this.btGiaiMa.Click += new System.EventHandler(this.btGiaiMa_Click);
            // 
            // tbDKhoa
            // 
            this.tbDKhoa.Location = new System.Drawing.Point(590, 231);
            this.tbDKhoa.Name = "tbDKhoa";
            this.tbDKhoa.Size = new System.Drawing.Size(269, 22);
            this.tbDKhoa.TabIndex = 26;
            // 
            // tbDBanRo
            // 
            this.tbDBanRo.Location = new System.Drawing.Point(590, 341);
            this.tbDBanRo.Name = "tbDBanRo";
            this.tbDBanRo.ReadOnly = true;
            this.tbDBanRo.Size = new System.Drawing.Size(269, 22);
            this.tbDBanRo.TabIndex = 25;
            // 
            // tbDBanMa
            // 
            this.tbDBanMa.Location = new System.Drawing.Point(590, 184);
            this.tbDBanMa.Name = "tbDBanMa";
            this.tbDBanMa.Size = new System.Drawing.Size(269, 22);
            this.tbDBanMa.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(513, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "Bản Rõ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(513, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Khoá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Bản Mã";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Bản Mã";
            // 
            // tbBanMa
            // 
            this.tbBanMa.Location = new System.Drawing.Point(128, 341);
            this.tbBanMa.Name = "tbBanMa";
            this.tbBanMa.ReadOnly = true;
            this.tbBanMa.Size = new System.Drawing.Size(257, 22);
            this.tbBanMa.TabIndex = 19;
            // 
            // btMaHoa
            // 
            this.btMaHoa.Location = new System.Drawing.Point(128, 284);
            this.btMaHoa.Name = "btMaHoa";
            this.btMaHoa.Size = new System.Drawing.Size(75, 23);
            this.btMaHoa.TabIndex = 18;
            this.btMaHoa.Text = "Mã Hoá";
            this.btMaHoa.UseVisualStyleBackColor = true;
            this.btMaHoa.Click += new System.EventHandler(this.btMaHoa_Click);
            // 
            // tbKhoa
            // 
            this.tbKhoa.Location = new System.Drawing.Point(128, 231);
            this.tbKhoa.Name = "tbKhoa";
            this.tbKhoa.Size = new System.Drawing.Size(257, 22);
            this.tbKhoa.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Khoá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Bản Rõ";
            // 
            // tbBanRo
            // 
            this.tbBanRo.Location = new System.Drawing.Point(128, 184);
            this.tbBanRo.Name = "tbBanRo";
            this.tbBanRo.Size = new System.Drawing.Size(257, 22);
            this.tbBanRo.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rd256);
            this.panel1.Controls.Add(this.rd192);
            this.panel1.Controls.Add(this.rd128);
            this.panel1.Location = new System.Drawing.Point(100, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 65);
            this.panel1.TabIndex = 28;
            // 
            // rd128
            // 
            this.rd128.AutoSize = true;
            this.rd128.Checked = true;
            this.rd128.Location = new System.Drawing.Point(28, 23);
            this.rd128.Name = "rd128";
            this.rd128.Size = new System.Drawing.Size(100, 20);
            this.rd128.TabIndex = 0;
            this.rd128.TabStop = true;
            this.rd128.Text = "Khoá 128 bit";
            this.rd128.UseVisualStyleBackColor = true;
            // 
            // rd192
            // 
            this.rd192.AutoSize = true;
            this.rd192.Location = new System.Drawing.Point(162, 22);
            this.rd192.Name = "rd192";
            this.rd192.Size = new System.Drawing.Size(100, 20);
            this.rd192.TabIndex = 1;
            this.rd192.Text = "Khoá 192 bit";
            this.rd192.UseVisualStyleBackColor = true;
            // 
            // rd256
            // 
            this.rd256.AutoSize = true;
            this.rd256.Location = new System.Drawing.Point(297, 23);
            this.rd256.Name = "rd256";
            this.rd256.Size = new System.Drawing.Size(100, 20);
            this.rd256.TabIndex = 2;
            this.rd256.Text = "Khoá 256 bit";
            this.rd256.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btGiaiMa);
            this.Controls.Add(this.tbDKhoa);
            this.Controls.Add(this.tbDBanRo);
            this.Controls.Add(this.tbDBanMa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbBanMa);
            this.Controls.Add(this.btMaHoa);
            this.Controls.Add(this.tbKhoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBanRo);
            this.Controls.Add(this.panelTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGiaiMa;
        private System.Windows.Forms.TextBox tbDKhoa;
        private System.Windows.Forms.TextBox tbDBanRo;
        private System.Windows.Forms.TextBox tbDBanMa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBanMa;
        private System.Windows.Forms.Button btMaHoa;
        private System.Windows.Forms.TextBox tbKhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBanRo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rd256;
        private System.Windows.Forms.RadioButton rd192;
        private System.Windows.Forms.RadioButton rd128;
    }
}

