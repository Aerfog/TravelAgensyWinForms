namespace TravelAgensyWinForms
{
    public partial class Form1 : Form
    {
        public static Tour currentTour = null;
        public bool isReversed = false;
        public Form1()
        {
            InitializeComponent();
            Commands.ReadFile(); //зчитує дані з файлу та заповнює словник замовленнями
            FillListBox(Commands.tours.Values);//заповнює листбокс даними зі словника
        }

        //заповнює листбокс даними з переданого IEnumerable<Tour>
        private void FillListBox(IEnumerable<Tour> keyValuePairs)
        {
            listBox1.Items.Clear();
            if (!isReversed)
            {
                foreach (var item in keyValuePairs)
                    listBox1.Items.Add(item.FormatTextForConsole());
            }
            else foreach (var item in keyValuePairs.Reverse())
                    listBox1.Items.Add(item.FormatTextForConsole());
        }

        //викликає форму 2 для реєстрації нового замовлення, після цього вписує зміни до файлу та оновлює дані у листбоксі
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            Commands.WriteFile();
            FillListBox(Commands.tours.Values);
        }

        //при натисканні на окреме замовлення у листбоксі обирає його для подальших дій
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTour = null;
            var item = listBox1.SelectedItem as string;
            if (item != null)
            {
                var data = item.Split(" ");
                var code = Convert.ToUInt32(data[0]);
                currentTour = Commands.tours[code];
            }
        }

        //викликає форму 3 для зміни даних замовлення, після цього вписує зміни до файлу та оновлює дані у листбоксі
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentTour == null) { MessageBox.Show("Елемент не було обрано!"); return; }
            new Form3().ShowDialog();
            FillListBox(Commands.tours.Values);
            Commands.WriteFile();
            currentTour = null;
        }

        //обирає у якому порядку буде виведено дані у листбокс
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isReversed = !isReversed;
            FillListBox(Commands.tours.Values);
        }

        //викликає метод для видалення обраного замовлення, після цього вписує зміни до файлу та оновлює дані у листбоксі
        private void button3_Click(object sender, EventArgs e)
        {
            if (currentTour == null) { MessageBox.Show("Елемент не було обрано!"); return; }
            Commands.DeleteOrder(currentTour.OrderCode);
            Commands.WriteFile();
            FillListBox(Commands.tours.Values);
            currentTour = null;
        }

        //викликає метод для обчислення вартості обраного замовлення, виводить вартість на екран
        private void button4_Click(object sender, EventArgs e)
        {
            if (currentTour == null) { MessageBox.Show("Елемент не було обрано!"); return; }
            Commands.CalculateCost(currentTour.OrderCode);
        }

        //заповнює листбокс гарячими турами
        private void button5_Click(object sender, EventArgs e)
        {
            FillListBox(Commands.ViewHotTours());
        }

        //заповнює листбокс відсортованими за вартістю 1 путівки замовленнями
        private void button6_Click(object sender, EventArgs e)
        {
            FillListBox(Commands.SortByCost());
        }

        //очищує листбокс та заповнює його даними зі словника
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FillListBox(Commands.tours.Values);
        }
    }
}