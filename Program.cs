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

               var join_test = items.OrderItem.AsNoTracking().Select(n => new {order_id =n.Orderid,product_name =n.product.name,category_name =n.product.category.name , Subtotal=n.Qty*n.UnitPrice });
                foreach(var item in join_test)
                {
                    Console.WriteLine($"{item.order_id,-5}{item.product_name,-13} {item.category_name,-8} {item.Subtotal,-5}");
                }
            }
        }
    }
}
