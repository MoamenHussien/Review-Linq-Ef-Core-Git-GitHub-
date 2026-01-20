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
            using (var items = new DB_Context()){
                string want;
                do
                {
                    int page_size = 5;
                    int products_size = items.Product.Count();
                    decimal pages_num = Math.Ceiling( (decimal) products_size / page_size);

                    Console.WriteLine($"Enter The Page index you want from 1 to {pages_num} :");
                    byte page_index = byte.Parse(Console.ReadLine());
                    Console.WriteLine();

                    var pagging = items.Product.Skip((page_index-1) * page_size).Take(page_size);
                    foreach(var item in pagging)
                    {
                        Console.WriteLine(item.name    , item.price);
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Do you Want another pagging Y or N ? :");
                     want = Console.ReadLine();
                    Console.Clear();
                }
                while (want=="Y");
            }
        }
    }
}
