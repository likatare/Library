using LibraryRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository
{
    public class LoanRepository
    {
        public static List<Loan> GetLoans()
        {
            Database db = new Database();

            return db.GetLoans();
        }

        public static void LoanBook(Book loanBook , Member memberToLoan, DateTime startDate, DateTime endDate)
        {
            Database db = new Database();

            db.LoanBook(loanBook.Title, memberToLoan.Name, startDate, endDate);
        }

        public static void LoanMovie(Movie loanMovie, Member memberToLoan, DateTime startDate, DateTime endDate)
        {
            Database db = new Database();

            db.LoanMovie(loanMovie.Title, memberToLoan.Name, startDate, endDate);
        }

        public static void UpdateBookLoanById(Book loanBook, Loan updateLoan, DateTime startDate, DateTime endDate)
        {
            Database db = new Database();
            db.UpdateBookLoanById(loanBook.Title, updateLoan.Id, startDate, endDate);
        }

        public static void UpdateMovieLoanById(Movie loanMovie, Loan updateLoan, DateTime startDate, DateTime endDate)
        {
            Database db = new Database();
            db.UpdateMovieLoanById(loanMovie.Title, updateLoan.Id, startDate, endDate);
        }

        public static void DeleteBookLoanById(Loan loan)
        {
            Database db = new Database();
            db.DeleteBookLoanById(loan.Id);
        }

        public static void DeleteMovieLoanById(Loan loan)
        {
            Database db = new Database();
            db.DeleteBookLoanById(loan.Id);
        }
    }
}
