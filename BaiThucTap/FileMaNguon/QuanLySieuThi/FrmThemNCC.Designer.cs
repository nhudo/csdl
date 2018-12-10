namespace QuanLySieuThi
{
    partial class FrmThemNCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThemNCC));
            this.sdttextBox2 = new System.Windows.Forms.TextBox();
            this.diachitextBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tennccTextBox = new System.Windows.Forms.TextBox();
            this.manccTextBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            tenkhoaLabel = new System.Windows.Forms.Label();
            makhoaLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // sdttextBox2
            // 
            this.sdttextBox2.Location = new System.Drawing.Point(102, 149);
            this.sdttextBox2.Name = "sdttextBox2";
            this.sdttextBox2.Size = new System.Drawing.Size(162, 20);
            this.sdttextBox2.TabIndex = 25;
            this.sdttextBox2.TextChanged += new System.EventHandler(this.sdttextBox2_TextChanged);
            // 
            // diachitextBox4
            // 
            this.diachitextBox4.Location = new System.Drawing.Point(102, 113);
            this.diachitextBox4.Name = "diachitextBox4";
            this.diachitextBox4.Size = new System.Drawing.Size(162, 20);
            this.diachitextBox4.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Số Điện Thoại :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Địa Chỉ :";
            // 
            // tenkhoaLabel
            // 
            tenkhoaLabel.AutoSize = true;
            tenkhoaLabel.Location = new System.Drawing.Point(39, 80);
            tenkhoaLabel.Name = "tenkhoaLabel";
            tenkhoaLabel.Size = new System.Drawing.Size(57, 13);
            tenkhoaLabel.TabIndex = 20;
            tenkhoaLabel.Text = "Tên NCC :";
            // 
            // tennccTextBox
            // 
            this.tennccTextBox.Location = new System.Drawing.Point(102, 77);
            this.tennccTextBox.Name = "tennccTextBox";
            this.tennccTextBox.Size = new System.Drawing.Size(162, 20);
            this.tennccTextBox.TabIndex = 21;
            this.tennccTextBox.TextChanged += new System.EventHandler(this.tennccTextBox_TextChanged);
            // 
            // makhoaLabel2
            // 
            makhoaLabel2.AutoSize = true;
            makhoaLabel2.Location = new System.Drawing.Point(46, 40);
            makhoaLabel2.Name = "makhoaLabel2";
            makhoaLabel2.Size = new System.Drawing.Size(50, 13);
            makhoaLabel2.TabIndex = 18;
            makhoaLabel2.Text = "Mã NCC:";
            // 
            // manccTextBox2
            // 
            this.manccTextBox2.Location = new System.Drawing.Point(102, 37);
            this.manccTextBox2.Name = "manccTextBox2";
            this.manccTextBox2.Size = new System.Drawing.Size(162, 20);
            this.manccTextBox2.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Image = global::QuanLySieuThi.Properties.Resources.check_icgchjgfhon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(113, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 26;
            this.button1.Text = "       OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmThemNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 260);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sdttextBox2);
            this.Controls.Add(this.diachitextBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(tenkhoaLabel);
            this.Controls.Add(this.tennccTextBox);
            this.Controls.Add(makhoaLabel2);
            this.Controls.Add(this.manccTextBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmThemNCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Nhà Cung Cấp ";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox sdttextBox2;
        private System.Windows.Forms.TextBox diachitextBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tennccTextBox;
        private System.Windows.Forms.TextBox manccTextBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}