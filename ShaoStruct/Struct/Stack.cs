using System;
using System.Text;

namespace ShaoStruct
{
    public class Stack<T> : StructBase<T>
    {
        T[] datas;
        int size;
        int top;

        public Stack(int size)
        {
            this.size = size;
            datas = new T[size];
            top = -1;
        }

        // 压栈
        public void Push(T data)
        {
            if (top >= size - 1)
            {
                LogError("The stack is full!");
                return;
            }

            top++;
            datas[top] = data;
        }

        // 出栈
        public T Pop()
        {
            if (top < 0)
            {
                LogError("The stack is empty!");
                return default(T);
            }

            T data = datas[top];
            top--;

            return data;
        }

        // 获取栈顶元素
        public T GetTop()
        {
            if (top < 0)
            {
                LogError("The stack is empty!");
                return default(T);
            }

            return datas[top];
        }

        // 清空
        public void Clear()
        {
            for (int i = 0; i <= top; i++)
            {
                datas[i] = default(T);
            }

            top = -1;
        }

        // 长度
        public int Length
        {
            get {
                return top + 1;
            }
        }

        // 是否为空
        public bool IsEmpty()
        {
            return top < 0;
        }

        // 打印
        public void Print()
        {
            StringBuilder stringBuilder = new StringBuilder("[");

            for (int i = 0; i <= top; i++)
            {
                stringBuilder.Append(datas[i]);

                if (i != top)
                    stringBuilder.Append(", ");
            }

            stringBuilder.Append("]");

            Log(stringBuilder.ToString());
        }
    }
}
