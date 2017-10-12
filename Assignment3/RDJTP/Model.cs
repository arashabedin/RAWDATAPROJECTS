using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RDJTP
{
    public class Model
    {
        //Initializing the directory with instances of type Category
        public Dictionary<String, Category> Data = new Dictionary<String, Category>();
        public Model()
        {
           
            Data.Add("/api/categories/1", new Category(1, "Beverages"));
            Data.Add("/api/categories/2", new Category(2, "Condiments"));
            Data.Add("/api/categories/3", new Category(3, "Confections"));
        }

        public Category Create(string path, string name)
        {
            var newCategory = new Category(Data.Count + 1, name);
            Data.Add(path + "/" + newCategory.Id, newCategory);
            return newCategory;
        }

        public Category updateName(string path, string name)
        {
            Data[path].Name = name;
            return Data[path];
        }

        public void Delete(string path)
        {
            Data.Remove(path);
        }

        public Category getPath(string path)
        {
            if (path != null && Data.ContainsKey(path))
            {
                return Data[path];
            }
            else
            {
                return null;
            }
        }

        public List<object> ReadAll()
        {
            return  Data.Select(category=> category.Value).Cast<object>().ToList();
        }
    }


    public class Category
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public Category() { }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}