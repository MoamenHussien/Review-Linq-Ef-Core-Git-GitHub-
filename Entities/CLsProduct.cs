using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    public class CLsProduct : I_SoftDelete, I_RowVersion
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int stockQty { get; set; }
        public int categoryid { get; set; }
        public ClsCategory category { get; set; }
        public ICollection<ClsOrderItem> orderItems { get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTime DeletedAt { get ; set ; }
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
