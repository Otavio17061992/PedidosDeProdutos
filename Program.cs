using System;
using PedidosProdutos.Entities;
using PedidosProdutos.Enums;

namespace PedidosProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
 

            Console.WriteLine("Enter Cliente data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY)");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int itemns = int.Parse(Console.ReadLine());

            Client cliente = new Client(clientName, clientEmail, birthDate);
            Order order1 = new Order(DateTime.Now,status,cliente);


            for (int i = 1; i <= itemns; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");

                Console.Write("Product Name: ");
                string productName = Console.ReadLine();

                Console.WriteLine();

                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine());

                Product produto1 = new Product(productName,price);


                Console.WriteLine("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, produto1);

                order1.AddOrderItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order1);
        }

    }
}
