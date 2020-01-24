using System;
using LibraryRepository.Models;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository
{
    public class BookRepository
    {
        /// <summary>
        /// Saves a book to the database
        /// </summary>
        /// <param name="book">Book of book</param>
        public static void SaveBook(Book book)
        {
            Database db = new Database();

            db.SaveBook(book);
        }

        /// <summary>
        /// Gets a list of books from the database
        /// </summary>
        /// <returns>A list of books</returns>
        public static List<Book> GetBooks()
        {
            Database db = new Database();

           return db.GetBooks();
        }

        /// <summary>
        /// Updates a book to the database
        /// </summary>
        /// <param name="book">Book of book</param>
        public static void UpdateBookById(Book book)
        {
            Database db = new Database();

            db.UpdateBookById(book);
        }

        /// <summary>
        /// Deletes a book to the database
        /// </summary>
        /// <param name="book">Book of book</param>
        public static void DeleteBookById(Book book)
        {
            Database db = new Database();

            db.DeleteBookById(book.Id);
        }

    }
}
