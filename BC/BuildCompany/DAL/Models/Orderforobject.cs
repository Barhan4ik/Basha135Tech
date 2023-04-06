using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Orderforobject
    {

        [Key]
        public int Order_number_Id { get; set; }
        public DateTime Order_date { get; set; }
        public int Client_Id { get; set; }
        public string? Address_of_the_object { get; set; }
        public DateTime Execution_date { get; set; }
        public string? Contract_number { get; set; }
        public int Masteremployee_Id { get; set; }
        public int Designeremployee_Id { get; set; }
        public int Design_Id { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public Designproject? Designproject { get; set; }
        public List<Typeofwork> GetTypeofworks(ApplicationContext db)
        {
            return db.Typeofworks.Where(tr => tr.Orderforobject.Order_number_Id == Order_number_Id).ToList();
        }
        public List<OrderLine> GetOrderLines(ApplicationContext db)
        {
            return db.OrderLines.Where(tr => tr.Orderforobject.Order_number_Id == Order_number_Id).ToList();
        }
    }
}