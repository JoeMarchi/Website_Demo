using Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Comments.Controllers
{
    
    public class MemberController : Controller
    {

        private Website_DemoContext db = new Website_DemoContext();

        public ActionResult Register()
        {
            return View();
        }
        private string pwSalt = "abcdefghijklmnopqrstuvwxyz";
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn,AuthCode")]Member member)
        {
            var chk_member = db.Member.Where(p => p.Email == member.Email).FirstOrDefault();
            if (chk_member != null)
            {
                ModelState.AddModelError("Email", "您輸入的Email已經有人註冊過了");
            }
            if (ModelState.IsValid)
            {
                member.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + member.Password, "SHA1");
                member.RegisterOn = DateTime.Now;
                member.AuthCode = Guid.NewGuid().ToString();

                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Login", "Member");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password, string returnUrl)
        {
            if (ValidateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Guestbook");
                }
                else
                {
                    
                    return Redirect(returnUrl);
                }
            }
            var chk_email = db.Member.Where(p => p.Email == email).FirstOrDefault();
            var chk_pw = db.Member.Where(p => p.Password == password).FirstOrDefault();
            if(chk_email!=null)
            {
                if (chk_pw == null)
                {
                    ViewBag.Errormsg = "密碼錯誤";
                }
            }
            else
            {
                ViewBag.Errormsg = "查無此帳號";
            }
            return View();
        }


        private bool ValidateUser(string email, string password)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + password, "SHA1");
            var member = (from p in db.Member
                          where p.Email == email && p.Password == hash_pw
                          select p).FirstOrDefault ();
            return (member != null);
        }
        public ActionResult Logout()
        {
            //清除表單驗證的Cookies
            FormsAuthentication.SignOut();

            //清除所有寫入過的Session 資料
            Session.Clear();
            return RedirectToAction("index","Guestbook");
        }
    }
}
