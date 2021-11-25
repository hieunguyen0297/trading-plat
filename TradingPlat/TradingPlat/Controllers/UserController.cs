
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlat.DBManager;
using TradingPlat.Models;

namespace TradingPlat.Controllers
{
    public class UserController : Controller
    {
        private DB db;

        public string SessionKeyName = "_Name";

        public string SessionKeyId = "_Id";

        //Generate a new instance of StockDB in the constructor
        public UserController()
        {
            db = new DB();
        }


        //Display a sign up form
        public IActionResult SignUp()
        {
            return View("SignUpForm");
        }


        //Process signup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessSignUp(UserModel user)
        {
            if (ModelState.IsValid)
            {
                //Find user by email in db, if user exist send a message, if not register the user. 
                UserModel userr = db.FindUserByEmail(user.Email);

                if (userr == null)
                {
                    //Register the user
                    db.RegisterUser(user);
                    //return RedirectToAction("UserRegisterSuccess");
                    //After registered, redirect them to home page
                    return Redirect("/home/index");
                   
                }
                else
                {
                    //Send an error when email is exist in database
                    ViewBag.error = "Email already exists";
                    return View("SignUpForm");
                }
            }

            return View();
        }



        //Send a login form
        public IActionResult SignIn()
        {
            //ViewBag.name = HttpContext.Session.GetString(SessionKeyName);
            //ViewBag.id = HttpContext.Session.GetInt32(SessionKeyId);
            return View("SignInForm");
        }



        //Implement the Sign in process
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessSignIn(UserModel user)
        {
            if (ModelState.IsValid)
            {
                //Find user by email and password in db
                UserModel userr = db.FindUserByEmailAndPassword(user.Email, user.Password);

                if(userr != null)
                {
                    //Establish a session after user signed in
                    HttpContext.Session.SetString(SessionKeyName, userr.FirstName.ToUpper() + " " + userr.LastName.ToUpper());
                    HttpContext.Session.SetInt32(SessionKeyId, userr.UserID);

                    //Find user id in the Accounts table 
                    Account account = db.FindUserInvestingAccountByUserId(userr.UserID);

                    //If account not found in the Accounts table, insert a new record
                    if(account == null)
                    {
                        db.InsertNewAccountIntoAccountsTable(userr.UserID);
                    }

                    //Redirect to home page
                    return Redirect("/home/index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View("SignInForm");
                }
            }
            return View();
            
        }


        //Create Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/home/index");
        }
    }
}
