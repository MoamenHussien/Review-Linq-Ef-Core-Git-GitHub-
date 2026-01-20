namespace ConsoleApp1.Entities
{
    public class ClsOrder
    {
        public int id { get; set; }
        public string  CustomerName { get; set; }
        public decimal Total { get; set; }
        public DateTime Createdat { get; set; }
        public ICollection<ClsOrderItem> orderitem { get; set; }
    }
}
