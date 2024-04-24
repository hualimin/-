using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace 抽象工厂模式C
{
    public interface IFruit
    {
        void Display();
    }

    class Apple : IFruit
    {
        public void Display()
        {
            Console.WriteLine("种子结果了，得到了一个苹果！");
        }
    }

    class Orange : IFruit
    {
        public void Display()
        {
            Console.WriteLine("种子结果了，得到了一个橘子！");
        }
    }

    class Banana : IFruit
    {
        public void Display()
        {
            Console.WriteLine("种子结果了，得到了一个香蕉！");
        }
    }

    public class FruitFactory
    {
        public static IFruit CreateFactory(string seedName)
        {
            IFruit fruit = null;
            switch (seedName)
            {
                case "appleseed":
                    fruit = new Apple();
                    break;

                case "orangeseed":
                    fruit = new Orange();
                    break;

                case "bananaseed":
                    fruit = new Banana();
                    break;
            }
            return fruit;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string seedname;
            seedname = ConfigurationManager.AppSettings["seed"];
            IFruit fruit;
            // Console.WriteLine("请输入要种下的种子");
            //seedname = Console.ReadLine();
            // fruit = FruitFactory.CreateFactory(seedname);
            fruit = (IFruit)Assembly.Load("抽象工厂模式C").CreateInstance("抽象工厂模式C." + seedname);
            fruit.Display();
            Console.Read();
        }
    }
}
