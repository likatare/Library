using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryRepository.Models
{
    public class Loan
    {


        public ObjectId Id { get; set; }



        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


        public Book BookRented { get; set; }

        public Movie MovieRented { get; set; }

        public Member MemberRenting { get; set; }

        public Loan()
        {

        }


        public Loan(DateTime startDate,DateTime endDate, Member member, Book book )
        {
            StartDate = startDate;
            EndDate = endDate;
            MemberRenting = member;
            BookRented = book;

            
        }


        public Loan(DateTime startDate, DateTime endDate, Member member, Movie movie)
        {
            StartDate = startDate;
            EndDate = endDate;
            MemberRenting = member;
            MovieRented = movie;


        }
    }
}
