using System.Text;

namespace ShaoStruct
{
    class LinkStackNode<T>
    {
        public T data;
        public LinkStackNode<T> next;

        public LinkStackNode(T data)
        {
            this.data = data;
        }

        public void Reset()
        {
            data = default(T);
            next = null;
        }
    }

    public class LinkStack<T> : StructBase<T>
    {
        LinkStackNode<T> top;
        int length;

        public LinkStack()
        {
            top = null;
            length = 0;
        }

        // 压栈
        public void Push(T data)
        {
            LinkStackNode<T> node = new LinkStackNode<T>(data);
            node.next = top;
            top = node;

            length++;
        }

        // 出栈
        public T Pop()
        {
            if (length <= 0)
            {
                LogError("Out of the range!");
                return default(T);
            }

            LinkStackNode<T> node = top;
            top = top.next;

            T data = node.data;
            node.Reset();
            length--;

            return data;
        }

        // 获取栈顶元素
        public T GetTop()
        {
            if (length <= 0)
            {
                LogError("Out of the range!");
                return default(T);
            }

            return top.data;
        }

        // 清空
        public void Clear()
        {
            while(top != null)
            {
                LinkStackNode<T> node = top;
                top = top.next;
                node.Reset();
            }

            length = 0;
        }

        // 长度
        public int Length {
            get {
                return length;
            }
        }

        // 是否为空
        public bool IsEmpty()
        {
            return length == 0;
        }

        // 打印
        public void Print()
        {
            StringBuilder builder = new StringBuilder("[");

            LinkStackNode<T> node = top;
            while (node != null)
            {
                builder.Append(node.data);

                if (node.next != null)
                    builder.Append(", ");

                node = node.next;
            }

            builder.Append("]");

            Log(builder.ToString());
        }
    }
}
