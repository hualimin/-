using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 解释器模式
{
    abstract class AbstractNode
    {
        public abstract int Interpret();
    }

    class NumNode:AbstractNode
    {
        private int num;

        public NumNode(string num)
        {
            this.num = Convert.ToInt32(num);
        }
        public override int Interpret()
        {
            return num;
        }
    }
    class AddNode : AbstractNode
    {
        private AbstractNode left; 
        private AbstractNode right; 

        public AddNode(AbstractNode left, AbstractNode right)
        {
            this.left = left;
            this.right = right;
        }
        public override int Interpret()
        {
            return left.Interpret() + right.Interpret();
        }
    }

    class SubNode : AbstractNode
    {
        private AbstractNode left; 
        private AbstractNode right; 
        public SubNode(AbstractNode left, AbstractNode right)
        {
            this.left = left;
            this.right = right;
        }
        public override int Interpret()
        {
            return left.Interpret() - right.Interpret();
        }
    }

    class Handler
    {
        private AbstractNode node;

        public void Handle(string opeation)
        {
            AbstractNode left = null, right = null;
            Stack stack = new Stack(); //声明一个栈对象用于存储抽象语法树
            string[] nums = opeation.Split(' '); //以空格分隔指令字符串
            for (int i = 0; i < nums.Length; i++)
            {  		        
                if (nums[i].Equals("+"))
                {
                    string nextnum = nums[++i];
                    left = (AbstractNode)stack.Pop();
                    right = new NumNode(nextnum);
                    stack.Push(new AddNode(left, right));
                }
                else if (nums[i].Equals("-"))
                {
                    string nextnum = nums[++i];
                    left = (AbstractNode)stack.Pop();
                    right = new NumNode(nextnum);
                    stack.Push(new SubNode(left,right));
                }
                else
                {
                    string num = nums[i];
                    left = new NumNode(num);
                    stack.Push(left);
                }
            }
            this.node = (AbstractNode)stack.Pop(); //将全部表达式从栈中弹出
        }

        public int Output()
        {
            int result = node.Interpret(); //解释表达式
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入操作：");
            string opera = Console.ReadLine();
            Handler hand = new Handler();
            hand.Handle(opera);
            int result = hand.Output();
            Console.WriteLine("结果是：{0}",result);
            Console.Read();
        }
    }
}
