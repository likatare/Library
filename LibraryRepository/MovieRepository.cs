using LibraryRepository.Models;
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

        /// <summary>
        /// Updates a movie in the database
        /// </summary>
        /// <param name="movie">Movie of movie</param>
        public static void UpdateMovieById(Movie movie)
        {
            Database db = new Database();

            db.UpdateMovieById(movie);
        }

        /// <summary>
        /// Deletes a movie in the database
        /// </summary>
        /// <param name="movie">Movie of movie</param>
        public static void DeleteMovieById(Movie movie)
        {
            Database db = new Database();

            db.DeleteMovieById(movie.Id);
        }
    }
}
