using MongoDB.Bson;
using MongoDB.Driver;
using LibraryRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository
{
    public class Database
    {

        private const string BOOKS_COLLECTION = "books";
        private const string MEMBERS_COLLECTION = "members";
        private const string Movies_COLLECTION = "movies";
        private const string LOANS_COLLECTION = "loans";

        private readonly IMongoDatabase _database;

        public Database()
        {
            MongoClient dbclient = new MongoClient();
            _database = dbclient.GetDatabase("library");
        }


        /// <summary>
        /// Saves book to the database
        /// </summary>
        /// <param name="book">The book to save</param>
        public void SaveBook(Book book)
        {

            var collection = _database.GetCollection<Book>(BOOKS_COLLECTION);

            collection.InsertOne(book);
        }

        internal Movie GetMovieById(ObjectId id)
        {
            var collection = _database.GetCollection<Movie>(Movies_COLLECTION);
            return collection.Find(m => m.Id == id).FirstOrDefault();
        }



        /// <summary>
        /// Saves movie to the database
        /// </summary>
        /// <param name="movie">The movie to save</param>
        public void SaveMovie(Movie movie)
        {

            var collection = _database.GetCollection<Movie>(Movies_COLLECTION);

            collection.InsertOne(movie);
        }

        /// <summary>
        /// Gets all books from database.
        /// </summary>
        /// <returns>list of all books in the database</returns>
        internal List<Book> GetBooks()
        {
            var collection = _database.GetCollection<Book>(BOOKS_COLLECTION);
            var findresult = collection.Find(b => true);
            return findresult.ToList();
        }


        internal Book GetBookById(ObjectId id)
        {
            var collection = _database.GetCollection<Book>(BOOKS_COLLECTION);
            return collection.Find(b => b.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets all the movies from database.
        /// </summary>
        /// <returns>list of all movies in the database</returns>
        internal List<Movie> GetMovies()
        {
            var collection = _database.GetCollection<Movie>(Movies_COLLECTION);
            var findresult = collection.Find(m => true);

            return findresult.ToList();
        }

        /// <summary>
        /// Updates book to the database
        /// </summary>
        /// <param name="id">book id</param>
        /// <param name="title">book title</param>
        /// <param name="language">book language</param>
        /// <param name="yearOfPublication">book year of publication</param>
        /// <param name="pages">book pages</param>
        /// <param name="author">book author</param>
        internal void UpdateBookById(ObjectId id,Book booksIndex)
        {
            var collection = _database.GetCollection<Book>(BOOKS_COLLECTION);

            UpdateDefinition<Book> update = Builders<Book>.Update
                .Set(b => b.Title, booksIndex.Title)
                .Set(b => b.Language, booksIndex.Language)
                .Set(b => b.YearOfPublication, booksIndex.YearOfPublication)
                .Set(b => b.Pages, booksIndex.Pages)
                .Set(b => b.Author, booksIndex.Author)
                .Set(b => b.Copies, booksIndex.Copies);

            collection.UpdateOne(b => b.Id == id, update);
        }

        /// <summary>
        /// Updates Movie to the database
        /// </summary>
        /// <param name="id">movie id</param>
        /// <param name="title">movie title</param>
        /// <param name="language">movie language</param>
        /// <param name="yearOfPublication">movie year of publication </param>
        /// <param name="genre">movie genre</param>
        /// <param name="type">movie type</param>
        internal void UpdateMovieById(ObjectId id,Movie moviesIndex)
        {
            var collection = _database.GetCollection<Movie>(Movies_COLLECTION);

            UpdateDefinition<Movie> update = Builders<Movie>.Update
                .Set(m => m.Title, moviesIndex.Title)
                .Set(m => m.Language, moviesIndex.Language)
                .Set(m => m.YearOfPublication, moviesIndex.YearOfPublication)
                .Set(m => m.Genre, moviesIndex.Genre)
                .Set(m => m.Type, moviesIndex.Type)
                .Set(m => m.Copies, moviesIndex.Copies);

            collection.UpdateOne(m => m.Id == id, update);
        }

        /// <summary>
        /// Delete a book from the database.
        /// </summary>
        /// <param name="id"> object id of book id</param>
        public void DeleteBookById(ObjectId id)
        {
            var collection = _database.GetCollection<Book>(BOOKS_COLLECTION);
            collection.DeleteOne(b => b.Id == id);
        }

        /// <summary>
        /// Delete a movie from the database.
        /// </summary>
        /// <param name="id">object id  of movie id</param>
        public void DeleteMovieById(ObjectId id)
        {
            var collection = _database.GetCollection<Movie>(Movies_COLLECTION);
            collection.DeleteOne(m => m.Id == id);
        }

        /// <summary>
        /// Saves member to the database
        /// </summary>
        /// <param name="member">members name</param>
        public void SaveMember(Member member)
        {
            var collection = _database.GetCollection<Member>(MEMBERS_COLLECTION);

            collection.InsertOne(member);
        }
        /// <summary>
        /// Gets all members from the database.
        /// </summary>
        /// <returns>list of all members in the database</returns>
        public List<Member> GetMembers()
        {
            var collection = _database.GetCollection<Member>(MEMBERS_COLLECTION);
            var findresult = collection.Find(m => true);
            return findresult.ToList();
        }

        /// <summary>
        /// Gets a member by id. 
        /// </summary>
        /// <param name="id">id of a member</param>
        /// <returns>A member</returns>
        internal Member GetMemberById(ObjectId id)
        {
            var collection = _database.GetCollection<Member>(MEMBERS_COLLECTION);
            return collection.Find(m => m.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Update member to the database
        /// </summary>
        /// <param name="id">member id</param>
        /// <param name="memberName">member name</param>
        /// <param name="age">member age</param>
        /// <param name="address">member address</param>
        internal void UpdateMemberById(ObjectId id,Member member)
        {
            var collection = _database.GetCollection<Member>(MEMBERS_COLLECTION);
            UpdateDefinition<Member> update = Builders<Member>.Update
                .Set(m => m.Name, member.Name)
                .Set(m => m.Age, member.Age)
                .Set(m => m.Address, member.Address);

            collection.UpdateOne(m => m.Id == id, update);

        }

        /// <summary>
        /// Delete a member from the database.
        /// </summary>
        /// <param name="id">object id of members id</param>
        public void DeleteMemberById(ObjectId id)
        {
            var collection = _database.GetCollection<Member>(MEMBERS_COLLECTION);
            collection.DeleteOne(m => m.Id == id);
        }

        /// <summary>
        /// Create a Book Loan in the database
        /// </summary>
        /// <param name="bookId">Article of the loan</param>
        /// <param name="memberId">Member of the loan</param>
        /// <param name="startDate">Startdate of the loan</param>
        /// <param name="endDate">Enddate of the loan</param>
        internal void LoanBook(Book rentedBook, Member memberRenting, DateTime startDate, DateTime endDate)
        {
            Loan loan = new Loan();
            var collection = _database.GetCollection<Loan>(LOANS_COLLECTION);

            loan.MemberRenting = memberRenting;
            loan.BookRented = rentedBook;
            loan.StartDate = startDate;
            loan.EndDate = endDate;
            loan.MovieRented = null;

            collection.InsertOne(loan);


        }

        /// <summary>
        /// Create a Movie Loan in the database
        /// </summary>
        /// <param name="movieId">Article of the loan</param>
        /// <param name="memberId">Member of the loan</param>
        /// <param name="startDate">Startdate of the loan</param>
        /// <param name="endDate">Enddate of the loan</param>
        internal void LoanMovie(Movie rentedBook, Member memberRenting, DateTime startDate, DateTime endDate)
        {
            Loan loan = new Loan();
            var collection = _database.GetCollection<Loan>(LOANS_COLLECTION);

            loan.MemberRenting = memberRenting;
            loan.MovieRented = rentedBook;
            loan.StartDate = startDate;
            loan.EndDate = endDate;
            loan.BookRented = null;

            collection.InsertOne(loan);
        }

        /// <summary>
        /// Prints out a list of loans
        /// </summary>
        /// <returns>list of loans</returns>
        internal List<Loan> GetLoans()
        {
            var collection = _database.GetCollection<Loan>(LOANS_COLLECTION);
            var findresult = collection.Find(l => true);
            return findresult.ToList();
        }

        /// <summary>
        /// Update BookLoan to the database.
        /// </summary>
        /// <param name="articleId">Id of the book</param>
        /// <param name="id">Id of loan</param>
        /// <param name="startDate">When Bookloan starts</param>
        /// <param name="endDate">When Bookloan ends</param>
        internal void UpdateBookLoanById(Book rentedBook, ObjectId id, DateTime startDate, DateTime endDate)
        {
            var collection = _database.GetCollection<Loan>(LOANS_COLLECTION);
            UpdateDefinition<Loan> update = Builders<Loan>.Update
                .Set(b => b.BookRented, rentedBook)
                .Set(b => b.StartDate, startDate)
                .Set(b => b.EndDate, endDate)
                .Set(b => b.MovieRented, null);

            collection.UpdateOne(b => b.Id == id, update);
        }

        /// <summary>
        /// Update MovieLoan to the database.
        /// </summary>
        /// <param name="title">Title of the Movie</param>
        /// <param name="id">Id of the loan</param>
        /// <param name="startDate">When Movieloan starts</param>
        /// <param name="endDate">When Movieloan ends</param>
        internal void UpdateMovieLoanById(Movie rentedMovie, ObjectId id, DateTime startDate, DateTime endDate)
        {
            var collection = _database.GetCollection<Loan>(LOANS_COLLECTION);
            UpdateDefinition<Loan> update = Builders<Loan>.Update
                .Set(m => m.MovieRented, rentedMovie)
                .Set(m => m.StartDate, startDate)
                .Set(m => m.EndDate, endDate)
                .Set(m => m.BookRented, null);

            collection.UpdateOne(m => m.Id == id, update);
        }

        /// <summary>
        /// Delete a loan in the database
        /// </summary>
        /// <param name="id">id of loan</param>
        internal void DeleteBookLoanById(ObjectId id)
        {
            var collection = _database.GetCollection<Loan>(LOANS_COLLECTION);
            collection.DeleteOne(b => b.Id == id);
        }

        /// <summary>
        /// Delete  movieloan in the database
        /// </summary>
        /// <param name="id">id of object</param>
        internal void DeleteMovieLoanById(ObjectId id)
        {
            var collection = _database.GetCollection<Loan>(LOANS_COLLECTION);
            collection.DeleteOne(m => m.Id == id);
        }
    }
}

