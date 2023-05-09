namespace TravelAgensyWinForms
{
    partial class Form3
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
            comboBox1 = new ComboBox();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Код замовлення", "ПІБ замовника", "Дата замовлення", "Назва туру ", "Країна", "Дата від'їзду", "Дата приїзду", "Кількість путівок", "Вартість 1 путівки", "Знижка" });
            comboBox1.Location = new Point(12, 62);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(123, 109);
            button1.Name = "button1";
            button1.Size = new Size(146, 51);
            button1.TabIndex = 1;
            button1.Text = "Змінити";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(179, 63);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(202, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 27);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 4;
            label1.Text = "Дані для зміни";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 39);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 5;
            label2.Text = "Нове значення";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 192);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Name = "Form3";
            Text = "Змінити дані";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
    }
}