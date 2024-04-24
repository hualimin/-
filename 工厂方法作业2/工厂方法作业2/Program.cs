using System;
using System.Configuration;
using System.Reflection;

namespace 工厂方法作业2
{
    //IButton接口
    interface IButton
    {
        void Display();
    }

    //形状子类部分
    class RectangleButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("得到矩形");
        }
    }
    
    class CircleButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("得到圆形");
        }
    }

    class DiamondButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("得到菱形");
        }
    }

    class EllipseButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("得到椭圆形");
        }
    }

    //抽象创建工厂类接口
    interface IButtonFactory
    {
        IButton CreateButton();
    }

    //抽象创建工厂类子类部分
    class RectangleButtonFactory : IButtonFactory
    {
        public IButton CreateButton()
        {
            return new RectangleButton();
        }
    }

    class CircleButtonFactory : IButtonFactory
    {
        public IButton CreateButton()
        {
            return new CircleButton();
        }
    }

    class DiamondButtonFactory : IButtonFactory
    {
        public IButton CreateButton()
        {
            return new DiamondButton();
        }
    }

    class EllipseButtonFactory : IButtonFactory
    {
        public IButton CreateButton()
        {
            return new EllipseButton();
        }
    }

    //客户端程序
    class Program
    {
        static void Main(string[] args)
        {
            IButton button;
            IButtonFactory factory;

            //factory = new EllipseButtonFactory();
            //button = factory.CreateButton();
            //button.Display();


            string factoryString = ConfigurationManager.AppSettings["factory"];
            //string factoryString = "EllipseButtonFactory".ToString();
            //反射生成对象
            factory = (IButtonFactory)Assembly.Load("工厂方法作业2").CreateInstance(factoryString);
            button = factory.CreateButton();
            button.Display();

            Console.Read();
        }
    }
}

