using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class LibraryApp
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
        private int ShowMenu()
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

            int selectedOption = 0;
            int.TryParse(input, out selectedOption);
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

            Database db = new Database();

            db.SaveBook(book);
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

            Database db = new Database();

            db.SaveMovie(movie);
        }

        /// <summary>
        /// Prints a list of all items
        /// </summary>
        private void ShowAllItems()
        {
            Console.Clear();
            Console.WriteLine("Showing items....");

            Database db = new Database();

            List<Book> books = db.GetBooks();
            List<Movie> movies = db.GetMovies();

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
        private void UpdateBook()
        {
            Console.Clear();

            Database db = new Database();
            List<Book> books = db.GetBooks();


            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < books.Count; i++)
            {

                Console.WriteLine($"{i + 1}: Book: {books[i].Title} {books[i].Language} {books[i].YearOfPublication} {books[i].Pages} {books[i].Author} {books[i].Copies}");
            }

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


            db.UpdateBookById(bookToUpdate);
        }

        /// <summary>
        /// Lets the user update a movie
        /// </summary>
        private void UpdateMovie()
        {
            Console.Clear();

            Database db = new Database();
            List<Movie> movies = db.GetMovies();


            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Book: {movies[i].Title} {movies[i].Language} {movies[i].YearOfPublication} {movies[i].Genre} {movies[i].Type} {movies[i].Copies}");
            }

            Console.Write("Select movie to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Movie movieToUpdate = movies[selectedNumber - 1];

            Console.Write("Enter a title: ");
            movieToUpdate.Title = Console.ReadLine();

            Console.Write("Enter a language: ");
            movieToUpdate.Language = Console.ReadLine();

            Console.Write("Enter year of publication: ");
            input = Console.ReadLine();
            int.TryParse(input, out int yearOfPublication);
            movieToUpdate.YearOfPublication = yearOfPublication;

            Console.Write("Enter genre: ");
            movieToUpdate.Genre = Console.ReadLine();

            Console.Write("Enter type: ");
            movieToUpdate.Type = Console.ReadLine();


            Console.Write("Enter number of copies: ");
            input = Console.ReadLine();
            int.TryParse(input, out int copies);
            movieToUpdate.Copies = copies;

            db.UpdateMovieById(movieToUpdate);
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

            Database db = new Database();
            List<Book> books = db.GetBooks();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Book: {books[i].Title} {books[i].Language} {books[i].YearOfPublication} {books[i].Pages} {books[i].Author} {books[i].Copies}");
            }


            Console.WriteLine("Choose book id to delete: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Book deleteBook = books[selectedNumber - 1];


            db.DeleteBookById(deleteBook.Id);

        }

        /// <summary>
        /// Lets the user delete a book with the specific id
        /// </summary>
        private void DeleteMovie()
        {
            Console.Clear();

            Database db = new Database();
            List<Movie> movies = db.GetMovies();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Genre - Type - Copies");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Movie: {movies[i].Title} {movies[i].Language} {movies[i].YearOfPublication} {movies[i].Genre} {movies[i].Type} {movies[i].Copies}");
            }


            Console.WriteLine("Choose movie id to delete: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Movie deleteMovie = movies[selectedNumber - 1];


            db.DeleteMovieById(deleteMovie.Id);

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

            Database db = new Database();
            db.SaveMember(member);
        }

        /// <summary>
        /// Prints a list of members
        /// </summary>
        private void ShowAllMembers()
        {
            Console.Clear();
            Console.WriteLine("Showing Members....");

            Database db = new Database();
            List<Member> members = db.GetMembers();

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

            Database db = new Database();
            List<Member> members = db.GetMembers();

            Console.WriteLine("Id  Name - Age - Address");

            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {members[i].Name} {members[i].Age} {members[i].Address}");
            }

            Console.Write("Select member to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Member memberToUpdate = members[selectedNumber - 1];

            Console.Write("Enter a name: ");
            string memberName = Console.ReadLine();

            Console.Write("Enter a age: ");
            input = Console.ReadLine();
            int.TryParse(input, out int age);

            Console.Write("Enter your address: ");
            string address = Console.ReadLine();


            db.UpdateMemberById(memberToUpdate.Id, memberName, age, address);
        }

        /// <summary>
        /// Lets the user delete a member with the specific id
        /// </summary>
        private void DeleteMember()
        {
            Console.Clear();

            Database db = new Database();
            List<Member> members = db.GetMembers();

            Console.WriteLine("Id  Name - Age - Address");

            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {members[i].Name} {members[i].Age} {members[i].Address}");
            }

            Console.Write("Choose member id to delete: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Member memberToUpdate = members[selectedNumber - 1];

            db.DeleteMemberById(memberToUpdate.Id);

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

            Database db = new Database();

            List<Member> members = db.GetMembers();

            Console.WriteLine("Id  Name - Age - Address");

            for (int x = 0; x < members.Count; x++)
            {
                Console.WriteLine($"{x + 1}: {members[x].Name} {members[x].Age} {members[x].Address}");
            }

            Console.Write("Choose member id to loan a book: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Member memberToLoan = members[selectedNumber - 1];

            List<Book> books = db.GetBooks();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int j = 0; j < books.Count; j++)
            {
                Console.WriteLine($"{j + 1}: Book: {books[j].Title} {books[j].Language} {books[j].YearOfPublication} {books[j].Pages} {books[j].Author} {books[j].Copies}");
            }

            Console.Write("Choose book id to loan: ");
            input = Console.ReadLine();
            selectedNumber = int.Parse(input);
            Book loanBook = books[selectedNumber - 1];

            Console.Write("Enter a day you want to loan your book: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime startDate);


            Console.Write("Enter when you want to return your book: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime endDate);

            List<Loan> loans = db.GetLoans();

            bool loanAccepted = false;
            int startDateResultat = DateTime.Compare(startDate, DateTime.Now.Date);
            int numberOFBooksLoans = 0;

            try
            {
                for (int i = 0; i < loans.Count; i++)
                {
                    if (loans[i].Article == loanBook.Title)
                    {
                        //The following is not met: the new loan start date is later than the current loan end date OR the new loan end date is earlier than the current loan start date.
                        if (!(startDate > loans[i].EndDate || endDate < loans[i].StartDate))
                        {
                            numberOFBooksLoans++;
                        }
                    }
                }
                if (numberOFBooksLoans < loanBook.Copies)
                {
                    loanAccepted = true;
                }
                if (startDateResultat < 0)
                {
                    Console.WriteLine($"You have to book {DateTime.Now.ToShortDateString()} or later ");
                    loanAccepted = false;

                }
                else
                {
                    throw new Exception("try another date");
                }
            }
            catch (System.Exception)
            {

                Console.WriteLine("try another date");
            }

            if (loanAccepted == true)
            {
                db.UpdateBookById(loanBook);
                db.LoanBook(loanBook.Title, memberToLoan.Name, startDate, endDate);
            }

            Console.WriteLine("Press enter");
            Console.ReadLine();

        }

        /// <summary>
        /// Lets the user loan a movie
        /// </summary>
        private void LoanMovieById()
        {
            Console.Clear();

            Database db = new Database();

            List<Member> members = db.GetMembers();

            Console.WriteLine("Id  Name - Age - Address");

            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {members[i].Name} {members[i].Age} {members[i].Address}");
            }

            Console.Write("Choose member id to loan a movie: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Member memberToLoan = members[selectedNumber - 1];

            List<Movie> movies = db.GetMovies();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Movie: {movies[i].Title} {movies[i].Language} {movies[i].YearOfPublication} {movies[i].Genre} {movies[i].Type} {movies[i].Copies}");
            }

            Console.Write("Choose movie id to loan: ");
            input = Console.ReadLine();
            selectedNumber = int.Parse(input);
            Movie loanMovie = movies[selectedNumber - 1];

            Console.Write("Enter a day you want to loan your movie: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime startDate);

            Console.Write("Enter when you want to return your movie: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime endDate);

            List<Loan> loans = db.GetLoans();

            int startDateResultat = DateTime.Compare(startDate, DateTime.Now.Date);
            bool loanAccepted = false;
            int numberOFMovieLoans = 0;


            try
            {
                for (int i = 0; i < loans.Count; i++)
                {
                    if (loans[i].Article == loanMovie.Title)
                    {
                        //The following is not met: the new loan start date is later than the current loan end date OR the new loan end date is earlier than the current loan start date.


                        if (!(startDate > loans[i].EndDate || endDate < loans[i].StartDate))
                        {
                            numberOFMovieLoans++;

                        }
                        if (startDateResultat < 0)
                        {
                            Console.WriteLine($"You have to book {DateTime.Now.ToShortDateString()} or later ");
                            loanAccepted = false;

                        }
                        else
                        {
                            Console.WriteLine("Enter a date today or later.");
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
            }
            catch (System.Exception)
            {

                Console.WriteLine("try another date");
            }
            if (loanAccepted == true)
            {
                db.UpdateMovieById(loanMovie);
                db.LoanMovie(loanMovie.Title, memberToLoan.Name, startDate, endDate);
            }

            Console.WriteLine("Press enter");
            Console.ReadLine();

        }

        /// <summary>
        /// show all loans in the consol
        /// </summary>
        private void ShowAllLoans()
        {
            Console.Clear();
            Console.WriteLine("Showing Loans....");

            Database db = new Database();
            List<Loan> loans = db.GetLoans();

            Console.WriteLine("Name - Article - Starttime - Enddate");

            foreach (Loan loan in loans)
            {
                Console.WriteLine($"Loan: {loan.Member} {loan.Article} {loan.StartDate.ToShortDateString()} {loan.EndDate.ToShortDateString()}");
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

            Database db = new Database();
            List<Loan> loans = db.GetLoans();

            Console.WriteLine("Name - Book - Starttime - Enddate");

            for (int i = 0; i < loans.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Loan: {loans[i].Member} {loans[i].Article} {loans[i].StartDate} {loans[i].EndDate}");
            }

            Console.WriteLine("Choose loan id to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Loan updateLoan = loans[selectedNumber - 1];

            List<Book> books = db.GetBooks();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Book: {books[i].Title} {books[i].Language} {books[i].YearOfPublication} {books[i].Pages} {books[i].Author} {books[i].Copies}");
            }

            Console.Write("Choose book id to loan: ");
            input = Console.ReadLine();
            selectedNumber = int.Parse(input);
            Book loanBook = books[selectedNumber - 1];

            Console.Write("Enter a day you want to loan: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime startDate);

            Console.Write("Enter when you want to return your book: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime endDate);


            db.UpdateBookLoanById(loanBook.Title, updateLoan.Id, startDate, endDate);


        }

        /// <summary>
        /// Lets the user Update a Movieloan.
        /// </summary>
        private void UpdateMovieLoan()
        {
            Console.Clear();

            Database db = new Database();
            List<Loan> loans = db.GetLoans();

            Console.WriteLine("Name - Book - Starttime - Enddate");

            for (int i = 0; i < loans.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Loan: {loans[i].Member} {loans[i].Article} {loans[i].StartDate} {loans[i].EndDate}");
            }

            Console.WriteLine("Choose loan id to update: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Loan updateLoan = loans[selectedNumber - 1];

            List<Movie> movies = db.GetMovies();

            Console.WriteLine("Id  Title - Language - Year Of Publication - Pages - Author - Copies");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Movie: {movies[i].Title} {movies[i].Language} {movies[i].YearOfPublication} {movies[i].Genre} {movies[i].Type} {movies[i].Copies}");
            }

            Console.Write("Choose movie id to loan: ");
            input = Console.ReadLine();
            selectedNumber = int.Parse(input);
            Movie loanMovie = movies[selectedNumber - 1];

            Console.Write("Enter a day you want to loan your movie: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime startDate);

            Console.Write("Enter when you want to return your movie: ");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime endDate);


            db.UpdateMovieLoanById(loanMovie.Title, updateLoan.Id, startDate, endDate);

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

            Database db = new Database();

            List<Loan> loans = db.GetLoans();

            Console.WriteLine("Name - Article - Starttime - Enddate");

            for (int i = 0; i < loans.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Loan: {loans[i].Member} {loans[i].Article} {loans[i].StartDate.ToShortDateString()} {loans[i].EndDate.ToShortDateString()}");
            }

            Console.WriteLine("Choose loan id to delete: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Loan deleteLoan = loans[selectedNumber - 1];



            db.DeleteBookLoanById(deleteLoan.Id);

        }

        /// <summary>
        /// Deletes a book loan.
        /// </summary>
        private void DeleteMovieLoan()
        {
            Console.Clear();
            Database db = new Database();

            List<Loan> loans = db.GetLoans();

            Console.WriteLine("Name - Article - Starttime - Enddate");

            for (int i = 0; i < loans.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Loan: {loans[i].Member} {loans[i].Article} {loans[i].StartDate} {loans[i].EndDate}");
            }

            Console.WriteLine("Choose loan id to delete: ");
            string input = Console.ReadLine();
            int selectedNumber = int.Parse(input);
            Loan deleteLoan = loans[selectedNumber - 1];

            db.DeleteMovieLoanById(deleteLoan.Id);
        }

    }
}
