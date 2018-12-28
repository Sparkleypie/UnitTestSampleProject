using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestSampleProject.Model;

namespace UnitTestSampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1 - Add a person");
                Console.WriteLine("2 - Add a book");
                Console.WriteLine("3 - Place an order");
                Console.WriteLine("4 - List Persons");
                Console.WriteLine("5 - List Books");
                Console.WriteLine("E - Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "2":
                        AddBook();
                        break;
                    case "3":
                        PlaceOrder();
                        break;
                    case "4":
                        ListPersons();
                        break;
                    case "5":
                        ListBooks();
                        break;
                    case "E":
                    case "e":
                        Console.WriteLine("ok doei");
                        return;
                    default:
                        break;
                }
            }
        }

        public static void ListPersons()
        {
            using (var uitleenContext = new UitleenContext())
            {
                var allPersons = uitleenContext.Persons;

                foreach (var person in allPersons)
                {
                    Console.WriteLine($"{person.Id}: {person.FirstName} + {person.LastName}, {person.BirthDate}");
                }
            }
        }

        public static void ListBooks()
        {

            using (var uitleenContext = new UitleenContext())
            {
                var allBooks = uitleenContext.Books;

                foreach (var book in allBooks)
                {
                    Console.WriteLine($"{book.Id}: {book.Title} + {book.IsComic}, {book.Genre}, {book.DateOfPublication}");
                }
            }
        }

        public static void AddPerson()
        {
            using (var uitleenContext = new UitleenContext())
            {
                var person = new Person();

                Console.WriteLine("What is your first name?");
                string firstName = Console.ReadLine();
                Console.WriteLine("And your surname?");
                string lastName = Console.ReadLine();

                DateTime birthDay = DateTime.Now.AddYears(-18);

                person.FirstName = firstName;
                person.LastName = lastName;
                person.BirthDate = birthDay;

                uitleenContext.Persons.Add(person);
                uitleenContext.SaveChanges();
            }
        }

        public static void AddBook()
        {
            using (var uitleenContext = new UitleenContext())
            {
                var book = new Book();

                Console.WriteLine("What is the book title?");
                string title = Console.ReadLine();

                Console.WriteLine("What is the genre?");
                string genre = Console.ReadLine();

                Console.WriteLine("Is it a comic? Y/N");
                string isComic = Console.ReadLine();
                if (isComic == "Y" || isComic == "y")
                {
                    Console.WriteLine("So it's a comic");
                    book.IsComic = true;
                }
                else
                {
                    Console.WriteLine("So it's not a comic");
                }

                DateTime dateOfPublication = DateTime.Now.AddDays(-100);

                book.Title = title;
                book.Genre = genre;
                book.DateOfPublication = dateOfPublication;
                //kusje voor jou <3
                uitleenContext.Books.Add(book);
                uitleenContext.SaveChanges();
            }

        }

        public static void PlaceOrder()
        {
            using (var uitleenContext = new UitleenContext())
            {
                var order = new Order();

                Console.WriteLine("Hello, who are you?");
                ListPersons();

                var selectedPersonId = Convert.ToInt32(Console.ReadLine());

                var person = uitleenContext.Persons.Where(x => x.Id == selectedPersonId).First();

                Console.WriteLine($"Hi {person.FirstName}, what books do you want to order? Please seperate them by a ,");

                ListBooks();
                var selectedBooksString = Console.ReadLine();

                var selectedBooksSplitted = selectedBooksString.Split(',');
          
                order.Books = new List<Book>();
                foreach (var bookIdString in selectedBooksSplitted)
                {
                    var number = Convert.ToInt32(bookIdString);
                    var book = uitleenContext.Books.Where(x => x.Id == number).First();
                    order.Books.Add(book);
                }

                order.Person = person;
                order.OrderNumber = new Random().Next(10000);
                order.ExpectedDeliveryDate = DateTime.Now.AddDays(19);

                uitleenContext.Orders.Add(order);
                uitleenContext.SaveChanges();
            }
        }
    }
}
