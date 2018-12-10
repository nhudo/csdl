namespace QuanLySieuThi
{
    partial class FrmLayThongTinKH
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label tenkhoaLabel;
            System.Windows.Forms.Label makhoaLabel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLayThongTinKH));
            this.tenkhTextBox = new System.Windows.Forms.TextBox();
            this.makhTextBox2 = new System.Windows.Forms.TextBox();
            this.sdttextBox2 = new System.Windows.Forms.TextBox();
            this.diachitextBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            tenkhoaLabel = new System.Windows.Forms.Label();
            makhoaLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tenkhoaLabel
            // 
            tenkhoaLabel.AutoSize = true;
            tenkhoaLabel.Location = new System.Drawing.Point(40, 76);
            tenkhoaLabel.Name = "tenkhoaLabel";
            tenkhoaLabel.Size = new System.Drawing.Size(50, 13);
            tenkhoaLabel.TabIndex = 10;
            tenkhoaLabel.Text = "Tên KH :";
            // 
            // tenkhTextBox
            // 
            this.tenkhTextBox.Location = new System.Drawing.Point(96, 73);
            this.tenkhTextBox.Name = "tenkhTextBox";
            this.tenkhTextBox.Size = new System.Drawing.Size(162, 20);
            this.tenkhTextBox.TabIndex = 11;
            this.tenkhTextBox.TextChanged += new System.EventHandler(this.tenkhTextBox_TextChanged);
            // 
            // makhoaLabel2
            // 
            makhoaLabel2.AutoSize = true;
            makhoaLabel2.Location = new System.Drawing.Point(47, 36);
            makhoaLabel2.Name = "makhoaLabel2";
            makhoaLabel2.Size = new System.Drawing.Size(43, 13);
            makhoaLabel2.TabIndex = 8;
            makhoaLabel2.Text = "Mã KH:";
            // 
            // makhTextBox2
            // 
            this.makhTextBox2.Location = new System.Drawing.Point(96, 33);
            this.makhTextBox2.Name = "makhTextBox2";
            this.makhTextBox2.Size = new System.Drawing.Size(162, 20);
            this.makhTextBox2.TabIndex = 9;
            // 
            // sdttextBox2
            // 
            this.sdttextBox2.Location = new System.Drawing.Point(96, 145);
            this.sdttextBox2.Name = "sdttextBox2";
            this.sdttextBox2.Size = new System.Drawing.Size(162, 20);
            this.sdttextBox2.TabIndex = 15;
            this.sdttextBox2.TextChanged += new System.EventHandler(this.sdttextBox2_TextChanged);
            // 
            // diachitextBox4
            // 
            this.diachitextBox4.Location = new System.Drawing.Point(96, 109);
            this.diachitextBox4.Name = "diachitextBox4";
            this.diachitextBox4.Size = new System.Drawing.Size(162, 20);
            this.diachitextBox4.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Số Điện Thoại :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Địa Chỉ :";
            // 
            // button2
            // 
            this.button2.Image = global::QuanLySieuThi.Properties.Resources.undo_512;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(183, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 35);
            this.button2.TabIndex = 17;
            this.button2.Text = "Quay Lại";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::QuanLySieuThi.Properties.Resources.check_icgchjgfhon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(43, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "       OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmLayThongTinKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sdttextBox2);
            this.Controls.Add(this.diachitextBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(tenkhoaLabel);
            this.Controls.Add(this.tenkhTextBox);
            this.Controls.Add(makhoaLabel2);
            this.Controls.Add(this.makhTextBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLayThongTinKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông Tin Khách Hàng";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tenkhTextBox;
        private System.Windows.Forms.TextBox makhTextBox2;
        private System.Windows.Forms.TextBox sdttextBox2;
        private System.Windows.Forms.TextBox diachitextBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}