using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Employees_last_name { get; set; }
        public int Jobtitle_Id { get; set; }
        public Jobtitle? Jobtitle { get; set; }
        public List<Orderforobject> GetOrderforobjects(ApplicationContext db)
        {
            return db.Orderforobjects.Where(tr => tr.Employee.Employee_Id == Employee_Id).ToList();
        }
        public List<Designproject> GetDesignprojects(ApplicationContext db)
        {
            return db.Designprojects.Where(tr => tr.Employee.Employee_Id == Employee_Id).ToList();
        }
    }
}