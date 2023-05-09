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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //при обиранні типу інформації на зміну робить доступним лише поле для вводу необхідних даних 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fs = comboBox1.SelectedItem as string;
            switch (fs)
            {
                case "Дата приїзду":
                case "Дата від'їзду":
                case "Дата замовлення":
                    textBox1.Visible = false;
                    dateTimePicker1.Visible = true;
                    break;
                default:
                    textBox1.Visible = true;
                    dateTimePicker1.Visible = false;
                    break;

            }
        }

        //при натисканні на кнопку "змінити" викликає метод для зміни даних з необхідними аргументами
        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.currentTour == null) return;
            if (textBox1.Visible)
                Commands.SelectEdit(Form1.currentTour.OrderCode, (uint)comboBox1.SelectedIndex, textBox1.Text);
            else
                Commands.SelectEdit(Form1.currentTour.OrderCode, (uint)comboBox1.SelectedIndex, string.Format("{0:dd-MM-yy}", dateTimePicker1.Value));
            Close();
        }
    }
}
