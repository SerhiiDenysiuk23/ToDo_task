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
        ICategoryRepository categoryRep;
        ViewModel model = new ViewModel();

        public CategoryController(ICategoryRepository repo)
        {
            categoryRep = repo;
        }

        public ActionResult Index()
        {
            model.Categories = categoryRep.GetList();
            return View(model);
        }

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
