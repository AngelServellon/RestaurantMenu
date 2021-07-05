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
            return View(db.Ingredient.ToList());
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
                List<MealIngredient> meals = db.MealIngredient.Where(m => m.id_Ingredient == id).ToList();
                return View(meals);
            }
        }
        //Crear un nuevo ingrediente-------------------------------------------------
        public ActionResult CrearIngrediente()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearIngrediente(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                using (var db = new RestaurantMenuContext())
                {
                    db.Ingredient.Add(ingredient);
                    db.SaveChanges();
                    return RedirectToAction("AgregarIngredientes", "Meal");

                }
            }
            else
            {
                return View();
            }
        }
    }
}