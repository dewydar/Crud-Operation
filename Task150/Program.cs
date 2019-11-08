using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task150
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer cust = new Customer();
            Order order = new Order();
            Console.WriteLine("\tInsert Write 1 \t Update Write 2\t Delete Write 3");
            int choese;
            do
            {
                Console.Write("Please Enter Your Operator : ");
            } while (!(int.TryParse(Console.ReadLine(), out choese)));
            if (choese == 1)
            {
                Console.WriteLine("\t\t*******Customer Table*******");
                Console.WriteLine("Please Enter Customer ID That Max Character Count Is 5");
                Console.Write("Please Enter Customer ID : ");
                cust.CustomerID = ClassExtentionMethod.checkName(Console.ReadLine());
                Console.Write("Please Enter Company Name : ");
                cust.CompanyName = ClassExtentionMethod.checkChar(Console.ReadLine());
                Console.Write("Please Enter Contact Name : ");
                cust.ContactName = ClassExtentionMethod.checkChar(Console.ReadLine());
                context.Customers.Add(cust);
                context.SaveChanges();
                Console.WriteLine($"Finished Saved New Customer");
                Console.WriteLine("\t\t*******Order Table*******");
                order.CustomerID = cust.CustomerID;
                var NoId=context.Orders.OrderByDescending(x=>x.OrderID).FirstOrDefault().OrderID;
                Console.WriteLine("New Order Id : {0} ", ++NoId);
                Console.WriteLine("Customer ID In Order Table : {0}", cust.CustomerID);
                order.OrderDate = DateTime.Now;
                Console.WriteLine("Order Date : {0}", order.OrderDate);
                Console.Write("Please Enter Ship Country : ");
                order.ShipCountry = Console.ReadLine();
                context.Orders.Add(order);
                context.SaveChanges();
                Console.WriteLine($"Finished Saved Order");
                Console.WriteLine("\t\t*******Order Details Table*******");
                int size;
                do
                {
                    Console.Write("Please Enter Number Of Product : ");
                } while (!(int.TryParse(Console.ReadLine(), out size)));
                
                int[] arrProductId = new int[size];
                decimal[] arrProductUnitPrice = new decimal[size];
                short[] arrProductQuantity = new short[size];
                float[] arrProductDiscount = new float[size];
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("\t\t****Order Id : {0} ****", order.OrderID);
                    Console.WriteLine($"****You Start [{i + 1}] Product****");
                    do
                    {
                        Console.Write($"Please Enter [{i + 1}] Product ID For Order [{order.OrderID}]: ");
                    } while (!(int.TryParse(Console.ReadLine(), out arrProductId[i])));
                    do
                    {
                        Console.Write($"Please Enter Product Unit Price[{i+1}] : ");
                    } while (!(decimal.TryParse(Console.ReadLine(), out arrProductUnitPrice[i])));
                    do

                    {
                        Console.Write($"Please Enter Product Quantity[{i+1}] : ");
                    } while (!(short.TryParse(Console.ReadLine(), out arrProductQuantity[i])));
                    do
                    {
                        Console.Write($"Please Enter Product Discount[{i+1}] : ");
                    } while (!(float.TryParse(Console.ReadLine(), out arrProductDiscount[i])));
                    Console.WriteLine($"****You Finished [{i+1}] Product****");
                }
                for (int j = 0; j < size; j++)
                {
                    Order_Detail orderDe = new Order_Detail();
                    orderDe.Order = order;
                    orderDe.ProductID = arrProductId[j];
                    orderDe.UnitPrice = arrProductUnitPrice[j];
                    orderDe.Quantity = arrProductQuantity[j];
                    orderDe.Discount = arrProductDiscount[j];
                    context.Order_Details.Add(orderDe);
                    context.SaveChanges();
                    Console.WriteLine($"Finished Saved Order Details {j+1}");
                }
            }
            else if (choese == 2)
            {
                Console.WriteLine("Please Enter Customer ID That Character Count Is 5 You Want To Change");
                Console.Write("Please Enter Customer ID : ");
                string IdEdit = ClassExtentionMethod.checkName(Console.ReadLine());
                Console.WriteLine("Customer Press 1 \t Order Press 2 \t Details Press 3");
                int cho;
                do
                {
                    Console.Write("Please Enter Your Choese : ");
                } while (!(int.TryParse(Console.ReadLine(), out cho)));
                if (cho == 1)
                {
                    Customer result = context.Customers.FirstOrDefault(a => a.CustomerID == IdEdit);
                    Console.WriteLine($"Customer ID : {result.CustomerID}\tCompany Name : {result.CompanyName}");
                    if (result != null)
                    {
                        Console.WriteLine("If You Want To Change Customer ID Press 1 \t If You Want To Change Company Name Press 2\t If You Want To Change Contact Name Press 3 \n(Alert)Tip Please Enter [K] After Finish");
                        Console.WriteLine("Please Enter Your Chose : ");
                        string[] z = new string[4];
                        int i, count = 0;
                        for (i = 0; i < z.Length; i++)
                        {
                            z[i] = Console.ReadLine();
                            if (z[i] == "k")
                                break;
                            count++;
                        }
                        for (int j = 0; j < count; j++)
                        {
                            if (z[j] == "1")
                            {
                                Console.Write($"Old Customer ID ({result.CustomerID}) Enter New Customer ID : ");
                                Console.WriteLine("Please Enter Customer ID That Character Count Is 5");
                                Console.Write("Please Enter Customer ID : ");
                                string nameCustomerID = ClassExtentionMethod.checkName(Console.ReadLine());
                            }
                            else if (z[j] == "2")
                            {
                                Console.Write($"Old Company Name ({result.CompanyName}) Enter New Company Name : ");
                                result.CompanyName = ClassExtentionMethod.checkChar(Console.ReadLine());
                            }
                            else if (z[j] == "3")
                            {
                                Console.Write($"Old Contact Name ({result.ContactName}) Enter New Contact Name : ");
                                result.ContactName = ClassExtentionMethod.checkChar(Console.ReadLine());
                            }
                        }
                    }
                    context.SaveChanges();
                    Console.WriteLine("The Update Is Saved");
                }
                else if (cho == 2)
                {
                    var result = context.Orders.FirstOrDefault(a => a.CustomerID == IdEdit);
                    Console.WriteLine($"Customer ID : {result.CustomerID}\tShip Country : {result.ShipCountry}");
                    result.ShipCountry = ClassExtentionMethod.checkChar(Console.ReadLine());
                    context.SaveChanges();
                    Console.WriteLine("The Update Is Saved");
                }
                else if (cho == 3)
                {
                    var result = context.Orders.Where(a => a.CustomerID == IdEdit).ToList();
                    foreach (var item in result)
                    {
                        var result2 = context.Order_Details.Where(a => a.OrderID == item.OrderID).ToList();
                        foreach (var item2 in result2)
                        {
                            var result3 = context.Order_Details.Where(a => a.ProductID == item2.ProductID).ToList();
                            Console.WriteLine($"Order ID : {item.OrderID}\tProduct ID : {item2.ProductID}");
                            int sr;
                            do
                            {
                                Console.Write("Please Enter New Product ID : ");
                            } while (!(int.TryParse(Console.ReadLine(), out sr)));
                            item2.ProductID = sr;
                            context.SaveChanges();
                            Console.WriteLine("The Update Is Saved");
                        }
                    }
                }
            }
            else if (choese == 3)
            {
                Console.Write("Please Enter Customer ID : ");
                string IdDelete = ClassExtentionMethod.checkName(Console.ReadLine());
                Customer cusRemove = context.Customers.FirstOrDefault(a => a.CustomerID == IdDelete);
                var cusOrderRemove = context.Orders.Where(a => a.CustomerID == IdDelete).ToList();
                foreach (var item in cusOrderRemove)
                {
                    var cusOrderDetailsRemove = context.Order_Details.Where(a => a.OrderID == item.OrderID).ToList();
                    foreach (var item2 in cusOrderDetailsRemove)
                    {
                        context.Order_Details.Remove(item2);
                        context.SaveChanges();
                    }
                    Console.WriteLine($"Order Details Of {item.OrderID} Removed");
                    context.Orders.Remove(item);
                    context.SaveChanges();
                    Console.WriteLine($"Order {item.OrderID} Removed");
                }
                context.Customers.Remove(cusRemove);
                context.SaveChanges();
                Console.WriteLine($"Order {cusRemove.CustomerID} Removed");
            }
        }
    }
}
