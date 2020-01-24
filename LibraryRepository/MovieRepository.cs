using LibraryRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository
{
    public class MovieRepository
    {
        public static void SaveMovie(Movie movie)
        {
            Database db = new Database();

            db.SaveMovie(movie);
        }

        public static List<Movie> GetMovies()
        {
            Database db = new Database();

            return db.GetMovies();
        }

        public static void UpdateMovieById(Movie movie)
        {
            Database db = new Database();

            db.UpdateMovieById(movie);
        }

        public static void DeleteMovieById(Movie movie)
        {
            Database db = new Database();

            db.DeleteMovieById(movie.Id);
        }
    }
}
