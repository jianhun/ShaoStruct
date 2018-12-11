using System;

namespace ShaoStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack<int> stack = new Stack<int>(20);
            //LinkStack<int> stack = new LinkStack<int>();
            //Queue<int> stack = new Queue<int>(10);
            QueueLink<int> stack = new QueueLink<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.EnQueue(i * i);
            }

            stack.Print();


            int d = stack.DeQueue();
            Console.WriteLine("The pop data is: " + d);
            d = stack.DeQueue();
            Console.WriteLine("The pop data is: " + d);
            stack.Print();
            Console.WriteLine("The stack length is: " + stack.Length);

            stack.EnQueue(180);
            stack.Print();

            stack.EnQueue(99);
            stack.Print();

            Console.WriteLine("The stack top data is: " + stack.GetHead());
            Console.WriteLine("The stack length is: " + stack.Length);
            Console.WriteLine("The stack is empty: " + stack.IsEmpty());

            stack.Clear();
            stack.Print();

            Console.WriteLine("The stack length is: " + stack.Length);
            Console.WriteLine("The stack is empty: " + stack.IsEmpty());
        }
    }
}
