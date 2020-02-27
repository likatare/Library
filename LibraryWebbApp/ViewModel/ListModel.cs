using LibraryRepository;
using LibraryRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebbApp.Models
{
    public class ListModel
    {
        public List<Member> MemberList = MemberRepository.GetMembers();
        public List<Book> BookList = BookRepository.GetBooks();
        public List<Movie> MovieList = MovieRepository.GetMovies();
        public Loan Loan { get; set; }
        public string ErrorMessage { get; set; }



    }
}
