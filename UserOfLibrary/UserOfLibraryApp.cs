using LibraryRepository;
using LibraryRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserOfLibrary
{
    class UserOfLibraryApp
    {
        public void Start()
        {
            while (true)
            {
                bool exit = false;

                int selectedMenuOption = ShowMenu();

                

                switch (selectedMenuOption)
                {
                    case 1:
                        ShowAllItems();
                        break;
                    default:
                        exit = true;
                        break;
                }

                if (exit)
                {
                    break;
                }
            }

        }

        /// <summary>
        /// shows the menu and lets the user pick a option.
        /// </summary>
        /// <returns>The selected option of the user</returns>
        private int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("  1. Show all items");
            Console.WriteLine("  0. Exit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();

            int.TryParse(input, out int selectedOption);
            return selectedOption;
        }


        private void ShowAllItems()
        {
            Console.Clear();
            Console.WriteLine("Showing items....");


            List<Book> books = BookRepository.GetBooks();
            List<Movie> movies = MovieRepository.GetMovies();

            Console.WriteLine("Title - Language - Year Of Publication - Pages - Author - Copies");

            foreach (Book book in books)
            {
                Console.WriteLine($"Book: {book.Title} {book.Language} {book.YearOfPublication} {book.Pages} {book.Author} {book.Copies}");
            }


            Console.WriteLine("\nTitle - Language - Year Of Publication - Genre - Type - Copies");
            foreach (Movie movie in movies)
            {
                Console.WriteLine($"Movie: {movie.Title} {movie.Language} {movie.YearOfPublication} {movie.Genre} {movie.Type} {movie.Copies}");
            }

            Console.WriteLine("press enter to continue");
            Console.ReadLine();
        }

    }
}
