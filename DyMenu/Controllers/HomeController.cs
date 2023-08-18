using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DyMenu.Models;

namespace DyMenu.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            using (var db = new DyMenuEntities())
            {
                var data= db.MainMenus.Include(c => c.SubMenus).ToList();
               return View(data);
            }
        }

        public List<MainMenu> getMnus()
        {
            List < MainMenu > mn = new List<MainMenu>();
            return (mn);
        }

    }
}