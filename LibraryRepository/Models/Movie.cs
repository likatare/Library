using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository.Models
{
  public  class Movie : Item
    {
        
        public string Genre { get; set; }
        public string Type { get; set; }

        public Movie()
        {

        }

        public Movie(string title, string language, int yearOfPublication, int copies, string genre, string type) : base(title, language, yearOfPublication,copies)
        {
            Genre = genre;
            Type = type;
        }

    }
}
