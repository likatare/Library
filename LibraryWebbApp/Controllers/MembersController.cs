using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryRepository;
using LibraryRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace LibraryWebbApp.Controllers
{
    public class MembersController : Controller
    {
       /// <summary>
       /// Gets all members from the database.
       /// </summary>
       /// <returns>A list of members</returns>
        public ActionResult Index()
        {
            List<Member> members = MemberRepository.GetMembers();

            return View(members);
        }

        /// <summary>
        /// Gets a member by id from the database
        /// </summary>
        /// <param name="id">Member id</param>
        /// <returns>A member</returns>
        public ActionResult Details(string id)
        {
            ObjectId memberId = new ObjectId(id);

            Member member = MemberRepository.GetMemberById(memberId);

            return View(member);
        }

        /// <summary>
        /// Show a Create form
        /// </summary>
        /// <returns>The form View</returns>
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Gets all member values and create the member in the database.
        /// </summary>
        /// <param name="member"></param>
        /// <returns>To index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                //Validate member values

                MemberRepository.SaveMember(member);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Gets a member from database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return a member</returns>
        public ActionResult Edit(string id)
        {
            ObjectId memberId = new ObjectId(id);
            Member member = MemberRepository.GetMemberById(memberId);

            return View(member);
        }

        /// <summary>
        /// Gets a new value and update that member in database.
        /// </summary>
        /// <param name="id">id of the member</param>
        /// <param name="member">Member of member</param>
        /// <returns>Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Member member)
        {
            try
            {
                ObjectId memberId = new ObjectId(id);
                MemberRepository.UpdateMemberById(memberId,member);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Gets a member from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a member to the View</returns>
        public ActionResult Delete(string id)
        {
            ObjectId memberId = new ObjectId(id);

            Member member = MemberRepository.GetMemberById(memberId);

            return View(member);
        }

        /// <summary>
        /// Deletes a member in the database.
        /// </summary>
        /// <param name="id">id of the member</param>
        /// <param name="collection"></param>
        /// <returns>Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                ObjectId memberId = new ObjectId(id);
                MemberRepository.DeleteMemberById(memberId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}