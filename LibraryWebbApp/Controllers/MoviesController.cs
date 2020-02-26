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
    public class MoviesController : Controller
    {
        /// <summary>
        /// Gets all films from the database.
        /// </summary>
        /// <returns>View of movies</returns>
        public ActionResult Index()
        {
            List<Movie> movies = MovieRepository.GetMovies();

            return View(movies);
        }

        /// <summary>
        /// Gets a movie id from database.
        /// </summary>
        /// <param name="id">id of movie</param>
        /// <returns>Movie to view</returns>
        public ActionResult Details(string id)
        {
            ObjectId movieId = new ObjectId(id);

            Movie movie = MovieRepository.GetMovieById(movieId);

            return View(movie);
        }

        /// <summary>
        /// Shows a create form
        /// </summary>
        /// <returns>A form</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Gets all value from a filmform and creates it in database.
        /// </summary>
        /// <param name="movie">Movie of movie</param>
        /// <returns>Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                MovieRepository.SaveMovie(movie);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Get id from database and creates an edit form
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie View</returns>
        public ActionResult Edit(string id)
        {
            ObjectId movieId = new ObjectId(id);

            Movie movie = MovieRepository.GetMovieById(movieId);

            return View(movie);
        }

        /// <summary>
        /// Gets id from database and update the movie in the database.
        /// </summary>
        /// <param name="id">id of movie</param>
        /// <param name="movie">Movie of movie</param>
        /// <returns>Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Movie movie)
        {
            try
            {
                ObjectId movieId = new ObjectId(id);
                MovieRepository.UpdateMovieById(movieId,movie);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Gets a id from movie
        /// </summary>
        /// <param name="id">id of the movie</param>
        /// <returns>Movie to view</returns>
        public ActionResult Delete(string id)
        {
            ObjectId movieId = new ObjectId(id);
            Movie movie = MovieRepository.GetMovieById(movieId);

            return View(movie);
        }

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="id">id of the movie</param>
        /// <param name="collection"></param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                ObjectId movieId = new ObjectId(id);

                MovieRepository.DeleteMovieById(movieId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}