using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;

namespace 适配器模式
{
    //方案一
    public interface Adaptee
    {
        void Cry();
        void Move();

        
    }
    class Dog : Adaptee
    {

        public void Cry()
        {
            Console.WriteLine("汪汪汪！");
        }

        public void Move()
        {
            Console.WriteLine("狗在跑！");
        }
    }

    class Bird : Adaptee
    {
        public void Cry()
        {
            Console.WriteLine("叽叽叽！");
        }

        public void Move()
        {
            Console.WriteLine("鸟在飞！");
        }
    }

    class Adaptor: Robort
    {
        Adaptee adaptee;

        public void SetDuiXiang(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }
        public void Cry()
        {
            adaptee.Cry();
        }

        public void Move()
        {
            adaptee.Move();
        }
    }

    interface Robort
    {
        void SetDuiXiang(Adaptee adaptee);
        void Cry();

        void Move();
    }

    ////方案二
    //public class Dog
    //{

    //    public void Cry()
    //    {
    //        Console.WriteLine("汪汪汪！");
    //    }

    //    public void Move()
    //    {
    //        Console.WriteLine("狗在跑！");
    //    }
    //}

    //public class Bird
    //{
    //    public void Cry()
    //    {
    //        Console.WriteLine("汪汪汪！");
    //    }

    //    public void Move()
    //    {
    //        Console.WriteLine("鸟在飞！");
    //    }
    //}

    //public interface Robert
    //{
    //    void Cry();
    //    void Move();
    //}

    //public class Adapter: Robert
    //{
    //    Dog dog;
    //    Bird bird;
    //    public Adapter(Dog dog)
    //    {
    //        this.dog = dog;
    //    }

    //    public Adapter(Bird bird)
    //    {
    //        this.bird = bird;
    //    }
    //    public void Cry()
    //    {
    //        bird.Cry();
    //    }

    //    public void Move()
    //    {
    //        this.Move();
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            string duixiang = ConfigurationManager.AppSettings["name"].ToString();
            Adaptee adaptee = (Adaptee)Assembly.Load("适配器模式").CreateInstance("适配器模式." + duixiang);
            //方案一
            //Adaptee adaptee = new Dog();
            Robort robort = new Adaptor();
            robort.SetDuiXiang(adaptee);
            robort.Cry();
            robort.Move();

            ////方案二
            //Dog dog = new Dog();
            //Robert robert = new Adapter(dog);
            //robert.Move();

            Console.Read();
        }
    }
}
