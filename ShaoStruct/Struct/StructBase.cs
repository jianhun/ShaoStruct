using System;

namespace ShaoStruct
{
    public abstract class StructBase<T>
    {
        protected void LogError(string str)
        {
            Console.WriteLine("Error：" + str);
            throw new Exception("Error：" + str);
        }

        protected void Log(string str)
        {
            Console.WriteLine(str);
        }
    }
}
