using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepositories;
using Repositories.Repositories;
using Repositories.Items;
using ToDoList_task.Models;

namespace ToDoList_task.Controllers
{
    public class CategoryController : Controller
    {
        private const string connectionStr = "Data Source=DESKTOP-6NLB2FU;Initial Catalog=sanaTask;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        ICategoryRepository categoryRep;
        ViewModel model = new ViewModel();

        public CategoryController()
        {
            switch (0)
            {
                case 0:
                default:
                    categoryRep = new SQLCategoryRepository(connectionStr);
                    break;
                //case 1:
                //    categoryRep = new XMLToDoRepository(@"C:\xmlData\ToDoList.xml");
                //    break;
            }
        }

        public ActionResult Index()
        {
            model.Categories = categoryRep.GetList();
            return View(model);
        }

        //public ActionResult Create()
        //{
        //    return View("Index");
        //}

        [HttpPost]
        public ActionResult Index(Category category)
        {
            model.Category = category;
            categoryRep.Create(model.Category);
            return RedirectToAction();
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Category category = categoryRep.Get(id);
            if (category != null)
                return View(category);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            categoryRep.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
