using System;
using LibraryRepository.Models;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

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
        /// Gets a book by id
        /// </summary>
        /// <param name="bookId">id of the book</param>
        /// <returns>A book</returns>
        public static Book GetBookById(ObjectId bookId)
        {
            Database db = new Database();
            return db.GetBookById(bookId);

        }

        /// <summary>
        /// Updates a book to the database
        /// </summary>
        /// <param name="book">Book of book</param>
        public static void UpdateBookById(ObjectId id,Book book)
        {
            Database db = new Database();

            db.UpdateBookById(id,book);
        }

        /// <summary>
        /// Deletes a book in the database
        /// </summary>
        /// <param name="book">Book of book</param>
        public static void DeleteBookById(ObjectId id)
        {
            Database db = new Database();

            db.DeleteBookById(id);
        }

    }
}
