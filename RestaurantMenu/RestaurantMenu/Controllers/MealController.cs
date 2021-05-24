using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantMenu.Models;
using System.Web.Mvc;

namespace RestaurantMenu.Controllers
{
    public class MealController : Controller
    {
        // GET: Meal
        public ActionResult Index()
        {
            RestaurantMenuContext db = new RestaurantMenuContext();
            return View(db.Meal.ToList());
        }

        //Vista parcial para mostrar los ingredientes de una comida cuando todas son listadas
        public ActionResult MealIngrediants(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                List<MealIngredient> lista = db.MealIngredient.Where(a => a.id_Meal == id).ToList();
                return PartialView(lista);
            }
        }
        //Obtener el nombre de cada ingrediente
        public static string NombreIngrediente(int id_ingredient)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Ingredient.Find(id_ingredient).Name;
            }
        }

        //Obtener imagen de Meal
        public static string MealImage(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Meal.Find(id).Image;
            }
        }
        
        //Obtener nombre de la categoria
        public static string MealName(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Meal.Find(id).Name;
            }
        }
        //Obtener el nombre del Area
        public static string AreaName(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Area.Find(id).Name;
            }
        }

        //Vista parcial para ver los tags de cad Meal
        public ActionResult AllMealsTags(int id)
        {
            using (var db = new RestaurantMenuContext())
            {
                List<MealTag> tags = db.MealTag.Where(a => a.id_Meal == id).ToList();
                return PartialView(tags);
            }
        }
        //Obtener nombre de cada Tag
        public static string NameTag(int id_tag)
        {
            using (var db = new RestaurantMenuContext())
            {
                return db.Tag.Find(id_tag).Name;
            }
        }


    }
}