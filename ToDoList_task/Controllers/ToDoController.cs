using Microsoft.AspNetCore.Mvc;
using ToDoList_task.Models;
using Repositories.IRepositories;
using Repositories.Repositories;
using Repositories.Items;

namespace ToDoList_task.Controllers
{
    public class ToDoController : Controller
    {
        private const string connectionStr = "Data Source=DESKTOP-6NLB2FU;Initial Catalog=sanaTask;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        IToDoRepository toDoRep;
        ICategoryRepository categoryRep;
        ViewModel _model = new ViewModel();

        public ToDoController()
        {
            switch ("SQL")
            {
                case "SQL":
                default:
                    {
                        toDoRep = new SQLToDoListRepository(connectionStr);
                        categoryRep = new SQLCategoryRepository(connectionStr);
                    }
                    break;
                case "XML":
                    toDoRep = new XMLToDoRepository(@"C:\xmlData\ToDoList.xml");
                    break;
            } 
        }

        public ActionResult Index()
        {
            try
            {
                _model.ToDoList = toDoRep.GetList();
                _model.Categories = categoryRep.GetList();
                return View(_model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Create");
            }
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

    }
}
