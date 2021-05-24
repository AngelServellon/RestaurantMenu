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
        //Obtener  la imagen de la categoria
        public static string CategoryImage(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Category.Find(id).Image;
            }
        }
        //Obtener nombre de la categoria
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
        //Mostra Meals segun su categoria
        public ActionResult CategoryMeals(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                List<Meal> meals = db.Meal.Where(a => a.id_Category == id).ToList();
                return View(meals);
            }
        }


        //Vista parcial para mostrar los ingredientes de una comida
        public ActionResult SpecificMealIngredients(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                List<MealIngredient> lista = db.MealIngredient.Where(a => a.id_Meal == id).ToList();
                return PartialView(lista);
            }
        }

        //Vista parcial para ver los tags de un Meal
        public ActionResult MealTags(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                List<MealTag> tags = db.MealTag.Where(a => a.id_Meal == id).ToList();
                return PartialView(tags);
            }
        }
        
    }
}