using System;
using System.Collections.Generic;
using System.Text;
using PedidosProdutos.Enums;

namespace PedidosProdutos.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Itemns { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            Itemns.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            Itemns.Remove(orderItem);
        }

        public double Total()
        {
            double total = 0;

            // run list orders 
            foreach (OrderItem orderItem in Itemns)
            {
                // sum subTotal OrderItems
                total += orderItem.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY: ");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy" + " "));
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order Items: ");
            foreach (OrderItem Orderitem in Itemns)
            {
                sb.AppendLine(Orderitem.ToString());
            }
            sb.Append("Total Price: $");
            sb.AppendLine(Total().ToString());

            return sb.ToString();

        }
    }
}
