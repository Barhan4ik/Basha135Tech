using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Typeofwork
    {
        [Key]
        public int Typeofwork_Id { get; set; }
        public int Order_number_Id { get; set; }
        public string? Value { get; set; }
        public int Job_Id { get; set; }
        public Orderforobject? Orderforobject { get; set; }
        public Workcatalog? Workcatalog { get; set; }
    }
}