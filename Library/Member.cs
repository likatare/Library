using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Member
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public Member(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }


    }



}
