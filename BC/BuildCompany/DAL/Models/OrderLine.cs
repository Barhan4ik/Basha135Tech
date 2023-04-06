using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class OrderLine
    {
        [Key]
        public int OrderLine_Id { get; set; }
        public int Order_number_Id { get; set; }
        public int Quantity { get; set; }
        public int Item_Id { get; set; }
        public Product? Product { get; set; }
        public Orderforobject? Orderforobject { get; set; }
    }
}