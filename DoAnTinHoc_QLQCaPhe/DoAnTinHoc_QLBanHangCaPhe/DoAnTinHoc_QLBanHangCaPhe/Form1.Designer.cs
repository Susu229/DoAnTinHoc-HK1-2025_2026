namespace DoAnTinHoc_QLBanHangCaPhe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridView1 = new DataGridView();
            dsbtn = new Button();
            btnXoaTheoTen = new Button();
            txtTenMonCanXoa = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(276, 28);
            button1.Name = "button1";
            button1.Size = new Size(101, 29);
            button1.TabIndex = 0;
            button1.Text = "Xử Lý CSV";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(919, 430);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dsbtn
            // 
            dsbtn.Location = new Point(276, 63);
            dsbtn.Name = "dsbtn";
            dsbtn.Size = new Size(94, 29);
            dsbtn.TabIndex = 2;
            dsbtn.Text = "DanhSach";
            dsbtn.UseVisualStyleBackColor = true;
            dsbtn.Click += button2_Click;
            // 
            // btnXoaTheoTen
            // 
            btnXoaTheoTen.Location = new Point(276, 98);
            btnXoaTheoTen.Name = "btnXoaTheoTen";
            btnXoaTheoTen.Size = new Size(127, 29);
            btnXoaTheoTen.TabIndex = 3;
            btnXoaTheoTen.Text = "Xóa theo tên\r\n\r\n";
            btnXoaTheoTen.UseVisualStyleBackColor = true;
            btnXoaTheoTen.Click += btnXoaTheoTen_Click;
            // 
            // txtTenMonCanXoa
            // 
            txtTenMonCanXoa.Location = new Point(12, 99);
            txtTenMonCanXoa.Name = "txtTenMonCanXoa";
            txtTenMonCanXoa.Size = new Size(241, 27);
            txtTenMonCanXoa.TabIndex = 4;
            txtTenMonCanXoa.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 602);
            Controls.Add(txtTenMonCanXoa);
            Controls.Add(btnXoaTheoTen);
            Controls.Add(dsbtn);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button dsbtn;
        private Button btnXoaTheoTen;
        private TextBox txtTenMonCanXoa;
    }
}