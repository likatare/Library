using LibraryRepository.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository
{
    public class MemberRepository
    {
        /// <summary>
        /// Saves a member in the database
        /// </summary>
        /// <param name="member">Member of member</param>
        public static void SaveMember(Member member)
        {
            Database db = new Database();
            db.SaveMember(member);
        }

        /// <summary>
        /// Gets a list of members
        /// </summary>
        /// <returns>a list of members</returns>
        public static List<Member> GetMembers()
        {
            Database db = new Database();

            return db.GetMembers();
        }

        public static Member GetMemberById(ObjectId memberId)
        {
            Database db = new Database();
            return db.GetMemberById(memberId);
        }

        /// <summary>
        /// Updates a member in the database
        /// </summary>
        /// <param name="member">Member of member</param>
        public static void UpdateMemberById(ObjectId id,Member member)
        {
            Database db = new Database();

            db.UpdateMemberById(id,member);
        }

        /// <summary>
        /// Deletes a member in the database
        /// </summary>
        /// <param name="member">Member of member</param>
        public static void DeleteMemberById(ObjectId id)
        {
            Database db = new Database();

            db.DeleteMemberById(id);
        }

    }
}
