using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Product
    {
        [Key]
        public int Item_Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public List<OrderLine> GetOrderLines(ApplicationContext db)
        {
            return db.OrderLines.Where(tr => tr.Product.Item_Id == Item_Id).ToList();
        }
    }
}