public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = _products.Sum(p => p.GetTotalCost());
        decimal shippingCost = _customer.LivesInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(p => $"{p.Name} ({p.ProductId})"));
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}

