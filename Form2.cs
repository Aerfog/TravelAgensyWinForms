using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgensyWinForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //при натисканні кнопки "зареєструвати" перевіряє введені дані та викликає метод для створення туру з необхідними аргументами
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("") || textBox9.Text.Equals("") || textBox10.Text.Equals("")) { MessageBox.Show("Неправильні значення"); return; }
            if (textBox3.Text.Equals(""))
            {
                if (Commands.CreateTour(string.Format("{0} {1} {2:dd-MM-yy} {3} {4} {5:dd-MM-yy} {6:dd-MM-yy} {7} {8}", textBox1.Text, textBox2.Text, dateTimePicker1.Value, textBox4.Text, textBox5.Text, dateTimePicker2.Value, dateTimePicker3.Value, textBox9.Text, textBox10.Text))) { Commands.WriteFile(); }
            }
            else
            {
                if (Commands.CreateTour(string.Format("{0} {1} {2:dd-MM-yy} {3} {4} {5:dd-MM-yy} {6:dd-MM-yy} {7} {8} {9}", textBox1.Text, textBox2.Text, dateTimePicker1.Value, textBox4.Text, textBox5.Text, dateTimePicker2.Value, dateTimePicker3.Value, textBox9.Text, textBox10.Text, textBox3.Text))) Commands.WriteFile();
            }
            Close();
        }
    }
}
