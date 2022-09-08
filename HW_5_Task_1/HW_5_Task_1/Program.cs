using System;

/*Задание 1
Ранее в одном из практических заданий вы создавали класс «Журнал». Добавьте к уже созданному классу информацию о количестве сотрудников.
Выполните перегрузку + (для увеличения количества сотрудников на указанную величину), — (для уменьшения количества сотрудников
на указанную величину), == (проверка на равенство количества сотрудников), < и > (проверка на меньше или
больше количества сотрудников), != и Equals. Используйте механизм свойств для полей класса.*/

namespace HW_5_Task_1
{
    class Journal
    {
        string name; // название
        DateTime yearOfFoundation; // год основания
        string description; // описание
        string contactNumber; // телефон
        string mail; // e-mail
        int numberEmployees; // количество сотрудников
        public Journal() { }
        public Journal(string name, DateTime yearOfFoundation, string description,
            string contactNumber, string mail, int numberEmployees)
        {
            this.name = name;
            this.yearOfFoundation = yearOfFoundation;
            this.description = description;
            this.contactNumber = contactNumber;
            this.mail = mail;
            this.numberEmployees = numberEmployees;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime Year
        {
            get { return yearOfFoundation; }
            set { yearOfFoundation = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Employee
        {
            get { return numberEmployees; }
            set { numberEmployees = value; }
        }
        public void PrintData()
        {
            Console.WriteLine($"Название журнала: {name}");
            Console.WriteLine($"Год основания: {yearOfFoundation.Year}");
            Console.WriteLine($"Контактный телефон :{contactNumber}");
            Console.WriteLine($"e-Mail: {mail}");
            Console.WriteLine($"Количество сотрудников: {numberEmployees}");
        }
        public static Journal operator +(Journal journal, int employees)
        {
            journal.Employee += employees;
            return journal;
        }
        public static Journal operator -(Journal journal, int employees)
        {
            journal.Employee -= employees;
            return journal;
        }
        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public static bool operator ==(Journal journal, int employees)
        {
            //return journal.Employee == employees;
            return journal.Employee.Equals(employees);
        }
        public static bool operator !=(Journal journal, int employees)
        {
            //return journal.Employee != employees;
            return !(journal.Employee.Equals(employees));
        }
        public static bool operator >(Journal journal, int employees)
        {
            return journal.Employee > employees;
        }
        public static bool operator <(Journal journal, int employees)
        {
            return journal.Employee < employees;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal("name", new DateTime(2000, 02, 04), "description", "22-22-22", "mail@.fu", 10);
            journal.PrintData();
            journal.Name = "name journal";
            journal.Year = new DateTime(1990, 03, 03);
            journal.Description = "description journal";
            journal += 100;
            Console.WriteLine();
            journal.PrintData();
            Console.WriteLine($"journal.employees == 110: {journal == 110}"); // true
            journal -= 50;
            Console.WriteLine();
            journal.PrintData();
            Console.WriteLine($"journal.employees != 60: {journal != 60}"); // false
            Console.WriteLine($"journal.employees < 65: {journal < 65}"); // true
            Console.WriteLine($"journal.employees > 70: {journal > 70}"); // false
        }
    }
}