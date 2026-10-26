namespace Session_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Section 01
            Section01.Run();
            #endregion

            #region Section 02
            Section02.Run();
            #endregion
        }
    }
}

#region Answers

// Q1: PriceCalculator vs Func<Order, decimal>
// PriceCalculator is a delegate we write ourselves. Func<Order, decimal> is a built-in delegate with the same signature.
// They do the same job, but with Func we don't need to declare a new delegate type.
// They are two different types, so a variable of one can't be assigned to the other directly.

// Q2: Action<Order> vs Func<Order, decimal>
// Action<Order> takes an Order and returns nothing (void). Func<Order, decimal> takes an Order and returns a decimal.
// Action is for doing something, Func is for calculating something.

// Q3: Why does Predicate<T> return bool?
// Because it is used to test a condition on an item (yes or no), like validation, searching or filtering.
// Example: List.FindAll, List.Exists take a Predicate.

// Q4: delegate vs event
// A delegate is a type that holds a reference to one or more methods, and anyone who can access it can invoke it or even reassign it.
// An event is built on a delegate but outside the class it can only be subscribed (+=) or unsubscribed (-=), it can't be invoked.

// Q5: Why can't external code invoke an event of another class?
// Because the event only exposes add and remove outside its class. Raising it (Invoke) is allowed only inside the class that declares it.
// This protects the publisher, no one else can fire the event by mistake.

// Q6: Multiple handlers subscribe to the same event
// The event keeps all of them in an invocation list (multicast delegate).
// When the event is raised, all handlers are called, in the same order they were subscribed.

// Q7: orderService.OrderProcessed += HandleOrderProcessed;
// OrderProcessed : the event in the orderService object
// +=             : subscribe, add a method to the invocation list (it doesn't replace the others)
// HandleOrderProcessed : the method (handler) that will be called when the event is raised, we only pass the name and we don't call it here

// Q8: Action<Order> vs event Action<Order>
// A public Action<Order> field can be invoked from outside by anyone, and anyone can use = and delete all other subscribers.
// With event, outside code can only use += and -=, and only the class itself can raise it.
// So we use event to keep the publisher safe and encapsulated.

#endregion
