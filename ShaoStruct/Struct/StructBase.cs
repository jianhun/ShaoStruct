using System;

namespace ShaoStruct
{
    public abstract class StructBase<T>
    {
        // 插入元素
        public abstract void Insert(int index, T data);
        // 删除元素
        public abstract bool Delete(int index);
        // 修改元素
        public abstract void Update(int index, T data);
        // 查看元素
        public abstract T Get(int index);


        // 以下为内部方法
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
