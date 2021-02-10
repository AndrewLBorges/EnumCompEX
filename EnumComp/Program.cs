using EnumComp.Entities;
using EnumComp.Entities.Enums;
using System;
using System.Globalization;

namespace EnumComp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int qtdItems = int.Parse(Console.ReadLine());

            for(int i = 1; i <= qtdItems; i++)
            {
                Console.WriteLine($"Enter #{i} data: ");
                Console.Write("Product name: ");
                string pName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product p = new Product(pName, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem item = new OrderItem(quantity, price, p);
                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);
        }
    }
}
