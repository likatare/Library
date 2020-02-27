using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryRepository;
using LibraryRepository.Models;
using LibraryWebbApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace LibraryWebbApp.Controllers
{
    public class LoansController : Controller
    {
        /// <summary>
        /// Gets all loans from database.
        /// </summary>
        /// <returns>view of loans</returns>
        public ActionResult Index()
        {
            List<Loan> loans = LoanRepository.GetLoans();

            return View(loans);
        }




        ///// <summary>
        ///// Gets all rents of a member by member id from db
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>View</returns>
        //public ActionResult MemberLoans(string id)
        //{
        //    ObjectId memberId = new ObjectId(id);
        //    List<Loan> loans = LoanRepository.GetLoanByMemberById(memberId);
        //    return View(loans);
        //}

        ///// <summary>
        ///// Gets a list of books by book id from db
        ///// </summary>
        ///// <param name="id">id of book</param>
        ///// <returns>View</returns>
        //[Route("/Loans/BookLoans/{id}")]
        //public ActionResult BookLoans(string id)
        //{
        //    ObjectId bookId = new ObjectId(id);
        //    Book book = BookRepository.GetBookById(bookId);
        //    List<Loan> rents = LoanRepository.GetAllLoanedBook(book);

        //    return View(rents);
        //}

        ///// <summary>
        ///// Gets a list of movies by movies id
        ///// </summary>
        ///// <param name="id">id of the movie</param>
        ///// <returns>view</returns>
        //[Route("/Loans/MovieLoans/{id}")]
        //public ActionResult MovieLoans(string id)
        //{
        //    ObjectId movieId = new ObjectId(id);
        //    Movie movie = MovieRepository.GetMovieById(movieId);
        //    List<Loan> loans = LoanRepository.GetAllLoanedMovie(movie);

        //    return View(loans);
        //}


        //[Route("/Loans/LoanBook/{id}")]
        //public ActionResult LoanBook(string id)
        //{
        //    List<Book> books = BookRepository.GetBooks();

        //    return View(books);
        //}



        // GET: Loans/Details/5
        public ActionResult Details(string id)
        {
            ObjectId loanId = new ObjectId(id);
            Loan loan = LoanRepository.GetLoanById(loanId);

            return View(loan);
        }

        // GET: Loans/Create
        public ActionResult Create()
        {

            ListModel viewModel = new ListModel();

            return View(viewModel);
        }

        // POST: Loans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string memberId, string bookId, string movieId, DateTime startDate, DateTime endDate)
        {
            ObjectId memberObjectId = new ObjectId(memberId);
            Member member = MemberRepository.GetMemberById(memberObjectId);


            try
            {


                if (movieId == "Empty")
                {
                    Book book = GetBook(bookId);
                    Loan loan = new Loan(startDate, endDate, member, book);
                    bool hasCopies = BookRepository.BookIsFreeToLoan(loan);

                    if (hasCopies)
                    {

                        LoanRepository.LoanBook(book, member, startDate, endDate);
                    }
                    else
                    {

                        ListModel viewModel = new ListModel();
                        viewModel.ErrorMessage = "Choose another date and is not available for loan";
                        return View(viewModel);
                    }

                }


                else if (bookId == "Empty")
                {

                    Movie movie = GetMovie(movieId);
                    Loan loan = new Loan(startDate, endDate, member, movie);
                    bool hasCopies = MovieRepository.MovieIsFreeToLoan(loan);

                    if (hasCopies)
                    {

                        LoanRepository.LoanMovie(movie, member, startDate, endDate);
                    }
                    else
                    {
                        ListModel listModel = new ListModel();
                        listModel.ErrorMessage = "Choose another date and is not available for loan";
                        return View(listModel);
                    }

                }

                else
                {

                    Book book = GetBook(bookId);
                    Movie movie = GetMovie(movieId);

                    Loan bookLoan = new Loan(startDate, endDate, member, book);
                    Loan movieLoan = new Loan(startDate, endDate, member, movie);

                    bool hasBookCopies = BookRepository.BookIsFreeToLoan(bookLoan);
                    bool hasMovieCopies = MovieRepository.MovieIsFreeToLoan(movieLoan);

                    if (hasBookCopies && hasMovieCopies)
                    {
                        LoanRepository.LoanBook(book, member, startDate, endDate);
                        LoanRepository.LoanMovie(movie, member, startDate, endDate);
                    }
                    else if (!hasBookCopies && !hasMovieCopies)
                    {
                        ListModel listModel = new ListModel();
                        listModel.ErrorMessage = "Both Movie and Book are unavaliable";

                        return View(listModel);
                    }
                    else if (!hasBookCopies)
                    {
                        ListModel listModel = new ListModel();
                        listModel.ErrorMessage = "Book is not avaliable";

                        return View(listModel);
                    }
                    else if (!hasMovieCopies)
                    {
                        ListModel listModel = new ListModel();
                        listModel.ErrorMessage = "Movie is not avaliable";

                        return View(listModel);

                    }

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(string id)
        {
            ObjectId loanId = new ObjectId(id);
            Loan loan = LoanRepository.GetLoanById(loanId);

            return View(loan);
        }

        // POST: Loans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, DateTime startDate,DateTime endDate)
        {
            try
            {
                ObjectId loanId = new ObjectId(id);
                Loan loan = LoanRepository.GetLoanById(loanId);


                if (loan.BookRented == null)
                {
                    LoanRepository.UpdateMovieLoanById(loan.MovieRented,loan,startDate,endDate );
                }
                else if (loan.MovieRented == null)
                {
                    LoanRepository.UpdateBookLoanById(loan.BookRented,loan,startDate,endDate);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(string id)
        {
            ObjectId loanId = new ObjectId(id);
            Loan loan = LoanRepository.GetLoanById(loanId);

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmedDelete(string id)
        {
            ObjectId loanId = new ObjectId(id);
            Loan loan = LoanRepository.GetLoanById(loanId);

            if (loan.MovieRented == null)
            {
                LoanRepository.DeleteBookLoanById(loan);
            }
            else if (loan.BookRented == null)
            {
                LoanRepository.DeleteMovieLoanById(loan);
            }


            return Redirect("/Loans");




        }

        private Book GetBook(string id)
        {
            ObjectId bookObjectId = new ObjectId(id);
            return BookRepository.GetBookById(bookObjectId);
        }

        private Movie GetMovie(string id)
        {
            ObjectId movieObjectId = new ObjectId(id);
            return MovieRepository.GetMovieById(movieObjectId);
        }


    }
}