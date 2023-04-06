using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Client
    {
        [Key]
        public int Client_Id { get; set; }
        public string? Customer_name { get; set; }
        public string? Phone_number { get; set; }
        public List<Orderforobject> GetOrderforobjects(ApplicationContext db)
        {
            return db.Orderforobjects.Where(tr => tr.Client.Client_Id == Client_Id).ToList();
        }
    }
}