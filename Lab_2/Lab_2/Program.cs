using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Lab_2
{
    public class Catalog
    {
        public int Job_id { get; private set; }
        public string Work_Title { get; private set; }
        public int cost { get; private set; }

        public Catalog() { }

        public Catalog(int Job_id, string Work_Title, int cost)
        {
            this.Job_id = Job_id;
            this.Work_Title = Work_Title;
            this.cost = cost;
        }
    }
    public class Employees
    {
  
        public int Identity_number { get; set; }
        public int Department { get; set; }
        public string? Post { get; set; }
        public int Job_id { get; set; }

        public Catalog catalog { get; private set; }

        public Employees() { }

        public Employees(int Identity_number, int Department, string Post, int Job_id, Catalog catalog)
        {
            this.Identity_number = Identity_number;
            this.Department = Department;
            this.Post = Post;
            this.Job_id = Job_id;
            this.catalog = catalog;
        }
    }





    public class JsonHandler<T> where T : class
    {
        private string fileName;
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };


        public JsonHandler() { }

        public JsonHandler(string fileName)
        {
            this.fileName = fileName;
        }


        public void SetFileName(string fileName)
        {
            this.fileName = fileName;
        }

        public void Write(List<T> list)
        {
            string jsonString = JsonSerializer.Serialize(list, options);

            if (new FileInfo(fileName).Length == 0)
            {
                File.WriteAllText(fileName, jsonString);
            }
            else
            {
                Console.WriteLine("Specified path file is not empty");
            }
        }

        public void Delete()
        {
            File.WriteAllText(fileName, string.Empty);
        }

        public void Rewrite(List<T> list)
        {
            string jsonString = JsonSerializer.Serialize(list, options);

            File.WriteAllText(fileName, jsonString);
        }

        public void Read(ref List<T> list)
        {
            if (File.Exists(fileName))
            {
                if (new FileInfo(fileName).Length != 0)
                {
                    string jsonString = File.ReadAllText(fileName);
                    list = JsonSerializer.Deserialize<List<T>>(jsonString);
                }
                else
                {
                    Console.WriteLine("Specified path file is empty");
                }
            }
        }

        public void OutputJsonContents()
        {
            string jsonString = File.ReadAllText(fileName);

            Console.WriteLine(jsonString);
        }

        public void OutputSerializedList(List<T> list)
        {
            Console.WriteLine(JsonSerializer.Serialize(list, options));
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Employees> partsList = new List<Employees>();

            JsonHandler<Employees> partsHandler = new JsonHandler<Employees>("partsFile.json");

            partsList.Add(new Employees(1, 2, "Builder", 3, new Catalog(1, "Installing insulation", 23000)));
            partsList.Add(new Employees(2, 1, "Manager", 1, new Catalog(2, "Conclusion of the contract", 1200)));
            partsList.Add(new Employees(3, 1, "Designer", 2, new Catalog(2, "design development", 5000)));
            partsList.Add(new Employees(4, 2, "Builder", 3, new Catalog(3, "Demolition of the roof",10000)));
            partsHandler.Rewrite(partsList);
            partsHandler.OutputJsonContents();
        }
    }
}