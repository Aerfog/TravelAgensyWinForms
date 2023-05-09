namespace TravelAgensyWinForms
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
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            checkBox1 = new CheckBox();
            listBox1 = new ListBox();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(818, 104);
            button1.Name = "button1";
            button1.Size = new Size(233, 29);
            button1.TabIndex = 0;
            button1.Text = "Зареєструвати замовлення";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(818, 139);
            button2.Name = "button2";
            button2.Size = new Size(233, 29);
            button2.TabIndex = 1;
            button2.Text = "Редагувати дані";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(818, 174);
            button3.Name = "button3";
            button3.Size = new Size(233, 29);
            button3.TabIndex = 2;
            button3.Text = "Видалити замовлення";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(818, 209);
            button4.Name = "button4";
            button4.Size = new Size(233, 29);
            button4.TabIndex = 3;
            button4.Text = "Обчислити вартість";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(818, 244);
            button5.Name = "button5";
            button5.Size = new Size(233, 29);
            button5.TabIndex = 4;
            button5.Text = "Переглянути гарячі тури";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(818, 279);
            button6.Name = "button6";
            button6.Size = new Size(233, 29);
            button6.TabIndex = 5;
            button6.Text = "Впорядкувати за ціною";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(818, 74);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(206, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "у зворотньому напрямку";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(12, 66);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(800, 284);
            listBox1.TabIndex = 7;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button7
            // 
            button7.Location = new Point(818, 314);
            button7.Name = "button7";
            button7.Size = new Size(233, 29);
            button7.TabIndex = 8;
            button7.Text = "Скинути";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 450);
            Controls.Add(button7);
            Controls.Add(listBox1);
            Controls.Add(checkBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Туристична агенція";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private CheckBox checkBox1;
        private ListBox listBox1;
        private Button button7;
    }
}