using LibraryRepository.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository
{
    public class MovieRepository
    {
        /// <summary>
        /// Saves a movie in the database
        /// </summary>
        /// <param name="movie">Movie of movie</param>
        public static void SaveMovie(Movie movie)
        {
            Database db = new Database();

            db.SaveMovie(movie);
        }

        /// <summary>
        /// Gets a list of movies
        /// </summary>
        /// <returns>a list of movies</returns>
        public static List<Movie> GetMovies()
        {
            Database db = new Database();

            return db.GetMovies();
        }

        public static Movie GetMovieById(ObjectId movieId)
        {
            Database db = new Database();
            return db.GetMovieById(movieId);
        }

        /// <summary>
        /// Updates a movie in the database
        /// </summary>
        /// <param name="movie">Movie of movie</param>
        public static void UpdateMovieById(ObjectId movieId,Movie movie)
        {
            Database db = new Database();

            db.UpdateMovieById(movieId,movie);
        }

        /// <summary>
        /// Deletes a movie in the database
        /// </summary>
        /// <param name="movie">Movie of movie</param>
        public static void DeleteMovieById(ObjectId movieId)
        {
            Database db = new Database();

            db.DeleteMovieById(movieId);
        }

        public static bool MovieIsFreeToLoan(Loan loan)
        {
            List<Loan> allSameFilmRented = LoanRepository.GetAllLoanedMovie(loan.MovieRented);
            int rentedCopies = 0;
            for (int i = 0; i < allSameFilmRented.Count; i++)
            {
                if (loan.EndDate >= allSameFilmRented[i].StartDate && loan.StartDate <= allSameFilmRented[i].EndDate)
                {
                    rentedCopies++;
                }
            }
            if (rentedCopies >= loan.MovieRented.Copies)
            {
                return false;
            }
            return true;
        }
    }
}
