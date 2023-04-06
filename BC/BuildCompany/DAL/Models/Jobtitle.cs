using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Jobtitle
    {
        [Key]
        public int Job_Id { get; set; }
        public string Job_Title { get; set; }
        public List<Employee> GetEmployees(ApplicationContext db)
        {
            return db.Employees.Where(tr => tr.Jobtitle.Job_Id == Job_Id).ToList();
        }
    }
}