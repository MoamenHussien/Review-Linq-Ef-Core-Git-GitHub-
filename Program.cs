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

                var count = items.Product.GroupBy(n => n.categoryid).Select(x => new { CategoryName = items.Category.First(n => n.id == x.Key).name, Prodcut_count = x.Count() });
                var avgprice = items.Product.GroupBy(n => n.categoryid).Select(x => new {CategoryName =items.Category.First(n=>n.id==x.Key).name,AvgPrice =x.Average(n=>n.price) });
                var MaxPrice = items.Product.GroupBy(n => n.categoryid).Select(x => new {CategoryName =items.Category.First(n=>n.id==x.Key).name,MaxPrice =x.Max(n=>n.price) });
                var TotalStockQty = items.Product.GroupBy(n => n.categoryid).Select(x => new {CategoryName =items.Category.First(n=>n.id==x.Key).name,TotalQty =x.Sum(n=>n.stockQty) });


                foreach(var item in TotalStockQty)
                {
                    Console.WriteLine($"{item.CategoryName,-15}     {item.TotalQty}") ;
                }
            }
        }
    }
}
