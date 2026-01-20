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

                using (var tran_items = items.Database.BeginTransaction())
                {
                    CLsProduct product = null;
                    int product_id;
                    do
                    {
                        Console.WriteLine("Please enter Product id :");
                         product_id = int.Parse(Console.ReadLine());
                         product = items.Product.Find(product_id);
                    }
                    while(product == null);
                    Console.WriteLine("Please enter How much you want :");
                    int product_want_num = int.Parse(Console.ReadLine());

                    if (product.stockQty >= product_want_num)
                    {
                        product.stockQty -=product_want_num;
                    }
                    else
                    {
                        Console.WriteLine("the stock is small then you want ");
                        return;
                    }

                    var order_items_list = new List<ClsOrderItem>()
                    {
                        new ClsOrderItem
                        {
                            Productid = product.id,
                            UnitPrice =product.price,
                            Qty=product_want_num
                        }
                    };

                    
                    decimal total = order_items_list.Sum(n => n.Qty * n.UnitPrice);



                    var order = new ClsOrder
                    {

                        CustomerName = "Moamen Hussien",
                        Createdat = DateTime.Now,
                        Total = total,
                        orderitem = order_items_list

                    };
                   
                    items.Order.Add(order);
                    if(items.SaveChanges()>0)
                    {
                        Console.WriteLine("The Order is Created sucssfully");
                        tran_items.Commit();

                    }
                }
            }
        }
    }
}
