using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Entities
{
    public class ClsCategory : I_SoftDelete
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<CLsProduct>? product { get; set; } = new List<CLsProduct>();
        public bool IsDeleted { get ; set ; }
        public DateTime DeletedAt { get ; set ; }
    }


}
