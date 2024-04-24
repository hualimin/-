using System;

namespace 简单工厂模式_菜园例题
{
    public class Fruit
    {
        public virtual void Display()
        {
            Console.WriteLine("还未放入种子！");
        }
    }

    //interface IFruit
    //{
    //   void  Display();
    //}

    class Apple : Fruit
    {
        public override void Display()
        {
            Console.WriteLine("种子结果了，得到了一个苹果！");
        }
    }

    class Orange : Fruit
    {
        public override void Display()
        {
            Console.WriteLine("种子结果了，得到了一个橘子！");
        }
    }

    class Banana : Fruit
    {
        public override void Display()
        {
            Console.WriteLine("种子结果了，得到了一个香蕉！");
        }
    }

    public  class FruitFactory
    {
        public static Fruit CreateFactory(string seedName)
        {
            Fruit fruit=null;
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
            Fruit fruit;
            Console.WriteLine("请输入要种下的种子");
            seedname =Console.ReadLine();
            fruit = FruitFactory.CreateFactory(seedname);
            fruit.Display();
        }
    }
}
