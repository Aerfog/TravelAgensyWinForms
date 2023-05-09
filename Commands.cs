using System.Collections;
using System.ComponentModel.Design;
using System.Text;

namespace TravelAgensyWinForms
{
    internal class Commands
    {
        public static Dictionary<uint, Tour> tours = new Dictionary<uint, Tour>();

        //зчитує інформацію з файлу та по рядку передає методу CreateTour()
        public static void ReadFile()
        {
            string[] toursData = File.ReadAllLines("ToursBase.txt");
            foreach (string item in toursData)
                CreateTour(item);
        }

        //записує у StringBuilder дані зі словника, після цього переводить результат у рядок та перезаписує файл
        public static void WriteFile()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in tours.Values)
            {
                if (item is RegularTour regular)
                    stringBuilder.Append(regular.ToString());
                else if (item is HotTour hot)
                    stringBuilder.Append(hot.ToString());
            }
            File.WriteAllText("ToursBase.txt", stringBuilder.ToString());
        }

        //ділить рядок на частини та залежно від кількості цих частин створює замовлення та додає його до словника 
        public static bool CreateTour(string item)
        {
            try
            {
                string[] data = item.Split(' ');
                if (data.Length == 11)
                {
                    var tour = CreateRegularTours(data);
                    tours.Add(tour.OrderCode, tour);
                }
                else if (data.Length == 12)
                {
                    var tour = CreateHotTours(data);
                    tours.Add(tour.OrderCode, tour);
                }
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //отримує дані з GetTourValues та 12ї частини наданого рядка, на їх основі створює та повертає новий "гарячий" тур
        public static Tour CreateHotTours(string[] data)
        {
            try
            {
                var values = GetTourValues(data);
                double discount = Convert.ToDouble(data[11]) / 100;
                return new HotTour(values.OrderCode, values.CustomerName, values.OrderDate,
                                       values.TourName, values.Country, values.DepartureDate,
                                       values.ArrivalDate, values.VouchersNumbers, values.OneTicketCost, discount);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        //отримує дані з GetTourValues, на їх основі створює та повертає новий звичайний тур
        public static Tour CreateRegularTours(string[] data)
        {
            try
            {
                var values = GetTourValues(data);
                return new RegularTour(values.OrderCode, values.CustomerName, values.OrderDate,
                                       values.TourName, values.Country, values.DepartureDate,
                                       values.ArrivalDate, values.VouchersNumbers, values.OneTicketCost);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        //перетворює частини рядка на необхідні змінні та повертає їх
        public static (uint OrderCode, string CustomerName, DateTime OrderDate,
                       string TourName, string Country, DateTime DepartureDate,
                       DateTime ArrivalDate, uint VouchersNumbers, double OneTicketCost)
                       GetTourValues(string[] data)
        {

            try
            {
                uint OrderCode = Convert.ToUInt32(data[0]);
                string CustomerName = string.Format("{0} {1} {2}", data[1], data[2], data[3]);
                DateTime OrderDate = Convert.ToDateTime(data[4]);
                string TourName = data[5];
                string Country = data[6];
                DateTime DepartureDate = Convert.ToDateTime(data[7]);
                DateTime ArrivalDate = Convert.ToDateTime(data[8]);
                uint VouchersNumbers = Convert.ToUInt32(data[9]);
                double OneTicketCost = Convert.ToDouble(data[10]);
                return (OrderCode, CustomerName, OrderDate,
                        TourName, Country, DepartureDate,
                        ArrivalDate, VouchersNumbers, OneTicketCost);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //залежно від переданих аргументів змінює необхідну інформацію про замовлення на дані введені з форми, якщо заміна виконується успішно - виводить "Виконано!"
        public static bool SelectEdit(uint code, uint command, string stringValue)
        {
            switch (command)
            {
                case 0:
                    if (EditOrderCode(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 1:
                    if (EditCustomerName(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 2:
                    if (EditOrderDate(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 3:
                    if (EditTourName(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 4:
                    if (EditCountry(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 5:
                    if (EditDepartureData(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 6:
                    if (EditArrivalDate(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 7:
                    if (EditVouchersNumbers(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 8:
                    if (EditOneTicketCost(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
                case 9:
                    if (EditDiscount(code, stringValue)) { MessageBox.Show("Виконано!"); return true; }
                    break;
            }
            return false;
        }

        //змінює у замовленні дані про країну
        public static bool EditCountry(uint code, string newCountry)
        {
            try
            {
                if (newCountry == null) throw new Exception("Рядок порожній!");
                (tours[code] as Tour).Country = newCountry; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про знижку
        public static bool EditDiscount(uint code, string Value)
        {
            try
            {
                double newDiscount = Convert.ToDouble(Value);
                if (tours[code] is not HotTour) throw new Exception("Обраний тур не є \"гарячим\"!");
                (tours[code] as HotTour).Discount = newDiscount; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про вартість одного квитка
        public static bool EditOneTicketCost(uint code, string Value)
        {
            try
            {
                uint newOneTicketCost = Convert.ToUInt32(Value);
                (tours[code] as Tour).OneTicketCost = newOneTicketCost; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про кількість квитків
        public static bool EditVouchersNumbers(uint code, string Value)
        {
            try
            {
                uint newVouchersNumbers = Convert.ToUInt32(Value);
                (tours[code] as Tour).VouchersNumbers = newVouchersNumbers; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про дату приїзду
        public static bool EditArrivalDate(uint code, string Value)
        {
            try
            {
                DateTime newArrivalDate = Convert.ToDateTime(Value);
                (tours[code] as Tour).ArrivalDate = newArrivalDate; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про дату від'їзду
        public static bool EditDepartureData(uint code, string Value)
        {
            try
            {
                DateTime newDepartureDate = Convert.ToDateTime(Value);
                (tours[code] as Tour).DepartureDate = newDepartureDate; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про назву туру
        public static bool EditTourName(uint code, string newTourName)
        {
            try
            {
                if (newTourName == null) throw new Exception("Рядок порожній!");
                (tours[code] as Tour).TourName = newTourName; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про дату замовлення
        public static bool EditOrderDate(uint code, string Value)
        {
            try
            {
                DateTime newOrderDate = Convert.ToDateTime(Value);
                (tours[code] as Tour).OrderDate = newOrderDate; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про ПІБ замовника
        public static bool EditCustomerName(uint code, string newCustomerName)
        {
            try
            {
                if (newCustomerName == null) throw new Exception("Рядок порожній!");
                (tours[code] as Tour).CustomerName = newCustomerName; return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        //змінює у замовленні дані про код замовлення
        public static bool EditOrderCode(uint code, string Value)
        {
            try
            {
                uint newCode = Convert.ToUInt32(Value);
                if (!tours.ContainsKey(newCode))
                {
                    if (tours[code] is RegularTour regular)
                    {
                        tours.Remove(code); //видаляє зі словника замовлення з таким кодом
                        regular.OrderCode = newCode;// змінює код на новий
                        tours.Add(regular.OrderCode, regular); //додає до словника замовлення зі зміненним кодом за зміненним ключем
                    }
                    else if (tours[code] is HotTour hot)
                    {
                        tours.Remove(code);
                        hot.OrderCode = newCode;
                        tours.Add(hot.OrderCode, hot);
                    }
                    return true;
                }throw new Exception("Замовлення з таким кодом вже існує!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }


        //видаляє зі словника замовлення із заданим кодом  
        public static void DeleteOrder(uint code)
        {
            tours.Remove(code);
            Console.WriteLine("Виконано!");
        }

        //залежно від типу замовлення шукає його вартість та виводить на екран
        public static void CalculateCost(uint code)
        {
            if (tours[code] is RegularTour regular)
                MessageBox.Show(string.Format("{0:F2}", regular.CalculateCost()));
            else if (tours[code] is HotTour hot)
                MessageBox.Show(string.Format("{0:F2}", hot.CalculateCost()));
        }

        //шукає у словнику усі гарячі замовлення, додає їх у перелік та повертає його
        public static LinkedList<HotTour> ViewHotTours()
        {
            LinkedList<HotTour> hotTours = new LinkedList<HotTour>();
            foreach (var item in tours.Values)
            {
                if (item is HotTour hot)
                {
                    hotTours.AddLast(hot);
                }
            }
            if (hotTours.Count == 0)
            {
                MessageBox.Show("\"Гарячих\" турів не знайдено!");
            }
            return hotTours;
        }

        //додає усі замовлення зі словника у перелік, сортує його за допомогою класа Sorter, повертає цей відсортований перелік
        public static List<Tour> SortByCost()
        {
            List<Tour> costList = new List<Tour>();
            foreach (var item in tours.Values)
            {
                if (item is HotTour hot)
                    costList.Add(hot);
                else if (item is RegularTour regular)
                    costList.Add(regular);
            }
            if (costList.Count == 0)
            {
                MessageBox.Show("Турів не знайдено!");
            }
            costList.Sort(new Sorter());
            return costList;
        }
    }

    //клас що сортує замовлення за вартістю однієї путівки (від меньшої до більшої)
    public class Sorter : IComparer<Tour>
    {
        public int Compare(Tour? x, Tour? y)
        {
            if (x.OneTicketCost > y.OneTicketCost)
            {
                return 1;
            }
            else if (x.OneTicketCost == y.OneTicketCost)
            {
                return 0;
            }
            else return -1;
        }
    }
}