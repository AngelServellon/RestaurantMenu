using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantMenu.Models;
using System.Web.Mvc;

namespace RestaurantMenu.Controllers
{
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            RestaurantMenuContext db = new RestaurantMenuContext();
            return View(db.MealIngredient.ToList());
        }
        //Obtener imagen del ingrediente
        public static string IngredientImage(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Ingredient.Find(id).Image;
            }
        }
        //Obtener nombre del ingrediente
        public static string IngredientName(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Ingredient.Find(id).Name;
            }
        }
        //Obtener las comidas que coincidan con un ingredienete
        public ActionResult IngredientMeals(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                List<Meal> meals = db.Meal.Where(m => m.Id_Meal == id).ToList();
                return View(meals);
            }
        }
    }
}