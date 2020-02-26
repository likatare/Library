using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryRepository;
using LibraryRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace LibraryWebbApp.Controllers
{
    public class BooksController : Controller
    {
        /// <summary>
        /// Gets a list of books
        /// </summary>
        /// <returns>A list of books</returns>
        public ActionResult Index()
        {
            List<Book> books = BookRepository.GetBooks();

            return View(books);
        }

        /// <summary>
        /// Get a bookid from database
        /// </summary>
        /// <param name="id">id of a book</param>
        /// <returns>View of a book</returns>
        public ActionResult Details(string id)
        {
            ObjectId bookId = new ObjectId(id);
            Book book = BookRepository.GetBookById(bookId);

            return View(book);
        }

        /// <summary>
        /// Creates a create form.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }

       /// <summary>
       /// Saves a Book in the database.
       /// </summary>
       /// <param name="book">book of book</param>
       /// <returns>A View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                BookRepository.SaveBook(book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Create a form to edit a book.
        /// </summary>
        /// <param name="id">id of book</param>
        /// <returns>View</returns>
        public ActionResult Edit(string id)
        {
            ObjectId bookId = new ObjectId(id);

            Book book = BookRepository.GetBookById(bookId);

            return View(book);
        }

        /// <summary>
        /// Lets user update a book in the database
        /// </summary>
        /// <param name="id">id of book</param>
        /// <param name="book">Book of book</param>
        /// <returns>Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Book book)
        {
            try
            {
                ObjectId bookId = new ObjectId(id);

                BookRepository.UpdateBookById(bookId,book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Gets a book by id from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View </returns>
        public ActionResult Delete(string id)
        {
            ObjectId bookId = new ObjectId(id);

            Book book = BookRepository.GetBookById(bookId);

            return View(book);
        }

        /// <summary>
        /// Deletes a book from the database.
        /// </summary>
        /// <param name="id">id of the book</param>
        /// <param name="collection"></param>
        /// <returns>index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                ObjectId bookId = new ObjectId(id);

                BookRepository.DeleteBookById(bookId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}