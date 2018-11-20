using System.Text;
using System.Collections.Generic;

namespace ShaoStruct
{
    struct StaticLinkNode<T>
    {
        public T data;
        public int next;
    }

    public class StaticLinkList<T> : StructBase<T>
    {
        StaticLinkNode<T>[] nodeList;
        int size;
        int length;

        public StaticLinkList()
        {
            // 第一个节点指向可用链表的第一个节点
            // 最后一个节点指向已用链表的第一个节点，相当于头结点
            size = 20;
            nodeList = new StaticLinkNode<T>[size];

            // 设置可用链表
            for (int i = 0; i < size; i++)
            {
                nodeList[i].next = i + 1;
            }
            // 设置可用链表的最后一个节点
            nodeList[size - 2].next = -1;
            // 设置已用链表
            nodeList[size - 1].next = -1;


            length = 0;
        }

        public int GetEmptyIndex()
        {
            int i = nodeList[0].next;

            if (i > -1)
            {
                nodeList[0].next = nodeList[i].next;
            }

            return i;
        }

		// 插入元素
		public override void Insert(int index, T data)
		{
            if (index < 0 || index > length)
            {
                LogError("Out of the range");
                return;
            }

            // 从可用链表中取出一个节点
            int emptyIndex = GetEmptyIndex();
            if (emptyIndex < 0)
            {
                LogError("The list is full!");
                return;
            }

            // 找到上一个节点索引
            int lastIndex = size - 1;
            int cur = 0;
            while(cur < index)
            {
                lastIndex = nodeList[lastIndex].next;
                cur++;
            }

            // 将节点加入到已用链表中
            nodeList[emptyIndex].data = data;
            nodeList[emptyIndex].next = nodeList[lastIndex].next;
            nodeList[lastIndex].next = emptyIndex;


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

            // 找到上一个节点索引
            int lastIndex = size - 1;
            int cur = 0;
            while(cur < index)
            {
                lastIndex = nodeList[lastIndex].next;
                cur++;
            }

            // 从已用链表中删除节点
            int delIndex = nodeList[lastIndex].next;
            nodeList[lastIndex].next = nodeList[delIndex].next;

            // 将被删除的节点放到可用链表中
            nodeList[delIndex].data = default(T);
            nodeList[delIndex].next = nodeList[0].next;
            nodeList[0].next = delIndex;

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

            // 找到节点索引
            int curIndex = nodeList[size - 1].next;
            int cur = 0;
            while(cur < index)
            {
                curIndex = nodeList[curIndex].next;
                cur++;
            }

            nodeList[curIndex].data = data;
		}

		// 查看元素
		public override T Get(int index)
		{
            if (index < 0 || index > length - 1)
            {
                LogError("Out of the range!");
                return default(T);
            }

            // 找到节点索引
            int curIndex = nodeList[size - 1].next;
            int cur = 0;
            while (cur < index)
            {
                curIndex = nodeList[curIndex].next;
                cur++;
            }

            return nodeList[curIndex].data;
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
            int index = nodeList[size - 1].next;
            nodeList[size - 1].next = -1;

            while (index > -1)
            {
                int nextIndex = nodeList[index].next;

                nodeList[index].data = default(T);
                nodeList[index].next = nodeList[0].next;
                nodeList[0].next = index;

                index = nextIndex;
            }

            length = 0;
        }

        // 是否为空
        public bool IsEmpty()
        {
            return length == 0;
        }

        // 元素索引
        public int IndexOf(T data)
        {
            int index = -1;

            int curIndex = nodeList[size - 1].next;
            int count = 0;
            while(curIndex > -1)
            {
                if (nodeList[curIndex].data.Equals(data))
                {
                    index = count;
                    break;
                }

                curIndex = nodeList[curIndex].next;
                count++;
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

        // 打印元素
        public void Print()
        {
            StringBuilder stringBuilder = new StringBuilder("[");

            if (length > 0)
            {
                StaticLinkNode<T> node = nodeList[size - 1];
                while (node.next > 0)
                {
                    node = nodeList[node.next];
                    stringBuilder.Append(node.data);

                    if (node.next > 0)
                        stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append("]");
            Log(stringBuilder.ToString());


            stringBuilder.Clear();
            stringBuilder.Append("[");

            for (int i = 0; i < nodeList.Length; i++)
            {
                stringBuilder.Append(nodeList[i].data);
                stringBuilder.AppendFormat("({0})", nodeList[i].next);

                if (i != nodeList.Length - 1)
                    stringBuilder.Append(", ");
            }
            stringBuilder.Append("]");
            stringBuilder.AppendLine();
            Log(stringBuilder.ToString());
        }
	}
}
