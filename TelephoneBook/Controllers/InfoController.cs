using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelephoneBook.Models;
namespace TelephoneBook.Controllers
{
    public class InfoController : Controller
    {
        TelephoneBookEntities db = new TelephoneBookEntities();
        public static int idHolder = 0;
        public ActionResult Index(string p)
        {
            var value = from v in db.StaffInformation select v;
            if (!string.IsNullOrEmpty(p))
            {
                value = value.Where(m=>m.Name.Contains(p));
            }
            return View(value.ToList());
            //var info = db.StaffInformation.ToList();
            //return View(info);
        }

        public ActionResult PublicUI()
        {
            var info2 = db.StaffInformation.ToList();
            return View(info2);
        }

        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStaff(StaffInformation staff)
        {

            db.StaffInformation.Add(staff);
            db.SaveChanges();
            return RedirectToAction("Index", "Info");

        }

        public ActionResult Delete(int id)
        {
            var info = db.StaffInformation.Find(id);
            db.StaffInformation.Remove(info);
            db.SaveChanges();
            return RedirectToAction("Index", "Info");
        }

        public ActionResult Update(int id)
        {
            idHolder = id;
            var update = db.StaffInformation.Find(id);

            return View("Update",update);
        }

        public ActionResult Update2(StaffInformation staffUpdate)
        {
            staffUpdate.Staff_ID = idHolder;
            var update = db.StaffInformation.Find(idHolder);
            update.Name = staffUpdate.Name;
            update.Surname = staffUpdate.Surname;
            update.Telephone = staffUpdate.Telephone;
            update.Department = staffUpdate.Department;
            update.Manager = staffUpdate.Manager;
            db.SaveChanges();
            return RedirectToAction("Index", "Info");
        }

    }
}