using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantMenu.Models;
using System.Web.Mvc;

namespace RestaurantMenu.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            RestaurantMenuContext db = new RestaurantMenuContext();
            return View(db.Category.ToList());
        }
        public static string CategoryImage(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Category.Find(id).Image;
            }
        }
        public static string CategoryName(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Category.Find(id).Name;
            }
        }
        //Detalles de Meal
        public ActionResult DetallesMeal(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                Meal meal = db.Meal.Find(id);
                return View(meal);
            }
        }
        
    }
}