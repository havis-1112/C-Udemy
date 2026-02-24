using System;
using System.Linq.Expressions;

namespace ClassLibrary1
{
    // EventArgs child class
    public class CustomEventArgs : EventArgs
    {
        public int a { get; set; }
        public int b { get; set; }
    }

    public class Publisher
    {
        private MyDelegateType3 myDelegate3;

        // Custom event using add/remove
        public event MyDelegateType3 myEvent
        {
            add => myDelegate3 += value;
            remove => myDelegate3 -= value;
        }

        // Auto-implemented events
        public event MyDelegateType myEvent2;
        public event Func<int, int, int> myEvent6;   // predefined Func
        public event Action<int, int> myEvent7;      // predefined Action
        public event Predicate<int> myEvent8;        // predefined Predicate
        public event EventHandler<CustomEventArgs> myEvent9;

        // Raise standard EventHandler event
        public void RaiseEvent(object sender, int a, int b)
        {
            if (myEvent9 != null)
            {
                var args = new CustomEventArgs { a = a, b = b };
                myEvent9(sender, args);
            }
        }

        // Raise Action event
        public void RaiseActionEvent(int a, int b) => myEvent7?.Invoke(a, b);

        // Expression Tree example
        public void ExpressionTreeDemo()
        {
            // Expression tree: store logic without executing
            Expression<Func<int, int, int>> exp = (x, y) => x + y;

            // Compile to delegate to execute
            Func<int, int, int> addFunc = exp.Compile();

            int result = addFunc(10, 20);
            Console.WriteLine("Expression Tree result: " + result);

            // Inspect the tree (structure)
            Console.WriteLine("Expression Tree Body: " + exp.Body);
        }
    }
}
