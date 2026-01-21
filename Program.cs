using ConsoleApp1.Context;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Channels;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var items = new DB_Context()) {
                var top3_revenue = items.OrderItem.GroupBy(n => n.product.category).Select(n => new { categoryName = n.Key, Revenue = n.Sum(n=>n.Qty*n.UnitPrice) }).OrderByDescending(n => n.Revenue).Take(3);
                var tot_paid_grait_th_10000 = items.Order.GroupBy(n => n.CustomerName).Select(n => new { customer_name = n.Key, total = n.Sum(n => n.Total) }).Where(n => n.total > 10000);
                var product_never_ordered = items.Product.Where(n => items.OrderItem.Any(x => x.Productid == n.id)).Select(n => new { Product_id=n.id, product_name=n.name });
                var product_ordered_than_5_times = items.OrderItem.GroupBy(n => new {n.Productid,n.product.name}).Select(n => new { sum_ordered_product = n.Sum(n=>n.Qty),productName =n.Key.name }).Where(n => n.sum_ordered_product > 2);
                foreach (var item in product_ordered_than_5_times)
                {
                    Console.WriteLine($"{item.productName,-9} {item.sum_ordered_product}");
                    // for test fetch
                }
            }
        }
    }
}
