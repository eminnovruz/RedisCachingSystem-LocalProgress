namespace WindowsForm
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
            listBox1 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox2 = new ComboBox();
            label2 = new Label();
            checkBox1 = new CheckBox();
            listBox2 = new ListBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(247, 52);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(480, 604);
            listBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 613);
            button1.Name = "button1";
            button1.Size = new Size(229, 43);
            button1.TabIndex = 2;
            button1.Text = "Get All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 564);
            button2.Name = "button2";
            button2.Size = new Size(229, 43);
            button2.TabIndex = 3;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(434, 9);
            label1.Name = "label1";
            label1.Size = new Size(220, 28);
            label1.TabIndex = 4;
            label1.Text = "Search Query Caching";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(229, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 98);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(229, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 142);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(229, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 184);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(229, 27);
            textBox4.TabIndex = 8;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 229);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(229, 28);
            comboBox2.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 529);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 10;
            label2.Text = "Users";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(223, 539);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 11;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            listBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox2.ForeColor = Color.Red;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 28;
            listBox2.Location = new Point(741, 52);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(480, 592);
            listBox2.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(987, 9);
            label3.Name = "label3";
            label3.Size = new Size(46, 28);
            label3.TabIndex = 13;
            label3.Text = "Log";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 682);
            Controls.Add(label3);
            Controls.Add(listBox2);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox2;
        private Label label2;
        private CheckBox checkBox1;
        private ListBox listBox2;
        private Label label3;
    }
}
