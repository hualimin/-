using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板方法模式
{
    abstract class Bank
    {
        public void GetNumber()
        {
            Console.WriteLine("排队取号！");
        }

        abstract public void Business();

        public void Evaluate()
        {
            Console.WriteLine("请为本次服务打分！");
        }
        public void Handle()
        {
            GetNumber();
            Business();
            Evaluate();
        }
    }
    class Deposit: Bank
    {
        public override void Business()
        {
            Console.WriteLine("办理存款业务！");
        } 
    }

    class Withdrawal : Bank
    {
        public override void Business()
        {
            Console.WriteLine("办理取款业务！");
        }
    }

    class Transfer : Bank
    {
        public override void Business()
        {
            Console.WriteLine("办理转账业务！");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank1,bank2,bank3;
            bank1 = new Withdrawal();
            bank1.Handle();
            Console.WriteLine();

            bank2 = new Deposit();
            bank2.Handle();
            Console.WriteLine();
            bank3 = new Transfer();
            bank3.Handle();

            Console.Read();
        }
    }
}
