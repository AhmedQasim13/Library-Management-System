using System.Collections.Generic;
using System.Reflection;

namespace Library_Management_System
{
    class Library
    {
        public List<Book> books { set; get;}
        public Library()
        {
            this.books = new List<Book>();
        }
        //Add Method
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"The book with the title {book.Title} \t is Added succcessfully.\n");
        }
        //Search Method
        public void Search(string search)
        {
            bool isFound = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (search == books[i].Title || search == books[i].Author )
                {
                    isFound = true;
                    Console.WriteLine($"I found the book and the the details is: \nthe Title is: {books[i].Title} . \nthe Author is: {books[i].Author} .\nthe ISBN is {books[i].ISBN}\nthe Availability is {books[i].Availability} \n");
                    break;
                }
                else
                {
                    isFound = false;
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{search}  cannot be determined \n");
            }

        }
        //Borrow Method
        public void BorrowBook(string borrow)
        {
            bool isFound = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Availability == true && borrow == books[i].Title)
                {
                    isFound = true;
                    Console.WriteLine($"Congrats you borrow the book {borrow} the details is: \nthe Title is: {books[i].Title} . \nthe Author is: {books[i].Author} .\nthe ISBN is {books[i].ISBN}.\n ");
                    books[i].Availability = false;
                    break;
                }
                else
                {
                    isFound = false;
                }
            }
            if (isFound==false)
            {
                Console.WriteLine($"The book {borrow} not found in the library\n");
            }
            //
            //using Contains
            //for (int i = 0; i < books.Count; i++)
            //{
            //    if (books[i].Title.Contains(borrow) && books[i].Availability == true)
            //    {
            //        isFound = true;
            //        Console.WriteLine($"Congrats you borrow the book {borrow} the details is: \nthe Title is: {books[i].Title} . \nthe Author is: {books[i].Author} .\nthe ISBN is {books[i].ISBN}.\n ");
            //        books[i].Availability = false;
            //        break;
            //    }
            //    else
            //    {
            //        isFound = false;
            //    }
            //}
            //if (isFound == false)
            //{
            //    Console.WriteLine($"The book {borrow} not found");
            //}
        }
        //Return Method
        public void ReturnBook(string ReturnedBook)
        {
            bool isFound = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (ReturnedBook == books[i].Title && books[i].Availability == false)
                {
                    isFound=true;
                    Console.WriteLine($"Thanks the book {books[i].Title} is returned \n");
                    books[i].Availability = true;
                    break;
                }
                else 
                {
                    isFound = false;
                }
            }
            if (isFound == false)
            {
                    Console.WriteLine($"the book {ReturnedBook} not borrowed \n");

            }
        }

    }
    class Book
    {
        #region Setter & Getter
        //string Title;
        //string Author;
        //int ISBN;
        //bool Availability;
        //
        ////title
        //public void SetTitle(string title) {this.Title = title;}
        //public string GetTitle() {return this.Title;}
        ////Author
        //public void SetAuthor(string author) {this.Author = author;}
        //public string GetAuthor() {return this.Author;}
        ////ISBN
        //public void SetISBN(int isbn) { this.ISBN = isbn;} 
        //public int  GetISBN() {return this.ISBN;}
        ////Availability
        //public void SetAvailability(bool available) { this.Availability = available;}
        //public bool GetAvailability() {return this.Availability;}
        //

        #endregion

        //Auto Prop
        public String Title { get; set; }
        public String Author { get; set; }
        public String ISBN { get; set; }
        public bool Availability { get; set; }
        public Book(string title ="none", string author = "none", string iSBN="none")
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            this.Availability = true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            //Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("Space X", "Elon Musk", "9780781273561"));
            library.AddBook(new Book("who I Am", "Qasim", "98443273565"));
            library.AddBook(new Book("QQ", "Maro", "9780743273565123"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            //search books
            library.Search("The Great Gatsby");
            library.Search("Harry Potter");
            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            //// Returning books
            //Console.WriteLine("\nReturning books...");
            //
            library.ReturnBook("The Great Gatsby");
            //
            library.BorrowBook("The Great Gatsby");

            library.Search("The Great Gatsby");


            library.ReturnBook("Harry Potter"); // This book is not borrowed

            //
            // display All books
            //for (int i = 0; i < library.books.Count; i++)
            //{
            //    Console.WriteLine($"the Title is: {library.books[i].Title}\t || the Author is: {library.books[i].Author}\t ||the ISBN is {library.books[i].ISBN}");
            //}
        }
    }
}
