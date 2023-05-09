namespace TravelAgensyWinForms
{
    public partial class Form1 : Form
    {
        public static Tour currentTour = null;
        public bool isReversed = false;
        public Form1()
        {
            InitializeComponent();
            Commands.ReadFile(); //����� ��� � ����� �� �������� ������� ������������
            FillListBox(Commands.tours.Values);//�������� �������� ������ � ��������
        }

        //�������� �������� ������ � ���������� IEnumerable<Tour>
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

        //������� ����� 2 ��� ��������� ������ ����������, ���� ����� ����� ���� �� ����� �� ������� ��� � ��������
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            Commands.WriteFile();
            FillListBox(Commands.tours.Values);
        }

        //��� ��������� �� ������ ���������� � �������� ����� ���� ��� ��������� ��
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

        //������� ����� 3 ��� ���� ����� ����������, ���� ����� ����� ���� �� ����� �� ������� ��� � ��������
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentTour == null) { MessageBox.Show("������� �� ���� ������!"); return; }
            new Form3().ShowDialog();
            FillListBox(Commands.tours.Values);
            Commands.WriteFile();
            currentTour = null;
        }

        //����� � ����� ������� ���� �������� ��� � ��������
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isReversed = !isReversed;
            FillListBox(Commands.tours.Values);
        }

        //������� ����� ��� ��������� �������� ����������, ���� ����� ����� ���� �� ����� �� ������� ��� � ��������
        private void button3_Click(object sender, EventArgs e)
        {
            if (currentTour == null) { MessageBox.Show("������� �� ���� ������!"); return; }
            Commands.DeleteOrder(currentTour.OrderCode);
            Commands.WriteFile();
            FillListBox(Commands.tours.Values);
            currentTour = null;
        }

        //������� ����� ��� ���������� ������� �������� ����������, �������� ������� �� �����
        private void button4_Click(object sender, EventArgs e)
        {
            if (currentTour == null) { MessageBox.Show("������� �� ���� ������!"); return; }
            Commands.CalculateCost(currentTour.OrderCode);
        }

        //�������� �������� �������� ������
        private void button5_Click(object sender, EventArgs e)
        {
            FillListBox(Commands.ViewHotTours());
        }

        //�������� �������� ������������� �� ������� 1 ������ ������������
        private void button6_Click(object sender, EventArgs e)
        {
            FillListBox(Commands.SortByCost());
        }

        //����� �������� �� �������� ���� ������ � ��������
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FillListBox(Commands.tours.Values);
        }
    }
}