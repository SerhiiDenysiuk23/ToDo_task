using Repositories.IRepositories;
using Repositories.Items;
using System.Xml;

namespace Repositories.Repositories
{
    public class XMLToDoRepository : IToDoRepository
    {
        XmlDocument xmlDoc;
        XmlElement? xmlRoot;

        public XMLToDoRepository(string path)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(path);
            xmlRoot = xmlDoc.DocumentElement;
        }

        public void Create(ToDo toDo)
        {
            xmlDoc.CreateElement("Id").InnerText = Convert.ToString(toDo.Id);
            //xmlDoc.CreateAttribute("Id").Value = Convert.ToString(toDo.Id);
            //xmlDoc.CreateAttribute("Text").Value = toDo.Text;
            //xmlDoc.CreateAttribute("Description").Value = toDo.Description;
            //xmlDoc.CreateAttribute("IsComplete").Value = Convert.ToString(toDo.IsComplete);
            //xmlDoc.CreateAttribute("Deadline").Value = Convert.ToString(toDo.Deadline);
            //xmlDoc.CreateAttribute("CategoryId").Value = Convert.ToString(toDo.CategoryId);
        }

        public void Delete(int id)
        {

        }
        public ToDo Get(int id)
        {
            return null;
        }
        public List<ToDo> GetList() { 
            return null; 
        }
        public void Update(ToDo toDo)
        {

        }
        public void UpdateState(ToDo toDo)
        {

        }
    }
}
