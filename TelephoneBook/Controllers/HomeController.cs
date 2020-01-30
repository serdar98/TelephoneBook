using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelephoneBook.Models;
using System.Data.SqlClient;
namespace TelephoneBook.Controllers
{
    public class HomeController : Controller
    {
        private TelephoneBookEntities db = new TelephoneBookEntities();
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(loginAdmin objUser)
        {
            if (ModelState.IsValid)
            {
                
                {
                    var obj = db.loginAdmin.Where(a => a.adminUsername.Equals(objUser.adminUsername) && a.adminPassword.Equals(objUser.adminPassword)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["adminUserID"] = obj.adminUserID.ToString();
                        Session["adminUsername"] = obj.adminUsername.ToString();
                        return RedirectToAction("Index","Info");
                    }
                    else
                    {
                        ModelState.AddModelError("adminUsername", "Kullanıcı Adınız Yanlış");
                        ModelState.AddModelError("adminPassword", "Şifreniz Yanlış");
                        return View("Login");
                    }
                }
            }
            return View(objUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StaffLogin(StaffLogin objStaff)
        {
            if (ModelState.IsValid)
            {

                {
                    var obj = db.StaffLogin.Where(a => a.staffUsername.Equals(objStaff.staffUsername) && a.staffPassword.Equals(objStaff.staffPassword)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["staffUserID"] = obj.staffUserID.ToString();
                        Session["staffUsername"] = obj.staffUsername.ToString();
                        return RedirectToAction("PublicUI","Info");
                    }
                    else
                    {
                        ModelState.AddModelError("staffUsername", "Kullanıcı Adınız Yanlış");
                        ModelState.AddModelError("staffPassword", "Şifreniz Yanlış");
                        return View("StaffLogin");
                    }
                }
            }
            return View(objStaff);
        }
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult StaffLogin()
        {
            return View();
        }

    }
}