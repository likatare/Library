using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository.Models
{
    public abstract class Item
    {

        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int YearOfPublication { get; set; }
        public int Copies { get; set; }


        public Item(string title, string language, int yearOfPublication, int copies)
        {
            Title = title;
            Language = language;
            YearOfPublication = yearOfPublication;
            Copies = copies;
        }

    }



}
