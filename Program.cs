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
             var projection_testitems = items.Product.Select(n => new
                                        {
                                            product_id = n.id,
                                            product_name = n.name,
                                            product_category_name = n.category.name,
                                            product_price = n.price,
                                            InStock = n.stockQty > 0
                                        }).ToList();

                foreach(var item in projection_testitems)
                {
                    Console.WriteLine($"{item.product_id,-5} {item.product_name,-14} {item.product_category_name,-8} {item.product_price,-9} {item.InStock}");
                }
            }
        }
    }
}
