using System.Text.Json;

namespace OrderSite.Models;

public enum ShippingMethod 
{
    CPUP,
    BACKORDER,
    FEDEX,
    UPS,
    SEFL,
    RLCA
}

public class Order(bool isPulled, uint orderNumber, string poNumber, ShippingMethod method, DateTime orderEntered): IComparable<Order>
{
    public bool IsPulled { get; set; } = isPulled;
    public uint OrderNumber { get; set; } = orderNumber;
    public string PONumber { get; set; } = poNumber;
    public ShippingMethod Method { get; set; } = method;
    public DateTime OrderEntered { get; set; } = orderEntered;

    public int CompareTo(Order? other)
    {
        if (other is not null)
            return this.OrderNumber.CompareTo(other.OrderNumber);

        return 0;
    }

    public string OrderFormat()
    {
        return string.Empty;
    }
}