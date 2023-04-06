using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Workcatalog
    {
        [Key]
        public int Workcatalog_Id { get; set; }
        public string Name { get; set; }
        public int Pricework { get; set; }
        public List<Typeofwork> GetTypeofworks(ApplicationContext db)
        {
            return db.Typeofworks.Where(tr => tr.Workcatalog.Workcatalog_Id == Workcatalog_Id).ToList();
        }
    }
}