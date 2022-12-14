namespace Lab3.Models
{
    public class Typeofwork
    {
        public int Id { get; set; }
        public int Order_number { get; set; }
        public int Job_line_number { get; set; }
        public string? Value { get; set; }

        public int Job_id { get; set; }

        public Workcatalog workcatalog { get; set; }
    }
}
    
