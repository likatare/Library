using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Movie : Item
    {
        
        public string Genre { get; set; }
        public string Type { get; set; }


        public Movie(string title, string language, int yearOfPublication, int copies, string genre, string type) : base(title, language, yearOfPublication,copies)
        {
            Genre = genre;
            Type = type;
        }

    }
}
