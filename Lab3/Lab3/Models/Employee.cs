namespace Lab3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int Identity_number { get; set; }
        public int Department { get; set; }
        public string? Post { get; set; }

        public int Job_id { get; set; }

        public Catalog catalog { get; set; }
    }
}
    
