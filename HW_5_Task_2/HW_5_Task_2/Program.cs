using System;

/*Задание 2
Ранее в одном из практических заданий вы создавали класс «Магазин». Добавьте к уже созданному классу
информацию о площади магазина. Выполните перегрузку + (для увеличения площади магазина на указанную
величину), — (для уменьшения площади магазина на указанную величину), == (проверка на равенство площа-
дей магазинов), < и > (проверка на меньше или больше площади магазина), != и Equals. Используйте механизм
свойств для полей класса.*/

namespace HW_3_Task_5
{
    class Shop
    {
        string name;
        string address;
        string description;
        string contactNumber;
        string mail;
        double square;
        public Shop() { }
        public Shop(string name, string address, string description, string contactNumber, string mail, double square)
        {
            Name = name;
            Address = address;
            Description = description;
            Contact = contactNumber;
            Mail = mail;
            Square = square;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Contact
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public double Square
        {
            get { return square; }
            set
            {
                if (value >= 0)
                {
                    square = value;
                }
                else
                {
                    square = 0;
                }
            }
        }
        public void PrintData()
        {
            Console.WriteLine($"Название магазина: {name}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Контактный телефон :{contactNumber}");
            Console.WriteLine($"e-Mail: {mail}");
            Console.WriteLine($"Площадь магазина: {square}");
        }
        public static Shop operator +(Shop shop, double square)
        {
            shop.Square += square;
            return shop;
        }
        public static Shop operator -(Shop shop, double square)
        {
            shop.Square -= square;
            return shop;
        }
        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public static bool operator ==(Shop shop, double square)
        {
            return shop.Square.Equals(square);
        }
        public static bool operator !=(Shop shop, double square)
        {
            return !(shop.Square.Equals(square));
        }
        public static bool operator <(Shop shop, double square)
        {
            return shop.Square < square;
        }
        public static bool operator >(Shop shop, double square)
        {
            return shop.Square > square;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop("name", "адрес", "description", "22-22-22", "@mail.fu", 100.5);
            shop.PrintData();
            shop.Name = "name shop".ToUpper();
            shop.Address = "адрес".ToUpper();
            shop.Description = "description shop".ToUpper();
            shop.Contact = "55-55-55";
            shop.Mail = "shop@mail.com".ToUpper();
            shop += 2.6;
            shop -= 50.92;
            Console.WriteLine();
            shop.PrintData();
            Console.WriteLine();
            Console.WriteLine($"shop.square == 100 {shop == 100}"); // false
            Console.WriteLine($"shop.square != 100 {shop != 100}"); // true
            Console.WriteLine($"shop.square > 100 {shop > 100}"); // false
            Console.WriteLine($"shop.square < 60 {shop < 60}"); // true
        }
    }
}

