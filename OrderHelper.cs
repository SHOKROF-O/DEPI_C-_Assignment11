namespace Session_11
{
    internal static class OrderHelper
    {
        #region Part 1 (User-Defined Delegate)
        public static decimal CalculateTotal(Order order)
        {
            return order.Price * order.Quantity;
        }

        public static decimal CalculateTotalWithDiscount(Order order)
        {
            decimal discount = 10;
            return order.Price * order.Quantity - discount;
        }

        public static decimal CalculateOrderPrice(Order order, PriceCalculator calculator)
        {
            return calculator(order);
        }
        #endregion

        #region Part 2 (Func)
        public static decimal CalculateOrderPriceFunc(Order order, Func<Order, decimal> calculator)
        {
            return calculator(order);
        }
        #endregion

        #region Part 3 (Predicate)
        public static bool ValidateOrder(Order order, Predicate<Order> validationRule)
        {
            return validationRule(order);
        }
        #endregion

        #region Part 4 (Action)
        public static void ProcessOrder(Order order, Action<Order> action)
        {
            // order is processed here
            action(order);
        }
        #endregion
    }
}
