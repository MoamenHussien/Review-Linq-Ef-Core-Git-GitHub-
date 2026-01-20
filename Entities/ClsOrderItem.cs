namespace ConsoleApp1.Entities
{
    public class ClsOrderItem
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public ClsOrder order { get; set; }
        public CLsProduct product { get; set; }
    }
}
