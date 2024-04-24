using System;
using System.Collections;

namespace 迭代器
{
    interface Iterator
    {
        object GetNextItem(); //获取下一个元素
        object GetPreviousItem(); //获取上一个元素
    }
    class ReverseArrayList: Iterator
    {
        ArrayList arrayList;
        int tail;
        public ReverseArrayList(ArrayList arrayList)
        {
            this.arrayList = arrayList;
            tail = arrayList.Count - 1;
        }
        
        public object GetNextItem()
        {
            object ret = null;
            tail--;
            if (tail >= 0)
            {
                ret = arrayList[tail];
            }
            return ret;
        }
        public object GetPreviousItem()
        {
            object ret = null;
            tail++;
            if (tail <arrayList.Count)
            {
                ret = arrayList[tail];
            }
            return ret;
        }
        
        public void WriteDesc()
        {
            for (int i=tail;i>=0;i--)
            {
                Console.Write("{0}  ",arrayList[i]);
            }
            Console.WriteLine("输出结束.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);
            arrayList.Add(6);
            ReverseArrayList ra = new ReverseArrayList(arrayList);
            ra.WriteDesc();
            Console.Read();
        }
    }
}
