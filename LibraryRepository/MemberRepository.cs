using LibraryRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRepository
{
    public class MemberRepository
    {
        public static void SaveMember(Member member)
        {
            Database db = new Database();
            db.SaveMember(member);
        }

        public static List<Member> GetMembers()
        {
            Database db = new Database();

            return db.GetMembers();
        }

        public static void UpdateMemberById(Member member)
        {
            Database db = new Database();

            db.UpdateMemberById(member);
        }
        public static void DeleteMemberById(Member member)
        {
            Database db = new Database();

            db.DeleteMemberById(member.Id);
        }

    }
}
