using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace companymodelapplication.Controllers
{
    public class personController : Controller
    {
        // GET: person
        mydatabaseEntities dbcontext = new mydatabaseEntities();
        public ActionResult addperson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult saveperson(person model)
        {
            person p1 = new person()
            {
                personid = model.personid,
                name = model.name,
                address = model.address,
                salary = model.salary,

            };
            dbcontext.people.Add(p1);
            dbcontext.SaveChanges();
            return RedirectToAction("personlist");
        }
        public ActionResult personlist()
        {
            return View(dbcontext.people.ToList());
        }
        // GET: person/Details/5
        public ActionResult Details(int id)
        {
            return View(dbcontext.people.FirstOrDefault(m=>m.personid==id));
        }

        // GET: person/Create
       
        public ActionResult Edit(int id)
        {
            return View(dbcontext.people.FirstOrDefault(m=>m.personid==id));
        }

        // POST: person/Edit/5
        [HttpPost]
        public ActionResult Edit(person model)
        {
            try
            {
                dbcontext.people.Add(model);
                dbcontext.Entry(model).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();

                

                return RedirectToAction("personlist");
            }
            catch
            {
                return View();
            }
        }

        // GET: person/Delete/5
        public ActionResult Delete(int id)
        {
            return View(dbcontext.people.FirstOrDefault(m=>m.personid==id));
        }

        // POST: person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                person model = dbcontext.people.FirstOrDefault(m => m.personid == id);
                dbcontext.people.Remove(model);
                dbcontext.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("personlist");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult index1()
        {
            return View();
        }
    }
}
