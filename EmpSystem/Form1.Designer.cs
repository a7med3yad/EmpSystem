namespace EmpSystem
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
            txt_job = new TextBox();
            txt_name = new TextBox();
            txt_salary = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbx_name = new ComboBox();
            label5 = new Label();
            Save = new Button();
            Delete = new Button();
            Edit = new Button();
            src_name = new TextBox();
            label6 = new Label();
            button4 = new Button();
            Enter = new Button();
            pic = new PictureBox();
            button1 = new Button();
            dtg = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg).BeginInit();
            SuspendLayout();
            // 
            // txt_job
            // 
            txt_job.Location = new Point(127, 145);
            txt_job.Name = "txt_job";
            txt_job.Size = new Size(228, 27);
            txt_job.TabIndex = 1;
            // 
            // txt_name
            // 
            txt_name.Location = new Point(127, 102);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(228, 27);
            txt_name.TabIndex = 2;
            // 
            // txt_salary
            // 
            txt_salary.Location = new Point(127, 189);
            txt_salary.Name = "txt_salary";
            txt_salary.Size = new Size(228, 27);
            txt_salary.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 196);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 5;
            label2.Text = "Salary";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 152);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 6;
            label3.Text = "Job";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 109);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 7;
            label4.Text = "Name";
            // 
            // cbx_name
            // 
            cbx_name.FormattingEnabled = true;
            cbx_name.Location = new Point(105, 357);
            cbx_name.Name = "cbx_name";
            cbx_name.Size = new Size(294, 28);
            cbx_name.TabIndex = 8;
            cbx_name.SelectedIndexChanged += cbx_name_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 360);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 9;
            label5.Text = "Name";
            label5.Click += label5_Click;
            // 
            // Save
            // 
            Save.Location = new Point(105, 422);
            Save.Name = "Save";
            Save.Size = new Size(94, 29);
            Save.TabIndex = 10;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(305, 422);
            Delete.Name = "Delete";
            Delete.Size = new Size(94, 29);
            Delete.TabIndex = 11;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Edit
            // 
            Edit.Location = new Point(205, 422);
            Edit.Name = "Edit";
            Edit.Size = new Size(94, 29);
            Edit.TabIndex = 12;
            Edit.Text = "Edit";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // src_name
            // 
            src_name.Location = new Point(515, 433);
            src_name.Name = "src_name";
            src_name.Size = new Size(271, 27);
            src_name.TabIndex = 13;
            src_name.TextChanged += src_name_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(515, 399);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 14;
            label6.Text = "Search";
            // 
            // button4
            // 
            button4.Location = new Point(810, 433);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 15;
            button4.Text = "Show";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Enter
            // 
            Enter.Location = new Point(127, 245);
            Enter.Name = "Enter";
            Enter.Size = new Size(94, 29);
            Enter.TabIndex = 18;
            Enter.Text = "Enter";
            Enter.UseVisualStyleBackColor = true;
            Enter.Click += button5_Click;
            // 
            // pic
            // 
            pic.Location = new Point(566, 121);
            pic.Name = "pic";
            pic.Size = new Size(291, 246);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.TabIndex = 19;
            pic.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(261, 245);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 20;
            button1.Text = "Add Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtg
            // 
            dtg.AllowUserToDeleteRows = false;
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg.BackgroundColor = Color.DodgerBlue;
            dtg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg.Location = new Point(137, 482);
            dtg.Name = "dtg";
            dtg.RowHeadersWidth = 51;
            dtg.Size = new Size(720, 102);
            dtg.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(977, 611);
            Controls.Add(dtg);
            Controls.Add(button1);
            Controls.Add(pic);
            Controls.Add(Enter);
            Controls.Add(button4);
            Controls.Add(label6);
            Controls.Add(src_name);
            Controls.Add(Edit);
            Controls.Add(Delete);
            Controls.Add(Save);
            Controls.Add(label5);
            Controls.Add(cbx_name);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt_salary);
            Controls.Add(txt_name);
            Controls.Add(txt_job);
            Name = "Form1";
            Text = "Employee";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_job;
        private TextBox txt_name;
        private TextBox txt_salary;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbx_name;
        private Label label5;
        private Button Save;
        private Button Delete;
        private Button Edit;
        private TextBox src_name;
        private Label label6;
        private Button button4;
        private Button Enter;
        private PictureBox pic;
        private Button button1;
        private DataGridView dtg;
    }
}
