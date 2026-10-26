namespace Session_11
{
    internal class Section02
    {
        // handlers for the event
        static void PrintMessage(Order order)
        {
            Console.WriteLine($"Handler1: Order {order.Id} is completed");
        }

        static void SendNotification(Order order)
        {
            Console.WriteLine($"Handler2: Notification sent to {order.CustomerName}");
        }

        static void WriteAudit(Order order)
        {
            Console.WriteLine($"Handler3: Audit -> order {order.Id} saved at {DateTime.Now.ToShortTimeString()}");
        }

        public static void Run()
        {
            Order order = new Order() { Id = 1, CustomerName = "Omar", Price = 100, Quantity = 3 };

            #region Part 1
            Console.WriteLine(OrderHelper.CalculateOrderPrice(order, OrderHelper.CalculateTotal));
            Console.WriteLine(OrderHelper.CalculateOrderPrice(order, OrderHelper.CalculateTotalWithDiscount));
            #endregion

            #region Part 2
            Console.WriteLine(OrderHelper.CalculateOrderPriceFunc(order, x => x.Price * x.Quantity));
            Console.WriteLine(OrderHelper.CalculateOrderPriceFunc(order, x => x.Price * x.Quantity * 0.9m));
            #endregion

            #region Part 3
            Console.WriteLine(OrderHelper.ValidateOrder(order, o => o.Quantity > 0));
            Console.WriteLine(OrderHelper.ValidateOrder(order, o => o.Price > 0));
            Console.WriteLine(OrderHelper.ValidateOrder(order, o => !string.IsNullOrEmpty(o.CustomerName)));
            #endregion

            #region Part 4
            Action<Order> printOrder = o => Console.WriteLine($"Order {o.Id} processed.");
            Action<Order> sendConfirmation = o => Console.WriteLine($"Confirmation sent to {o.CustomerName}");
            Action<Order> writeAudit = o => Console.WriteLine($"Audit: order {o.Id}, total {o.Price * o.Quantity}");

            OrderHelper.ProcessOrder(order, printOrder);
            OrderHelper.ProcessOrder(order, sendConfirmation);
            OrderHelper.ProcessOrder(order, writeAudit);
            #endregion

            #region Part 5 + Part 6 (Events)
            OrderService orderService = new OrderService();

            orderService.OrderProcessed += PrintMessage;
            orderService.OrderProcessed += SendNotification;
            orderService.OrderProcessed += WriteAudit;

            orderService.ProcessOrder(order);   // 3 handlers

            Console.WriteLine("---- after unsubscribe Handler1 ----");
            orderService.OrderProcessed -= PrintMessage;

            orderService.ProcessOrder(order);   // 2 handlers
            #endregion

            #region Part 7 (Final Application)
            Console.WriteLine("---- Final Application ----");

            Order newOrder = new Order() { Id = 2, CustomerName = "Ali", Price = 50, Quantity = 4 };

            Predicate<Order> isValid = o => o.Quantity > 0 && o.Price > 0 && !string.IsNullOrEmpty(o.CustomerName);
            Func<Order, decimal> priceCalculator = o => o.Price * o.Quantity;

            bool valid = OrderHelper.ValidateOrder(newOrder, isValid);
            Console.WriteLine($"Valid: {valid}");

            decimal total = OrderHelper.CalculateOrderPriceFunc(newOrder, priceCalculator);
            Console.WriteLine($"Total: {total}");

            orderService.OrderProcessed += PrintMessage;
            orderService.ProcessOrder(newOrder);
            #endregion

            #region Bonus (Pricing Strategies)
            Console.WriteLine("---- Bonus ----");

            Func<Order, decimal> normal = o => o.Price * o.Quantity;
            Func<Order, decimal> discount10 = o => o.Price * o.Quantity * 0.9m;
            Func<Order, decimal> discount20 = o => o.Price * o.Quantity * 0.8m;
            Func<Order, decimal> vip = o => o.Price * o.Quantity * 0.7m;

            OrderService service2 = new OrderService();
            Console.WriteLine(service2.ProcessOrder(newOrder, normal));
            Console.WriteLine(service2.ProcessOrder(newOrder, discount10));
            Console.WriteLine(service2.ProcessOrder(newOrder, discount20));
            Console.WriteLine(service2.ProcessOrder(newOrder, vip));
            #endregion
        }
    }
}
