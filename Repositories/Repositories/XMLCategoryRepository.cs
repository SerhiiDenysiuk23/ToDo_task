using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repositories.IRepositories;
using Repositories.Items;
using System.Xml;
using System.Xml.Linq;

namespace Repositories.Repositories
{
    public class XMLCategoryRepository : ICategoryRepository
    {
        public string filePath;

        public XMLCategoryRepository(string path)
        {
            filePath = path;
        }

        public void Create(Category category)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement CategoryList = doc.Element("CategoryList");

            CategoryList.Add(new XElement("Category",
                    new XAttribute("Id", DateTime.Now.Ticks % 1000000000),
                    new XElement("Text", category.Name)
                ));
            doc.Save(filePath);
        }

        public void Delete(int id)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement CategoryList = doc.Element("CategoryList");
            var category = CategoryList.Elements("Category").FirstOrDefault(t => t.Attribute("Id").Value == id.ToString());
            category.Remove();
            doc.Save(filePath);
        }

        public Category Get(int id)
        {
            XDocument doc = XDocument.Load(filePath);
            XElement CategoryList = doc.Element("CategoryList");
            foreach (var item in CategoryList.Elements("Category"))
                if (item.Attribute("Id").Value == id.ToString())
                {
                    Category itemCategory = new Category();
                    itemCategory.Id = Convert.ToInt32(item.Attribute("Id").Value);
                    itemCategory.Name = Convert.ToString(item.Element("Name").Value);

                    return itemCategory;
                }
            return null;
        }

        public List<Category> GetList()
        {
            XDocument doc = XDocument.Load(filePath);
            var list = new List<Category>();

            XElement CategoryList = doc.Element("CategoryList");
            if (CategoryList == null)
                return null;

            foreach (XElement item in CategoryList.Elements("Category"))
            {
                Category newCategory = new Category();
                newCategory.Id = Convert.ToInt32(item.Attribute("Id").Value);
                newCategory.Name = Convert.ToString(item.Element("Text").Value);
                list.Add(newCategory);
            }
            return list;
        }

        public void Update(Category category)
        {
            XDocument doc = XDocument.Load(filePath);
            var updatedCategory = doc.Element("CategoryList").Elements("Category").FirstOrDefault(t => t.Attribute("Id").Value == category.Id.ToString());

            updatedCategory.Element("Name").Value = category.Name.ToString();

            doc.Save(filePath);
        }
    }
}
