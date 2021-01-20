using CarTry.App.Abstract;
using CarTry.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CarTry.App.Concrete
{
    public class DataService : IDataService<Item>
    {
        public List<Item> LoadXMLData(string nameFileToLoad)
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Cars";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Item>), root);
            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", nameFileToLoad);

            string xml = File.ReadAllText(filePath);
            StringReader stringReader = new StringReader(xml);
            var xmlItems = (List<Item>)(xmlSerializer.Deserialize(stringReader));
            return xmlItems;
        }

        public void SaveXMLData(string nameFileToSave, List<Item> list)
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Cars";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Item>), root);
            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", nameFileToSave);
            using StreamWriter sw = new StreamWriter(filePath);
            xmlSerializer.Serialize(sw, list);
        }
        public List<string> LoadJsonData(string fileName)
        {
            string jsonFilePath = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            List<string> myObject;
            using (StreamReader sr = File.OpenText(jsonFilePath))
                myObject = JsonConvert.DeserializeObject<List<string>>(sr.ReadToEnd());
            return myObject;
        }


        public void SaveJsonData(string nameFileToSave, List<Item> list)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\", nameFileToSave+".txt");
            using StreamWriter sw = new StreamWriter(filePath);
            using JsonWriter writer = new JsonTextWriter(sw);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, list);

        }
    }
}


