using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManagement.Models;
using ExpenseManagement.DataLayer;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ExpenseManagement.Controllers
{
    public class UserProfileController : Controller
    {
        public readonly DBContextExpMgt _context;

        public UserProfileController(DBContextExpMgt context) {
            _context = context;
        }
        
        public IActionResult Login(string EmailAddress, string Password)
        {
            if(ModelState.Keys.Count() > 0 &&  ModelState.IsValid) {
                var userCheck = _context.UserProfile.FirstOrDefault
                    (a=> a.EmailAddress == EmailAddress && a.Password==Password);

                if (userCheck == null)
                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }


        public IActionResult Registration(UserProfile userDetails)
        {
            if (ModelState.IsValid) {
                _context.UserProfile.Add(userDetails);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
