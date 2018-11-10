using System;
using System.Text;

namespace ShaoStruct
{
    public class List<T> : StructBase<T>
    {

        T[] datas;
        int length;
        int size;

        public List(int size)
        {
            this.size = size;

            datas = new T[this.size];
            length = 0;
        }


        // 增加元素
        public override void Insert(int index, T data)
        {
            if (length == size)
            {
                LogError("List is full!");
                return;
            }
            else if (index < 0 || index > length)
            {
                LogError("Out of the length!");
                return;
            }

            // 将插入位置后面的元素后移一位
            for (int j = length - 1; j >= index; j--)
            {
                datas[j + 1] = datas[j];
            }

            datas[index] = data;
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
                LogError("Out of the length!");
                return false;
            }

            // 将删除位置后面的元素前移一位
            for (int i = index; i < length - 1; i++)
            {
                datas[i] = datas[i + 1];
            }

            // 将最后一位元素数据重置
            datas[length - 1] = default(T);

            length--;
            return true;
        }

        // 修改元素
        public override void Update(int index, T data)
        {
            if (index < 0 || index > length - 1)
            {
                LogError("Out of the length!");
                return;
            }

            datas[index] = data;
        }

        // 查看元素
        public override T Get(int index)
        {
            if (index < 0 || index > length - 1)
            {
                LogError("Out of the length!");
                return default(T);
            }

            return datas[index];
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
            for (int i = 0; i < length; i++)
            {
                datas[i] = default(T);
            }

            length = 0;
        }

        // 是否为空
        public bool IsEmpty()
        {
            return length == 0;
        }

        // 获取元素索引
        public int IndexOf(T data)
        {
            int index = -1;

            for (int i = 0; i < length; i++)
            {
                if (data.Equals(datas[i]))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        // 列表长度
        public int Length{
            get {
                return length;
            }
        }

        // 打印元素
        public void Print()
        {
            StringBuilder stringBuilder = new StringBuilder("[");
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(datas[i]);
                if(i != length - 1)
                    stringBuilder.Append(", ");
            }
            stringBuilder.Append("]");


            Log(stringBuilder.ToString());
        }


    }
}
