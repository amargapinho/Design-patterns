using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class OnlineOrder
    {
        public string Product { get; set; } 
        public double Price { get; set; }
        public string Buyer { get; set; }
        public string Address { get; set; }
    }

    public class OnlineStore
    {
        private List<OnlineOrder> shoppingCartItems;

        public OnlineStore()
        {
            shoppingCartItems = new List<OnlineOrder>();
        }

        public void AddNewOrder(OnlineOrder order)
        {
            shoppingCartItems.Add(order);
        }
        public void CompleteOrder()
        {
            Console.WriteLine("Order successfully completed.");
        }
    }

    public class ShippingService
    {
        private OnlineOrder _shoppingCartItems;
        public void ReceiveOrder(OnlineOrder order)
        {
            _shoppingCartItems = order;
        }

        public void ShipOrder()
        {
            Console.WriteLine("Order will be shipped to {0}", _shoppingCartItems.Address, ".");
        }
    }

    public class Facade
    {
        private readonly OnlineStore _myStore;
        private readonly ShippingService _ups;

        public Facade(OnlineStore myStore, ShippingService ups)
        {
            _myStore = myStore;
            _ups = ups;
        }

        public void ProductOrder(List<OnlineOrder> OnlineOrders)
        {
            foreach (var onlineOrder in OnlineOrders)
            {
                _myStore.AddNewOrder(onlineOrder);
            }

            _myStore.CompleteOrder();

            foreach (var onlineOrder in OnlineOrders)
            {
                _ups.ReceiveOrder(onlineOrder);
                _ups.ShipOrder();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var myStore = new OnlineStore();
            var ups = new ShippingService();

            var facade = new Facade(myStore, ups);

            var order = new OnlineOrder()
            { Product = "iphone14", Price = 1020.00, Buyer = "Neves", Address = "Musterstrasse 90" };

            facade.ProductOrder(new List<OnlineOrder> { order });
        }
    }
}