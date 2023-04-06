using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Designproject
    {
        [Key]
        public int Design_project_Id { get; set; }
        public int Employee_id { get; set; }
        public Employee? Employee { get; set; }
        public List<Orderforobject> GetOrderforobjects(ApplicationContext db)
        {
            return db.Orderforobjects.Where(tr => tr.Designproject != null && tr.Designproject.Design_project_Id == Design_project_Id).ToList();
        }
    }
}