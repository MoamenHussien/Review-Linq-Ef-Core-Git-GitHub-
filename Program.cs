using ConsoleApp1.Context;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Threading.Channels;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var items = new DB_Context()){
                var eager = items.Order.Include(n => n.orderitem).ThenInclude(n => n.product);
                foreach(var item in eager)
                {
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.CustomerName);
                    foreach(var item2 in item.orderitem)
                    {
                        Console.WriteLine($"The id {item2.Orderid}the quantity is {item2.Qty} The Price is {item2.UnitPrice}");
                        Console.WriteLine(item2.product.id);
                        Console.WriteLine(item2.product.name);
                    }
                }
                             
            }
        }
    }
}
