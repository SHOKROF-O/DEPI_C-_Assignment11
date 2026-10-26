namespace Session_11
{
    public class OrderService
    {
        // Part 5: event, only this class can raise it
        public event Action<Order> OrderProcessed;

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Processing order {order.Id}...");

            OrderProcessed?.Invoke(order);
        }

        // Bonus: the service gets the pricing behavior from outside, it doesn't know how the price is calculated
        public decimal ProcessOrder(Order order, Func<Order, decimal> pricingStrategy)
        {
            decimal total = pricingStrategy(order);

            ProcessOrder(order);

            return total;
        }
    }
}
