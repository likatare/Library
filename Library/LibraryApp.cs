using LibraryRepository.Models;
using LibraryRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class LibraryApp
    {
        /// <summary>
        /// Starts the showmenu
        /// </summary>
        public void Start()
        {

            while (true)
            {
                bool exit = false;

                int selectedMenuOption = ShowMenu();

                switch (selectedMenuOption)
                {
                    case 1:
                        CreateItem();
                        break;
                    case 2:
                        ShowAllItems();
                        break;
                    case 3:
                        UpdateItem();
                        break;
                    case 4:
                        DeleteItem();
                        break;
                    case 5:
                        CreateMember();
                        break;
                    case 6:
                        ShowAllMembers();
                        break;
                    case 7:
                        UpdateMember();
                        break;
                    case 8:
                        DeleteMember();
                        break;
                    case 9:
                        CreateLoan();
                        break;
                    case 10:
                        ShowAllLoans();
                        break;
                    case 11:
                        UpdateLoan();
                        break;
                    case 12:
                        DeleteLoan();
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
        private static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("  1. Create item");
            Console.WriteLine("  2. Show all items");
            Console.WriteLine("  3. Update item");
            Console.WriteLine("  4. Delete item");
            Console.WriteLine("  5. create a member");
            Console.WriteLine("  6. Show all members");
            Console.WriteLine("  7. Update member");
            Console.WriteLine("  8. Delete member");
            Console.WriteLine("  9. Create loan");
            Console.WriteLine("  10. Show all loans");
            Console.WriteLine("  11. Update loan");
            Console.WriteLine("  12. Delete loan");
            Console.WriteLine("  0. Exit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();

            int.TryParse(input, out int selectedOption);
            return selectedOption;
        }

        /// <summary>
        /// Let the user create a book or a movie
        /// </summary>
        private void CreateItem()
        {
            Console.Clear();
            Console.WriteLine("Creating item...");

            Console.Write("Select (b)ook or (m)ovie: ");
            string itemType = Console.ReadLine();

            Console.Write("Enter a title: ");
            string title = Console.ReadLine();

            Console.Write("Enter a language: ");
            string language = Console.ReadLine();

            Console.Write("Enter year of publication: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int yearOfPublication);

            if (itemType.ToLower() == "b")
            {
                CreateBook(title, language, yearOfPublication);
            }
            else if (itemType.ToLower() == "m")
            {
                CreateMovie(title, language, yearOfPublication);
            }
        }

        /// <summary>
        /// Lets the user create a book 
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="language">Language of the book</param>
        /// <param name="yearOfPublication">Year of publication of the book</param>
        private void CreateBook(string title, string language, int yearOfPublication)
        {
            Console.Write("Enter how many pages: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int pages);

            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            Console.Write("Enter number of copies: ");
            input = Console.ReadLine();
            int.TryParse(input, out int copies);

            Book book = new Book(title, language, yearOfPublication, copies, pages, author);

            BookRepository.SaveBook(book);
        }

        /// <summary>
        /// Lets the user create a movie
        /// </summary>
        /// <param name="title">Title of the movie</param>
        /// <param name="language">Language of the movie</param>
        /// <param name="yearOfPublication">Year of publication of the movie</param>
        private void CreateMovie(string title, string language, int yearOfPublication)
        {
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();


            Console.Write("Enter type: ");
            string type = Console.ReadLine();


            Console.Write("Enter number of copies: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int copies);


            Movie movie = new Movie(title, language, yearOfPublication, copies, genre, type);

            MovieRepository.SaveMovie(movie);
        }




        /// <summary>
        /// Prints a list of all items
        /// </summary>
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

        /// <summary>
        /// Lets the user to choose to update book or movie.
        /// </summary>
        private void UpdateItem()
        {
            Console.Clear();
            Console.WriteLine("Updating item...");

            Console.Write("Select (b)ook or (m)ovie: ");
            string itemType = Console.ReadLine();


            if (itemType.ToLower() == "b")
            {
                UpdateBook();
            }
            else if (itemType.ToLower() == "m")
            {
                UpdateMovie();
            }
        }

        /// <summary>
        /// Lets the user update a book
        /// </summary>
        public void UpdateBook()
        {
            Console.Clear();

            List<Book> books = ListOfBooks();

            InPutUpdateBook(books);
        }

        /// <summary>
        /// list of books
        /// </summary>
        /// <returns>A list of books+</returns>
        private static List<Book> ListOfBooks()
        {
            List<Book> books = BookRepository.GetBooks();


            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < books.Count; i++)
            {

                Console.WriteLine($"{i + 1}: Book: {books[i].Title} {books[i].Language} {books[i].YearOfPublication} {books[i].Pages} {books[i].Author} {books[i].Copies}");
            }

            return books;
        }

        /// <summary>
        /// Lets the user updade bookinput
        /// </summary>
        /// <param name="books">list of books</param>
        private static void InPutUpdateBook(List<Book> books)
        {
            Console.Write("Select member to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Book bookToUpdate = books[selectedNumber - 1];

            Console.Write("Enter a title: ");
            bookToUpdate.Title = Console.ReadLine();

            Console.Write("Enter a language: ");
            bookToUpdate.Language = Console.ReadLine();

            Console.Write("Enter year of publication: ");
            input = Console.ReadLine();
            int.TryParse(input, out int yearOfPublication);
            bookToUpdate.YearOfPublication = yearOfPublication;

            Console.Write("Enter how many pages: ");
            input = Console.ReadLine();
            int.TryParse(input, out int pages);
            bookToUpdate.Pages = pages;

            Console.Write("Enter author: ");
            bookToUpdate.Author = Console.ReadLine();

            Console.Write("Enter number of copies: ");
            input = Console.ReadLine();
            int.TryParse(input, out int copies);
            bookToUpdate.Copies = copies;


            BookRepository.UpdateBookById(bookToUpdate.Id,bookToUpdate);
        }

        /// <summary>
        /// Lets the user update a movie
        /// </summary>
        private void UpdateMovie()
        {
            Console.Clear();

            bool inputValidation = true;


            List<Movie> movies = MovieRepository.GetMovies();


            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Movie: {movies[i].Title} {movies[i].Language} {movies[i].YearOfPublication} {movies[i].Genre} {movies[i].Type} {movies[i].Copies}");
            }

            Console.Write("Select movie to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Movie movieToUpdate = movies[selectedNumber - 1];

            Console.Write("Enter a title: ");
            movieToUpdate.Title = Console.ReadLine();

            Console.Write("Enter a language: ");
            movieToUpdate.Language = Console.ReadLine();



            while (inputValidation)
            {

                Console.Write("Enter year of publication: ");
                input = Console.ReadLine();

                if (IsDigitsOnly(input))
                {
                    int.TryParse(input, out int yearOfPublications);
                    inputValidation = false;
                }
                else
                {
                    Console.WriteLine("Wrong input");
                    inputValidation = true;
                }
            }

            int.TryParse(input, out int yearOfPublication);
            movieToUpdate.YearOfPublication = yearOfPublication;



            while (!inputValidation)
            {
                Console.Write("Enter genre: ");
                movieToUpdate.Genre = Console.ReadLine();

                if (ValidateString(movieToUpdate.Genre))
                {
                    inputValidation = true;
                }

                else
                {
                    Console.WriteLine("Wrong input");
                    inputValidation = false;

                }
            }


            Console.Write("Enter type: ");
            movieToUpdate.Type = Console.ReadLine();


            Console.Write("Enter number of copies: ");
            input = Console.ReadLine();
            int.TryParse(input, out int copies);
            movieToUpdate.Copies = copies;

            MovieRepository.UpdateMovieById(movieToUpdate.Id,movieToUpdate);
        }

        /// <summary>
        /// Validates if its a number.
        /// </summary>
        /// <param name="str">string to validate</param>
        /// <returns>A bool that is true or false</returns>
        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Validates inputs length and if it contains anythinge else then letters
        /// </summary>
        /// <param name="str">string to validate</param>
        /// <returns>A bool that is true or false</returns>
        public bool ValidateString(string str)
        {
            bool output = true;
            char[] invalidCharacters = "~!@#¤%^&()_+=0123456789<>,.?/\\|{}[]'\"".ToCharArray();

            if (str.Length < 2)
            {
                output = false;
            }

            if (str.IndexOfAny(invalidCharacters) >= 0)
            {
                output = false;
            }
            return output;
        }



        /// <summary>
        /// Lets the user Choose to delete a book or movie. 
        /// </summary>
        private void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("Deleting item...");

            Console.Write("Select (b)ook or (m)ovie: ");
            string itemType = Console.ReadLine();


            if (itemType.ToLower() == "b")
            {
                DeleteBook();
            }
            else if (itemType.ToLower() == "m")
            {
                DeleteMovie();
            }
        }

        /// <summary>
        /// Lets the user delete a book with the specific id
        /// </summary>
        private void DeleteBook()
        {
            Console.Clear();

            List<Book> books = BookRepository.GetBooks(); ;

            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Book: {books[i].Title} {books[i].Language} {books[i].YearOfPublication} {books[i].Pages} {books[i].Author} {books[i].Copies}");
            }


            Console.WriteLine("Choose book id to delete: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Book deleteBook = books[selectedNumber - 1];


            BookRepository.DeleteBookById(deleteBook.Id);

        }

        /// <summary>
        /// Lets the user delete a book with the specific id
        /// </summary>
        private void DeleteMovie()
        {
            Console.Clear();


            List<Movie> movies = MovieRepository.GetMovies();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Genre - Type - Copies");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Movie: {movies[i].Title} {movies[i].Language} {movies[i].YearOfPublication} {movies[i].Genre} {movies[i].Type} {movies[i].Copies}");
            }


            Console.WriteLine("Choose movie id to delete: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Movie deleteMovie = movies[selectedNumber - 1];


            MovieRepository.DeleteMovieById(deleteMovie.Id);

        }

        /// <summary>
        /// Lets the user input name, age and address and create a member.
        /// </summary>
        private void CreateMember()
        {
            Console.Clear();
            Console.Write("Enter a name: ");
            string name = Console.ReadLine();

            Console.Write("Enter a age: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int age);

            Console.Write("Enter your address: ");
            string address = Console.ReadLine();

            Member member = new Member(name, age, address);

            MemberRepository.SaveMember(member);
        }

        /// <summary>
        /// Prints a list of members
        /// </summary>
        private void ShowAllMembers()
        {
            Console.Clear();
            Console.WriteLine("Showing Members....");


            List<Member> members = MemberRepository.GetMembers();

            Console.WriteLine("Name - Age - Address");

            foreach (Member member in members)
            {
                Console.WriteLine($"{member.Name} {member.Age} {member.Address}");
            }
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
        }

        /// <summary>
        /// Lets the user update a member
        /// </summary>
        private void UpdateMember()
        {
            Console.Clear();

            Member memberToUpdate = SelectMember();

            Console.Write("Enter a name: ");
            memberToUpdate.Name = Console.ReadLine();

            Console.Write("Enter a age: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int age);
            memberToUpdate.Age = age;

            Console.Write("Enter your address: ");
            memberToUpdate.Address = Console.ReadLine();


            MemberRepository.UpdateMemberById(memberToUpdate.Id,memberToUpdate);
        }

        /// <summary>
        /// Select Member to loan.
        /// </summary>
        /// <returns>selected member id</returns>
        private static Member SelectMember()
        {

            List<Member> members = MemberRepository.GetMembers();

            Console.WriteLine("Id  Name - Age - Address");

            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {members[i].Name} {members[i].Age} {members[i].Address}");
            }

            Console.Write("Select member to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            return members[selectedNumber - 1];

        }

        /// <summary>
        /// Lets the user delete a member with the specific id
        /// </summary>
        private void DeleteMember()
        {
            Console.Clear();

            Member memberToDelete = SelectMember();

            MemberRepository.DeleteMemberById(memberToDelete.Id);

        }

        /// <summary>
        /// Lets the user create a loan of a book or a movie
        /// </summary>
        private void CreateLoan()
        {
            Console.Clear();
            Console.WriteLine("Creating loan...");

            Console.Write("Select (b)ook or (m)ovie: ");
            string itemType = Console.ReadLine();


            if (itemType.ToLower() == "b")
            {
                LoanBookById();
            }
            else if (itemType.ToLower() == "m")
            {
                LoanMovieById();
            }
        }

        /// <summary>
        /// Lets the user loan a book
        /// </summary>
        private void LoanBookById()
        {
            Console.Clear();

            Member memberToLoan = SelectMember();
            Book loanBook = SelectBook();

            Console.Write("Enter a day you want to loan your book: ");
            string input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime startDate);


            Console.Write("Enter when you want to return your book: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime endDate);

            List<Loan> loans = LoanRepository.GetLoans();

            bool loanAccepted = false;
            int startDateResultat = DateTime.Compare(startDate, DateTime.Now.Date);
            int numberOFBooksLoans = 0;

            try
            {
                for (int i = 0; i < loans.Count; i++)
                {
                    if (loans[i].BookRented != null)
                    {
                        if (loans[i].BookRented.Id == loanBook.Id)
                        {
                            //The following is not met: the new loan start date is later than the current loan end date OR the new loan end date is earlier than the current loan start date.
                            if (!(startDate > loans[i].EndDate || endDate < loans[i].StartDate))
                            {
                                numberOFBooksLoans++;
                            }
                        }
                    }
                }

                if (numberOFBooksLoans < loanBook.Copies)
                {
                    loanAccepted = true;
                }

                else
                {
                    throw new Exception("try another date");
                }

                if (startDateResultat < 0)
                {
                    Console.WriteLine($"You have to book {DateTime.Now.ToShortDateString()} or later ");
                    loanAccepted = false;

                }
            }
            catch (System.Exception)
            {

                Console.WriteLine("try another date");
            }

            if (loanAccepted == true)
            {
                BookRepository.UpdateBookById(loanBook.Id,loanBook);
                LoanRepository.LoanBook(loanBook, memberToLoan, startDate, endDate);
            }

            Console.WriteLine("Press enter");
            Console.ReadLine();

        }


        /// <summary>
        /// select bookId to loan
        /// </summary>
        /// <returns>selected book id</returns>
        private Book SelectBook()
        {

            List<Book> books = BookRepository.GetBooks();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int j = 0; j < books.Count; j++)
            {
                Console.WriteLine($"{j + 1}: Book: {books[j].Title} {books[j].Language} {books[j].YearOfPublication} {books[j].Pages} {books[j].Author} {books[j].Copies}");
            }

            Console.Write("Choose book id to loan: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            return books[selectedNumber - 1];
        }


        public bool IsDateInRightFormat(string date)
        {
            if (DateTime.TryParse(date, out DateTime startDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Lets the user loan a movie
        /// </summary>
        private void LoanMovieById()
        {
            Console.Clear();

            Member memberToLoan = SelectMember();
            Movie loanMovie = SelectMovie();

            string input = "";
            bool test = true;

            while (test)
            {

                Console.Write("Enter a day you want to loan your movie: ");
                input = Console.ReadLine();


                if (IsDateInRightFormat(input))
                {
                    DateTime.TryParse(input, out DateTime startdate);
                    test = false;
                }
                else
                {
                    Console.WriteLine("Wrong Date Format");
                    test = true;
                }

            }

            DateTime.TryParse(input, out DateTime startDate);

            while (!test)
            {

                Console.Write("Enter when you want to return your movie: ");
                input = Console.ReadLine();


                if (IsDateInRightFormat(input))
                {
                    DateTime.TryParse(input, out DateTime endingDate);
                    test = true;

                }
                else
                {
                    Console.WriteLine("Wrong Date Format");
                    test = false;
                }
            }

            DateTime.TryParse(input, out DateTime endDate);

            List<Loan> loans = LoanRepository.GetLoans();

            int startDateResultat = DateTime.Compare(startDate, DateTime.Now.Date);
            bool loanAccepted = false;
            int numberOFMovieLoans = 0;

            try
            {
                for (int i = 0; i < loans.Count; i++)
                {
                    if (loans[i].MovieRented != null)
                    {
                        if (loans[i].MovieRented.Id == loanMovie.Id)
                        {
                            //The following is not met: the new loan start date is later than the current loan end date OR the new loan end date is earlier than the current loan start date.

                            if (!(startDate > loans[i].EndDate || endDate < loans[i].StartDate))
                            {
                                numberOFMovieLoans++;

                            }
                        }
                    }
                }

                if (numberOFMovieLoans < loanMovie.Copies)
                {
                    loanAccepted = true;
                }

                else
                {
                    throw new Exception("try another date");
                }

                if (startDateResultat < 0)
                {
                    Console.WriteLine($"You have to book {DateTime.Now.ToShortDateString()} or later ");
                    loanAccepted = false;

                }

            }
            catch (System.Exception)
            {

                Console.WriteLine("try another date");
            }
            if (loanAccepted == true)
            {
                MovieRepository.UpdateMovieById(loanMovie.Id,loanMovie);
                LoanRepository.LoanMovie(loanMovie, memberToLoan, startDate, endDate);
            }

            Console.WriteLine("Press enter");
            Console.ReadLine();

        }




        private Movie SelectMovie()
        {

            List<Movie> movies = MovieRepository.GetMovies();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Movie: {movies[i].Title} {movies[i].Language} {movies[i].YearOfPublication} {movies[i].Genre} {movies[i].Type} {movies[i].Copies}");
            }

            Console.Write("Choose movie id to loan: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            return movies[selectedNumber - 1];

        }

        private Loan SelectBookLoan()
        {

            List<Loan> bookLoans = LoanRepository.GetLoans();


            Console.WriteLine("Name - Movie - Starttime - Enddate");


            string bookTitle = "";
            for (int i = 0; i < bookLoans.Count; i++)
            {
                if (bookLoans[i].BookRented != null)
                {
                    bookTitle = bookLoans[i].BookRented.Title;

                    //members
                    Console.WriteLine($"{i + 1}: Loan: {bookLoans[i].MemberRenting.Name} {bookTitle} {bookLoans[i].StartDate.ToShortDateString()} {bookLoans[i].EndDate.ToShortDateString()}");
                }
            }

            Console.WriteLine("Choose loan id to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            return bookLoans[selectedNumber - 1];

        }

        private Loan SelectMovieLoan()
        {

            List<Loan> movieLoans = LoanRepository.GetLoans();


            Console.WriteLine("Name - Movie - Starttime - Enddate");


            string movieTitle = "";
            for (int i = 0; i < movieLoans.Count; i++)
            {
                if (movieLoans[i].MovieRented != null)
                {
                    movieTitle = movieLoans[i].MovieRented.Title;

                    //members
                    Console.WriteLine($"{i + 1}: Loan: {movieLoans[i].MemberRenting.Name} {movieTitle} {movieLoans[i].StartDate.ToShortDateString()} {movieLoans[i].EndDate.ToShortDateString()}");
                }
            }

            Console.WriteLine("Choose loan id to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            return movieLoans[selectedNumber - 1];

        }

        /// <summary>
        /// show all loans in the consol
        /// </summary>
        private void ShowAllLoans()
        {
            Console.Clear();
            Console.WriteLine("Showing Loans....");


            List<Loan> loans = LoanRepository.GetLoans();

            Console.WriteLine("Name - Article - Starttime - Enddate");

            for (int i = 0; i < loans.Count; i++)
            {

                if (loans[i].MovieRented != null)
                {
                    Console.WriteLine($"Loan: {loans[i].MemberRenting.Name} {loans[i].MovieRented.Title} {loans[i].StartDate.ToShortDateString()} {loans[i].EndDate.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine($"Loan: {loans[i].MemberRenting.Name} {loans[i].BookRented.Title} {loans[i].StartDate.ToShortDateString()} {loans[i].EndDate.ToShortDateString()}");

                }
            }
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
        }

        /// <summary>
        /// Let the user choose to update bookloan or movieloan
        /// </summary>
        private void UpdateLoan()
        {
            Console.Clear();
            Console.WriteLine("Updating loan...");

            Console.Write("Select (b)ook or (m)ovie: ");
            string itemType = Console.ReadLine();


            if (itemType.ToLower() == "b")
            {
                UpdateBookLoan();
            }
            else if (itemType.ToLower() == "m")
            {
                UpdateMovieLoan();
            }
        }

        /// <summary>
        /// Let the user update a bookloan.
        /// </summary>
        private void UpdateBookLoan()
        {
            Console.Clear();

            Console.WriteLine("Updating bookloan....");

            Loan updateBookLoan = SelectBookLoan();
            Book loanBook = SelectBook();

            Console.Write("Enter a day you want to loan: ");
            string input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime startDate);

            Console.Write("Enter when you want to return your book: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime endDate);

            LoanRepository.UpdateBookLoanById(loanBook, updateBookLoan, startDate, endDate);
        }

        /// <summary>
        /// Lets the user Update a Movieloan.
        /// </summary>
        private void UpdateMovieLoan()
        {
            Console.Clear();

            Loan updateMovieLoan = SelectMovieLoan();
            Movie loanMovie = SelectMovie();

            Console.Write("Enter a day you want to loan your movie: ");
            string input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime startDate);

            Console.Write("Enter when you want to return your movie: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime endDate);

            LoanRepository.UpdateMovieLoanById(loanMovie, updateMovieLoan, startDate, endDate);
        }

        /// <summary>
        /// Lets the user choose to delete a book or a movie
        /// </summary>
        private void DeleteLoan()
        {
            Console.Clear();
            Console.WriteLine("Deleting loan...");

            Console.Write("Select (b)ook or (m)ovie: ");
            string itemType = Console.ReadLine();


            if (itemType.ToLower() == "b")
            {
                DeleteBookLoan();
            }
            else if (itemType.ToLower() == "m")
            {
                DeleteMovieLoan();
            }
        }

        /// <summary>
        /// Deletes a book loan.
        /// </summary>
        private void DeleteBookLoan()
        {
            Console.Clear();

            Loan deleteBookLoan = SelectBookLoan();

            LoanRepository.DeleteBookLoanById(deleteBookLoan);

        }

        /// <summary>
        /// Deletes a book loan.
        /// </summary>
        private void DeleteMovieLoan()
        {
            Console.Clear();

            Loan deleteMovieLoan = SelectMovieLoan();

            LoanRepository.DeleteMovieLoanById(deleteMovieLoan);
        }

    }
}
