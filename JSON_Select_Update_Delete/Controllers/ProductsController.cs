using JSON_Select_Update_Delete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSON_Select_Update_Delete.Controllers
{
    public class ProductsController : Controller
    {
        leaderContext db = new leaderContext();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products JSON
        public JsonResult GetListProducts()
        {
            var pro = db.Products.ToList();
            return Json(new { data = pro }, JsonRequestBehavior.AllowGet);
        }
       

        [HttpGet]
        // GET: Products JSON
        public ActionResult AddOrEdit(int id = 0)
        {
           
            if (id==0)
            {
                Products products = new Products();
                ViewBag.Cat_id = new SelectList(db.Categories, "Cat_id", "Cat_Name", products.Cat_id);
                return View();
            }
            else
            {
                Products products = db.Products.Where(x => x.Product_id == id).FirstOrDefault<Products>();
                ViewBag.Cat_id = new SelectList(db.Categories, "Cat_id", "Cat_Name", products.Cat_id);
                return View(products);
            }
        }
        //

        [HttpPost]
        // GET: Products JSON
        public ActionResult AddOrEdit(Products pros)
        {
            if (pros.Product_id==0)
            {
                db.Products.Add(pros);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    return Json(new { success = true, msg = "Added Successfly" });

                }
                else
                    return Json(new { success = false, msg = "Failed Added" });
            }
            else
            {
                db.Entry(pros).State = System.Data.Entity.EntityState.Modified;
                int result = db.SaveChanges();
                if (result > 0)
                {
                    return Json(new { success = true, msg = "Update Successfly" });

                }
                else
                    return Json(new { success = false, msg = "Failed Update" });
            }

        }
        //

        public ActionResult Delete(int id)
        {
            Products products = db.Products.Where(x => x.Product_id == id).FirstOrDefault<Products>();
            db.Products.Remove(products);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return Json(new { success = true, msg = "Delete Successfly" });

            }
            else
                return Json(new { success = false, msg = "Delete Failed" });
        }
        //
    }
}