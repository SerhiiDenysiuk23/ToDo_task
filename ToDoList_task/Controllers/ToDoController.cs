using Microsoft.AspNetCore.Mvc;
using ToDoList_task.Models;
using Repositories.IRepositories;
using Repositories.Repositories;
using Repositories.Items;

namespace ToDoList_task.Controllers
{
    public class ToDoController : Controller
    {
        IToDoRepository toDoRep;
        ICategoryRepository categoryRep;
        ViewModel _model = new ViewModel();

        public ToDoController(IToDoRepository toDoRep, ICategoryRepository categoryRep)
        {
            this.toDoRep = toDoRep;
            this.categoryRep = categoryRep;
        }

        public ActionResult Index()
        {
                _model.ToDoList = toDoRep.GetList();
                _model.Categories = categoryRep.GetList();
                return View(_model);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = categoryRep.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDo toDo)
        {
            toDoRep.Create(toDo);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ToDo toDo = toDoRep.Get(id);
            if (toDo != null)
            {
                ViewBag.Categories = categoryRep.GetList();
                return View(toDo);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(ToDo toDo)
        {
            toDoRep.Update(toDo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            ToDo toDo = toDoRep.Get(id);
            if (toDo != null)
                return View(toDo);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            toDoRep.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangeFlag(int changeFlag)
        {
            FlagValue.CurrValue = changeFlag;
            return RedirectToAction("Index");
        }

    }
}
