using System.Text;

namespace ShaoStruct
{
    class QueueLinkNode<T>
    {
        public T data;
        public QueueLinkNode<T> next;

        public QueueLinkNode(T data)
        {
            this.data = data;
            next = null;
        }

        public QueueLinkNode()
        {
            data = default(T);
            next = null;
        }

        public void Reset()
        {
            data = default(T);
            next = null;
        }
    }

    public class QueueLink<T> : StructBase<T>
    {
        QueueLinkNode<T> front;
        QueueLinkNode<T> rear;
        int length;

        public QueueLink()
        {
            front = new QueueLinkNode<T>();
            rear = front;
            length = 0;
        }

        // 进队
        public void EnQueue(T data)
        {
            QueueLinkNode<T> newNode = new QueueLinkNode<T>(data);
            rear.next = newNode;
            rear = newNode;

            length++;
        }

        // 出队
        public T DeQueue()
        {
            if (IsEmpty())
            {
                LogError("The Queue is Empty！");
                return default(T);
            }

            QueueLinkNode<T> node = front.next;
            front.next = node.next;
            if (node == rear)
                rear = front;

            T data = node.data;
            node.Reset();

            length--;
            return data;
        }

        // 获取队头元素
        public T GetHead()
        {
            if (IsEmpty())
            {
                LogError("The Queue is Empty！");
                return default(T);
            }

            return front.next.data;
        }

        // 清空
        public void Clear()
        {
            while (front != rear)
            {
                QueueLinkNode<T> toClear = front.next;
                front.next = toClear.next;

                if (rear == toClear)
                    rear = front;

                toClear.Reset();
            }
            front.Reset();

            length = 0;
        }

        // 是否为空
        public bool IsEmpty()
        {
            return length == 0;
        }

        // 长度
        public int Length {
            get {
                return length;
            }
        }

        public void Print()
        {
            StringBuilder builder = new StringBuilder("[");

            QueueLinkNode<T> cur = front;
            while(cur != rear)
            {
                cur = cur.next;
                builder.Append(cur.data);

                if (cur != rear)
                    builder.Append(", ");
            }
            builder.Append("]");

            Log(builder.ToString());
        }
    }
}
