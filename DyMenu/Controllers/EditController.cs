using DyMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DyMenu.Controllers
{
    public class EditController : Controller
    {
        DyMenuEntities db = new DyMenuEntities();
        // GET: Edit

        // display 2 model in one view by viewModel.cs
        public ActionResult Edit()
        {
            var mainmenu = MainMenuList();
            var submenu = SubMenuList();

            viewModel vm = new viewModel();

            vm.Mm = mainmenu;
            vm.Sm = submenu;

            return View(vm);
        }

        public List<MainMenu> MainMenuList()
        {
            return db.MainMenus.ToList();

        }
        public List<SubMenu> SubMenuList()
        {

            return db.SubMenus.ToList();
        }

        public ActionResult addNew() //SubMenu child
        {
            return View();
        }
        // end of viewModel.cs
        [HttpPost]
        public ActionResult addNew(MainMenu parent) //SubMenu child
        {

            MainMenu mainMenuObj = new MainMenu();
            //SubMenu subMenuObj = new SubMenu();

            // Add into mainMenu Parent 
            mainMenuObj.MenuName = parent.MenuName;
            mainMenuObj.MenuUrl = parent.MenuUrl;
            mainMenuObj.SubMenus = parent.SubMenus;

            // final save in db 
            db.MainMenus.Add(mainMenuObj);
            db.SaveChanges();


            return View();
        }


    }
}