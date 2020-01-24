using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository.Models
{
  public  class Book : Item
    {
        public int Pages { get; set; }
        public string Author { get; set; }


        public Book(string title, string language, int yearOfPublication,int copies ,int pages, string author) : base(title, language, yearOfPublication,copies)
        {
            Pages = pages;
            Author = author;
            
        }

    }

}
