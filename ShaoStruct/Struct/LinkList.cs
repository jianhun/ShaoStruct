using System;
using System.Text;

namespace ShaoStruct
{
    class LinkNode<T> 
    {
        public T data;
        public LinkNode<T> next;

        public LinkNode(T item)
        {
            data = item;
        }

        public LinkNode()
        {
            data = default(T);
        }

        public void Reset()
        {
            data = default(T);
            next = null;
        }
    }

    public class LinkList<T> : ListBase<T>
    {
        LinkNode<T> head;
        int length;

        public LinkList()
        {
            head = new LinkNode<T>();
        }

        // 插入元素
        public override void Insert(int index, T data)
        {
            if (index < 0 || index > length)
            {
                LogError("Out of the range!");
            }

            LinkNode<T> lastNode = GetLastNode(index);
            LinkNode<T> newNode = new LinkNode<T>(data);
            newNode.next = lastNode.next;
            lastNode.next = newNode;

            length++;
        }

        public void Append(T data)
        {
            Insert(length, data);
        }

		// 删除元素
		public override bool Delete(int index)
		{
            if (index < 0 || index > length - 1)
            {
                LogError("Out of the range!");
                return false;
            }

            LinkNode<T> lastNode = GetLastNode(index);
            LinkNode<T> node = lastNode.next;
            lastNode.next = node.next;

            node.Reset();
            length--;

            return true;
		}

		// 修改元素
		public override void Update(int index, T data)
		{
            if (index < 0 || index > length - 1)
            {
                LogError("Out of the range!");
                return;
            }

            LinkNode<T> node = GetNode(index);
            node.data = data;
		}

		// 查看元素
		LinkNode<T> GetLastNode(int index)
        {
            LinkNode<T> lastNode;
            if (index == 0)
            {
                lastNode = head;
            }
            else
            {
                lastNode = GetNode(index - 1);
            }

            return lastNode;
        }

		LinkNode<T> GetNode(int index)
		{
            if (index < 0 || index > length - 1)
            {
                LogError("Out of the range!");
                return default(LinkNode<T>);
            }

            LinkNode<T> data = head.next;
            int cur = 0;

            while(cur != index)
            {
                cur++;
                data = data.next;
            }

            return data;
		}

		public override T Get(int index)
		{
            LinkNode<T> node = GetNode(index);
            return node.data;
		}

        public T this[int index]
        {
            get {
                return Get(index);
            }
            set {
                Update(index, value);
            }
        }

        // 清空列表
        public void Clear()
        {
            LinkNode<T> cur = head.next;
            head.Reset();

            while(cur != null)
            {
                LinkNode<T> toClear = cur;
                cur = cur.next;

                toClear.Reset();
            }

            length = 0;
        }

        // 是否为空
        public bool IsEmpty()
        {
            // 自查
            if ((length > 0 && head.next == null)
                ||(length == 0 && head.next != null))
            {
                LogError("Badly Bug!!!");
            }

            return length == 0;
        }

        // 元素索引
        public int IndexOf(T data)
        {
            int index = -1;

            LinkNode<T> node = head.next;
            int curIndex = 0;
            while(node != null)
            {
                if (node.data.Equals(data))
                {
                    index = curIndex;
                    break;
                }

                node = node.next;
                curIndex++;
            }

            return index;
        }

        // 列表长度
        public int Length
        {
            get {
                return length;
            }
        }

        // 打印
        public void Print()
        {
            StringBuilder log = new StringBuilder("[");

            LinkNode<T> node = head;
            while(node.next != null)
            {
                node = node.next;
                log.Append(node.data);
                if (node.next != null)
                    log.Append(", ");
            }
            log.Append("]");

            Log(log.ToString());
        }
	}
}
