using Repositories.IRepositories;
using Repositories.Items;
using System.Xml;
using System.Xml.Linq;

namespace Repositories.Repositories
{
    public class XMLToDoRepository : IToDoRepository
    {
        public string filePath;

        public XMLToDoRepository(string path)
        {
            filePath = path;
        }

        public void Create(ToDo toDo)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement toDoList = doc.Element("ToDoList");

            toDoList.Add(new XElement("ToDo",
                    new XAttribute("Id", DateTime.Now.Ticks % 1000000000),
                    new XElement("Text", toDo.Text),
                    new XElement("Description", toDo.Description),
                    new XElement("Deadline",  toDo.Deadline.ToString()),
                    new XElement("IsComplete", toDo.IsComplete),
                    new XElement("CategoryId", toDo.CategoryId)
                ));
            doc.Save(filePath);
        }

        public void Delete(int id)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement toDoList = doc.Element("ToDoList");
            var toDo = toDoList.Elements("ToDo").FirstOrDefault(t => t.Attribute("Id").Value == id.ToString());
            toDo.Remove();
            doc.Save(filePath);
        }

        public ToDo Get(int id)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement toDoList = doc.Element("ToDoList");
            foreach (var item in toDoList.Elements("ToDo"))
                if (item.Attribute("Id").Value == id.ToString())
                {
                    ToDo itemToDo = new ToDo();
                    itemToDo.Id = Convert.ToInt32(item.Attribute("Id").Value);
                    itemToDo.Text = Convert.ToString(item.Element("Text").Value);

                    itemToDo.Description = Convert.ToString(item?.Element("Description").Value);
                    itemToDo.IsComplete = Convert.ToBoolean(item?.Element("IsComplete").Value);

                    int categId;
                    if (int.TryParse(item?.Element("CategoryId").Value, out categId))
                        itemToDo.CategoryId = categId;
                    DateTime dt;
                    if (DateTime.TryParse(item?.Element("Deadline").Value, out dt))
                        itemToDo.Deadline = dt;
                    return itemToDo;
                }
            return null;
        }

        public List<ToDo> GetList() {
            XDocument doc = XDocument.Load(filePath);
            var list = new List<ToDo>();

            XElement toDoList = doc.Element("ToDoList");
            if (toDoList == null)
                return null;

            foreach (XElement item in toDoList.Elements("ToDo"))
            {
                ToDo newTask = new ToDo();
                newTask.Id = Convert.ToInt32(item.Attribute("Id").Value);
                newTask.Text = Convert.ToString(item.Element("Text").Value);

                newTask.Description = Convert.ToString(item?.Element("Description").Value);
                newTask.IsComplete = Convert.ToBoolean(item?.Element("IsComplete").Value);

                int categId;
                if (int.TryParse(item?.Element("CategoryId").Value, out categId))
                    newTask.CategoryId = categId;
                DateTime dt;
                if (DateTime.TryParse(item?.Element("Deadline").Value, out dt))
                    newTask.Deadline = dt;

                list.Add(newTask);
            }
            return list;
        }

        public void Update(ToDo toDo)
        {
            XDocument doc = XDocument.Load(filePath);
            var updatedToDo = doc.Element("ToDoList").Elements("ToDo").FirstOrDefault(t => t.Attribute("Id").Value == toDo.Id.ToString());

            updatedToDo.Element("Text").Value = toDo.Text.ToString();
            updatedToDo.Element("Description").Value = toDo.Description.ToString();
            updatedToDo.Element("Deadline").Value = toDo.Deadline.ToString();
            updatedToDo.Element("IsComplete").Value = toDo.IsComplete.ToString();
            updatedToDo.Element("CategoryId").Value = toDo.CategoryId.ToString();

            doc.Save(filePath);
        }

        public void UpdateState(ToDo toDo)
        {
            XDocument doc = XDocument.Load(filePath);
            var updatedToDo = doc.Element("ToDoList").Elements("ToDo").FirstOrDefault(t => t.Attribute("Id").Value == toDo.Id.ToString());
            updatedToDo.Element("IsComplete").Value = toDo.IsComplete.ToString();
            doc.Save(filePath);
        }
    }
}
