namespace Shellworks_Installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            openFileDialog1 = new OpenFileDialog();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            label4 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(86, 253);
            label1.Name = "label1";
            label1.Size = new Size(319, 29);
            label1.TabIndex = 1;
            label1.Text = "SHELLWORKS INSTALLER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Sans", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(55, 337);
            label2.Name = "label2";
            label2.Size = new Size(375, 23);
            label2.TabIndex = 2;
            label2.Text = "WILL YOU SNAIL INSTALL DIRECTORY:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 363);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(366, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(62, 389);
            button1.Name = "button1";
            button1.Size = new Size(193, 27);
            button1.TabIndex = 4;
            button1.Text = "Select";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(253, 389);
            button2.Name = "button2";
            button2.Size = new Size(175, 27);
            button2.TabIndex = 5;
            button2.Text = "Auto-Detect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(163, 432);
            button3.Name = "button3";
            button3.Size = new Size(175, 45);
            button3.TabIndex = 6;
            button3.Text = "INSTALL";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(163, 483);
            button4.Name = "button4";
            button4.Size = new Size(175, 31);
            button4.TabIndex = 7;
            button4.Text = "UNINSTALL";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "WYS Executable|Will You Snail.exe";
            // 
            // label3
            // 
            label3.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(12, 284);
            label3.Name = "label3";
            label3.Size = new Size(458, 53);
            label3.TabIndex = 8;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.Location = new Point(232, 124);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(236, 40);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Dotnet 6 runtime";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(234, 164);
            label5.Name = "label5";
            label5.Size = new Size(185, 30);
            label5.TabIndex = 11;
            label5.Text = "if you haven't yet!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(234, 99);
            label4.Name = "label4";
            label4.Size = new Size(226, 30);
            label4.TabIndex = 10;
            label4.Text = "Also install Microsoft's\r\n";
            label4.Click += label4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Control;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Brown;
            label6.Location = new Point(234, 53);
            label6.Name = "label6";
            label6.Size = new Size(214, 46);
            label6.TabIndex = 12;
            label6.Text = "IMPORTANT!";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Control;
            ClientSize = new Size(482, 526);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(linkLabel1);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private OpenFileDialog openFileDialog1;
        private Label label3;
        private LinkLabel linkLabel1;
        private Label label5;
        private Label label4;
        private Label label6;
    }
}
