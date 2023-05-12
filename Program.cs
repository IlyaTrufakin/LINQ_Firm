using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Реалізуйте користувацький тип «Фірма». В ньому має бути інформація про назву фірми, дату заснування,
//профіль бізнесу (маркетинг, IT, і т. д.), ПІБ директора, кількість працівників, адреса.
//Для масиву фірм реалізуйте такі запити:
// Отримати інформацію про всі фірми.
// Отримати фірми, які мають у назві слово «Food».
// Отримати фірми, які працюють у галузі маркетингу.
// Отримати фірми, які працюють у галузі маркетингу або IT.
// Отримати фірми з кількістю працівників більшою, ніж 100.
// Отримати фірми з кількістю працівників у діапазоні від 100 до 300.
// Отримати фірми, які знаходяться в Лондоні.
// Отримати фірми, в яких прізвище директора White.
// Отримати фірми, які засновані більше двох років тому.
// Отримати фірми з дня заснування яких минуло 123 дні.
// Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White». 


namespace Firm
{

    class Firm
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string BusinessActivity { get; set; }
        public string DirectorLastName { get; set; }
        public string DirectorFirstName { get; set; }
        public int Employees { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        public Firm(string _name, string _date, string _businessActivity, string _directorLastName, string _directorFirstName, int _employees, string _country, string _address)
        {
            this.Name = _name;
            this.Date = DateTime.Parse(_date);
            this.BusinessActivity = _businessActivity;
            this.DirectorLastName = _directorLastName;
            this.DirectorFirstName = _directorFirstName;
            this.Employees = _employees;
            this.Country = _country;
            this.Address = _address;
        }

        public void Print()
        {
            Console.WriteLine("_________________________________________");
            Console.WriteLine($"Firm: {this.Name}");
            Console.WriteLine($"Address: {this.Country} - {this.Address}");
            Console.WriteLine($"Date of foundation: {this.Date:dd-MM-yyyy}");
            Console.WriteLine($"Business activity: {this.BusinessActivity}");
            Console.WriteLine($"Director: {this.DirectorLastName}  {this.DirectorFirstName}");
            Console.WriteLine($"Employees: {this.Employees}");
        }


        ~Firm() { }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Firm> firms = new List<Firm>
            {
                new Firm("Ford", "11-10-1945", "Automotive industry", "Ford", "Henry", 30010, "USA",  "1 One American Road"),
                new Firm("Mitsui", "01-04-1907", "Marketing", "Tatsuo", "Yasunaga", 100, "Japan" , "Otemachi 1-chome"),
                new Firm("White star FOOD", "17-12-1987", "woodworking industry", "White", "Khan", 87, "London", " 1 St. Martin's Le Grand"),
                new Firm("IBM", "25-08-1965", "IT", "Krishna", "Arvind", 168000, "USA", "1 New Orchard Road"),
                new Firm("White food", "25-03-2023", "Food industry", "Black", "Ignacio", 301, "Spain", "Santa Hortensia 26-28")
            };

            // Отримати інформацію про всі фірми.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var all = from x in firms select x;
            Console.WriteLine("All firms: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in all) x.Print();

            // Отримати фірми, які мають у назві слово «Food».
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var NameHasFood = from firm in firms
                              where firm.Name.ToLower().Contains("food")
                              select firm;
            Console.WriteLine("Firms with the word \"food\" in the name: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in NameHasFood) x.Print();


            // Отримати фірми, які працюють у галузі маркетингу.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var MarketingFirms = from firm in firms
                              where firm.BusinessActivity.ToLower().Contains("marketing")
                              select firm;
            Console.WriteLine("Marketing firms: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in MarketingFirms) x.Print();



            // Отримати фірми, які працюють у галузі маркетингу або IT.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var MarketingAndITFirms = from firm in firms
                                 where firm.BusinessActivity.ToLower().Contains("marketing") || firm.BusinessActivity.ToLower().Contains("it")
                                 select firm;
            Console.WriteLine("Marketing or IT firms: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in MarketingAndITFirms) x.Print();

            // Отримати фірми з кількістю працівників більшою, ніж 100.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var More100Workers = from firm in firms
                                      where firm.Employees>100
                                      select firm;
            Console.WriteLine("Firms with more than 100 employees: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in More100Workers) x.Print();


            // Отримати фірми з кількістю працівників у діапазоні від 100 до 300.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var Beetwen100And300Workers = from firm in firms
                                 where firm.Employees >= 100 && firm.Employees <=300
                                 select firm;
            Console.WriteLine("Firms with 100 to 300 employees: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in Beetwen100And300Workers) x.Print();

            // Отримати фірми, які знаходяться в Лондоні.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var FirmsFromLondon = from firm in firms
                                      where firm.Country.ToLower().Contains("london")
                                      select firm;
            Console.WriteLine("Firms from London: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in FirmsFromLondon) x.Print();

            // Отримати фірми, в яких прізвище директора White.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var LastName_White = from firm in firms
                                  where firm.DirectorLastName.ToLower().Contains("white")
                                  select firm;
            Console.WriteLine("Firms in which the director's lastname is White: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in LastName_White) x.Print();


            // Отримати фірми, які засновані більше двох років тому.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var founded_2_Years_Ago = from firm in firms
                                 where firm.Date < DateTime.Now.AddYears(-2)
                                 select firm;
            Console.WriteLine("Firms that were founded more than two years ago: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in founded_2_Years_Ago) x.Print();


            // Отримати фірми з дня заснування яких минуло 123 дні.
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var founded_123_Days_Ago = from firm in firms
                                      where firm.Date < DateTime.Now.AddDays(-123)
                                      select firm;
            Console.WriteLine("Firms that were founded more than 123 days ago: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in founded_123_Days_Ago) x.Print();

            // Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White».
            Console.WriteLine("\n-----------------------------------------------------------------------------------");
            var LastName_Black_FirmName_White = from firm in firms
                                 where firm.DirectorLastName.ToLower().Contains("black") && firm.Name.ToLower().Contains("white")
                                 select firm;
            Console.WriteLine("Firms in which the director's last name is Black and have the word \"White\" in the name of the firm: ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var x in LastName_Black_FirmName_White) x.Print();

        }

    }
}
