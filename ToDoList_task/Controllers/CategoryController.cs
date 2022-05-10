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

        public CategoryController()
        {
            switch (Flag.value)
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
            return View(categoryRep.GetList());
        }

        public ActionResult Create()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryRep.Create(category);
            return RedirectToAction("Index");
        }


    }
}
