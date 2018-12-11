using System.Text;
namespace ShaoStruct
{
    public class Queue<T> : StructBase<T>
    {
        T[] datas;
        int size;
        int front;
        int rear;

        public Queue(int size)
        {
            this.size = size + 1;   //尾指针占一个空间，不放数据
            datas = new T[this.size];
            front = 0;
            rear = 0;
        }

        // 队尾插入元素
        public void EnQueue(T data)
        {
            if (IsFull())
            {
                LogError("The Queue is full!");
                return;
            }

            datas[rear] = data;
            rear = (rear + 1) % size;
        }

        // 队头删除元素
        public T DeQueue()
        {
            if (IsEmpty())
            {
                LogError("The Queue is Empty!");
                return default(T);
            }

            T data = datas[front];
            datas[front] = default(T);
            front = (front + 1) % size;

            return data;
        }

        // 获取队头元素
        public T GetHead()
        {
            if (IsEmpty())
            {
                LogError("The Queue is Empty!");
                return default(T);
            }

            return datas[front];
        }

        // 清空
        public void Clear()
        {
            while(!IsEmpty())
            {
                datas[front] = default(T);
                front = (front + 1) % size;
            }
        }

        // 长度
        public int Length {
            get {
                return (rear - front + size) % size;
            }
        }

        // 是否为空
        public bool IsEmpty()
        {
            return front == rear;
        }

        bool IsFull()
        {
            return (rear + 1) % size == front;
        }

        public void Print()
        {
            StringBuilder builder = new StringBuilder("[");

            int cur = front;
            while(cur != rear)
            {
                builder.Append(datas[cur]);

                cur = (cur + 1) % size;

                if (cur != rear)
                    builder.Append(", ");
            }
            builder.Append("]");


            builder.AppendLine();

            builder.Append("{");
            for (int i = 0; i < size; i++)
            {
                builder.Append(datas[i]);

                if (i != size - 1)
                    builder.Append(", ");
            }
            builder.Append("}");

            Log(builder.ToString());
        }
    }
}
