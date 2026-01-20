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

                var q_one = items.Category.Where(n => n.name.StartsWith("ph"));
                var q_two = items.Product.Where(n=>n.price>=500 && n.price<=5000);
                var q_three = items.Product.OrderBy(n => n.price).ThenBy(n => n.name);


                foreach (var item in q_three)
                {
                    Console.WriteLine($"{item.name}    {item.price}");
                }
            }
        }
    }
}
