using System.Collections.Generic;

namespace OrderSite.Models;

class OrderCurrier 
{
    public SortedSet<Order> sortedOrders;
    public IEnumerable<Order>? Orders { get => sortedOrders; }

    public OrderCurrier() {
    Order testOrder = new Order(false, 11111111, "Hello",ShippingMethod.BACKORDER, DateTime.Now);
        sortedOrders = [testOrder];
    }

    public void AddOrder(Order order) => sortedOrders?.Add(order);

}