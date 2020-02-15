using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository.Models
{
    public class Loan
    {


        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]

        public DateTime StartDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]

        public DateTime EndDate { get; set; }
      

        public Book BookRented { get; set; }

        public Movie MovieRented { get; set; }

        public Member MemberRenting { get; set; }

    }
}
