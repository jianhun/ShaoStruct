using System;

namespace ShaoStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //List<int> structList = new List<int>(20);
            // LinkList<int> structList = new LinkList<int>();
            StaticLinkList<int> structList = new StaticLinkList<int>();

            for (int i = 0; i < 10; i++)
            {
                structList.Append(i * i);
            }
            structList.Print();

            structList.Insert(0, 2);
            structList.Insert(5, 3);

            structList.Print();

            structList.Delete(5);
            structList.Print();

            structList.Delete(10);
            structList.Print();

            structList.Update(2, 99);
            structList.Update(3, 100);
            structList.Print();

            structList[2] = 199;
            structList.Print();

            //structList.Clear();
            //structList.Print();

            Console.WriteLine(structList.IndexOf(25));
            Console.WriteLine(structList.IndexOf(199));
            Console.WriteLine(structList.IndexOf(200));

            Console.WriteLine("Length:" + structList.Length);

            Console.WriteLine(structList.IsEmpty());

            structList.Clear();
            structList.Print();

            Console.WriteLine(structList.IsEmpty());

            Console.WriteLine("Length:" + structList.Length);



        }
    }
}
