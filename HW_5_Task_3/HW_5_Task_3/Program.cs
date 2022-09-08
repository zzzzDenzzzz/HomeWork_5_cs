using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Задание 3
Создайте приложение «Список книг для прочтения». Приложение должно позволять добавлять книги в список,
удалять книги из списка, проверять есть ли книга в списке, и т. д. Используйте механизм свойств, перегрузки
операторов, индексаторов.*/

namespace HW_5_Task_3
{
    class Book : IComparable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Book()
        {
            Title = string.Empty;
            Author = string.Empty;
        }
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
        public void PrintBook() => Console.WriteLine($"Название книги: {Title}. Автор: {Author}.");

        public int CompareTo(object obj)
        {
            if (obj is Book book)
            {
                return Title.CompareTo(book.Title);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
    class Library
    {
        Book[] listBook;
        public Library()
        {
            listBook = new Book[] { };
        }
        public Library(int size)
        {
            listBook = new Book[size];
        }
        public int Length
        {
            get { return listBook.Length; }
        }
        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < listBook.Length)
                {
                    return listBook[index];
                }
                throw new IndexOutOfRangeException();
            }
            set { listBook[index] = value; }
        }
        public void PrintLibrary()
        {
            foreach (var item in listBook)
            {
                item.PrintBook();
            }
        }
        public void AddBook(Book book)
        {
            // Если есть пустая ячейка, записываем в нее книгу
            for (int i = 0; i < listBook.Length; i++)
            {
                if (listBook[i].Title == string.Empty && listBook[i].Author == string.Empty)
                {
                    listBook[i] = book;
                    return;
                }
            }
            // Если ячейки заняты, увеличиваем массив на 1 и записываем книгу в конец массива
            Array.Resize(ref listBook, listBook.Length + 1);
            listBook[listBook.Length - 1] = book;
        }
        public void AddBook(params Book[] library)
        {
            var tmp = new List<Book>(listBook);
            tmp.AddRange(library);
            listBook = tmp.ToArray();
        }
        public bool DeleteBook(Book book)
        {
            bool deleteBook = false;
            // для удаления элемента из массива, массива преобразуем в List
            var tmp = new List<Book>(listBook);

            for (int i = 0; i < listBook.Length; i++)
            {
                if (listBook[i].Title == book.Title && listBook[i].Author == book.Author)
                {
                    tmp.RemoveAt(i);
                    deleteBook = true;
                }
            }
            // list обратно в массив
            listBook = tmp.ToArray();
            return deleteBook;
        }
        // удаляет первый найденый элемент
        public bool DeleteBook(string title)
        {
            bool deleteBook = false;
            // для удаления элемента из массива, массива преобразуем в List
            var tmp = new List<Book>(listBook);

            for (int i = 0; i < listBook.Length; i++)
            {
                if (listBook[i].Title == title)
                {
                    tmp.RemoveAt(i);
                    deleteBook = true;
                }
            }
            // list обратно в массив
            listBook = tmp.ToArray();
            return deleteBook;
        }
        public bool IsThereBook(Book book)
        {
            for (int i = 0; i < listBook.Length; i++)
            {
                if (listBook[i].Title == book.Title && listBook[i].Author == book.Author)
                {
                    return true;
                }
            }
            return false;
        }
        public void SortLibrary()
        {
            Array.Sort(listBook);
        }
        public void HowManyBooks()
        {
            if (listBook.Length == 0)
            {
                Console.WriteLine($"В списке нет записей.");
                return;
            }
            string book = string.Empty;
            if (listBook.Length == 1 || listBook.Length == 21)
            {
                book = "книга";
            }
            else if (listBook.Length > 1 && listBook.Length < 5 || listBook.Length > 21)
            {
                book = "книги";
            }
            else
            {
                book = "книг";
            }
            Console.WriteLine($"В списке {listBook.Length} {book}.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //var library = new Library(2);
            //library[0] = new Book("title_1", "author_1");
            //library[1] = new Book("title_2", "author_2");
            var library = new Library();
            library.HowManyBooks();
            library.AddBook(new Book("title_1", "author_1"));
            library.AddBook(new Book());
            library.AddBook(new Book("title_2", "author_2"));
            library.AddBook(new Book("title_3", "author_3"));
            var book1 = new Book("title_1", "author_1");
            var book2 = new Book("title_4", "author_4");
            Console.WriteLine($"{book1.Title} {book1.Author} = {library.IsThereBook(book1)}"); // true
            Console.WriteLine($"{book2.Title} {book2.Author} = {library.IsThereBook(book2)}"); // false
            library.AddBook(book2);
            Console.WriteLine($"{book2.Title} {book2.Author} = {library.IsThereBook(book2)}"); // true
            library.PrintLibrary();
            if (library.DeleteBook(book1))
            {
                var book3 = new Book("title_1", "author_1");
                var book4 = new Book("title_1", "author_1");
                var book5 = new Book("title_5", "author_5");
                var book6 = new Book("title_6", "author_6");
                library.AddBook(book3, book4, book5, book6);
                library.DeleteBook(book2);
                Console.WriteLine();
                library.PrintLibrary();
                library.DeleteBook("title_1");
                //library.DeleteBook("title_6");
                Console.WriteLine();
                library.SortLibrary();
                library.PrintLibrary();
                Console.WriteLine();
                library.HowManyBooks();
            }
        }
    }
}
