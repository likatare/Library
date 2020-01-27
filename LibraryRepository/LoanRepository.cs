using LibraryRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository
{
    public class LoanRepository
    {   
        /// <summary>
        /// Gets a list of loans from the database
        /// </summary>
        /// <returns>A list of loans</returns>
        public static List<Loan> GetLoans()
        {
            Database db = new Database();

            return db.GetLoans();
        }

        /// <summary>
        /// Create a loan on a book in the database
        /// </summary>
        /// <param name="loanBook">title of the loaned book</param>
        /// <param name="memberToLoan">member to loan the book</param>
        /// <param name="startDate">startdate of the bookloan</param>
        /// <param name="endDate">enddate of the bookloan</param>
        public static void LoanBook(Book loanBook , Member memberToLoan, DateTime startDate, DateTime endDate)
        {
            Database db = new Database();

            db.LoanBook(loanBook, memberToLoan.Name, startDate, endDate);
        }

        /// <summary>
        /// Create a loan on a movie in the database
        /// </summary>
        /// <param name="loanMovie">title of the movie</param>
        /// <param name="memberToLoan">member to loan the movie</param>
        /// <param name="startDate">startdate of the movieloan</param>
        /// <param name="endDate">enddate of the movieloan</param>
        public static void LoanMovie(Movie loanMovie, Member memberToLoan, DateTime startDate, DateTime endDate)
        {
            Database db = new Database();

            db.LoanMovie(loanMovie, memberToLoan.Name, startDate, endDate);
        }

        /// <summary>
        /// Updates a loan on a book in the database
        /// </summary>
        /// <param name="loanBook">title of the movie</param>
        /// <param name="updateLoan">loanid to update</param>
        /// <param name="startDate">startdate of the movieloan</param>
        /// <param name="endDate">endate of the movieloan</param>
        public static void UpdateBookLoanById(Book loanBook, Loan updateLoan, DateTime startDate, DateTime endDate)
        {
            Database db = new Database();
            db.UpdateBookLoanById(loanBook, updateLoan.Id, startDate, endDate);
        }

        /// <summary>
        /// Updates loan on a movie in the database
        /// </summary>
        /// <param name="loanMovie">title of the movie</param>
        /// <param name="updateLoan">loanid to update</param>
        /// <param name="startDate">startdate of the movieloan</param>
        /// <param name="endDate">enddate of the movieloan</param>
        public static void UpdateMovieLoanById(Movie loanMovie, Loan updateLoan, DateTime startDate, DateTime endDate)
        {
            Database db = new Database();
            db.UpdateMovieLoanById(loanMovie, updateLoan.Id, startDate, endDate);
        }

        /// <summary>
        /// Deletes a bookloan in the database
        /// </summary>
        /// <param name="loan">id of loan</param>
        public static void DeleteBookLoanById(Loan loan)
        {
            Database db = new Database();
            db.DeleteBookLoanById(loan.Id);
        }

        /// <summary>
        /// Deletes a movieloan in the database
        /// </summary>
        /// <param name="loan">id of loan</param>
        public static void DeleteMovieLoanById(Loan loan)
        {
            Database db = new Database();
            db.DeleteMovieLoanById(loan.Id);
        }
    }
}
