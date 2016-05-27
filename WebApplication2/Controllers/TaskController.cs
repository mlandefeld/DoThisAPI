using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TaskController : Controller
    {
        private DoThisEntities1 db = new DoThisEntities1();

        public ActionResult index()
        {
            List<task> tasks = this.db.tasks.ToList();

            return Json(tasks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult show(int id)
        {
            var task = this.db.tasks.Where(t => t.TaskID.Equals(id)).ToList();

            return Json(task, JsonRequestBehavior.AllowGet);
        }

        public ActionResult create()
        {
            var task = db.tasks.Add(new task
            {
                Description = Request.QueryString["description"],
                Created = System.DateTime.Now,
                Updated = System.DateTime.Now,
                Complete = false
            });
            db.SaveChanges();
            
            return Json(task, JsonRequestBehavior.AllowGet);
        }

        public ActionResult update(int id)
        {
            var task = this.db.tasks.Where(t => t.TaskID.Equals(id)).First();

            string description = Request.QueryString["description"];
            string complete = Request.QueryString["complete"];


            if (description != null)
            {
                task.Description = description;
            }

            if(complete != null)
            {
                task.Complete = bool.Parse(complete);//TODO: handle invalid user input
            }

            task.Updated = System.DateTime.Now;
            

            db.SaveChanges();

            return Json(task, JsonRequestBehavior.AllowGet);
        }

        public ActionResult delete(int id)
        {
            var task = this.db.tasks.Where(t => t.TaskID.Equals(id)).First();

            db.tasks.Remove(task);
            db.SaveChanges();

            return Json("delete successful", JsonRequestBehavior.AllowGet);
        }


    }
}
