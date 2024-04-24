using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 访问者模式
{
    interface IFood
    {
        void Accept(Person person);
    }

    class Banana : IFood
    {
        double price;
        string quality;
        int count;
        public double Price { get { return price; } }
        public string Quality { get { return quality; } }
        public int Count { get { return count; } }
        public Banana(double price, string quality, int count)
        {
            this.price = price;
            this.quality = quality;
            this.count = count;
        }
        public void Accept(Person person)
        {
            person.Visit(this);
        }
    }

    class Milk : IFood
    {
        double price;
        string quality;
        int count;

        public double Price { get { return price; } }
        public string Quality { get { return quality; } }
        public int Count { get { return count; } }
        public Milk(double price, string quality, int count)
        {
            this.price = price;
            this.quality = quality;
            this.count = count;
        }
        public void Accept(Person person)
        {
            person.Visit(this);
        }
    }

    abstract class Person
    {
        string name;

        public string Name
        {
            get { return name; }
        }
        public Person(string name)
        {
            this.name = name;
        }
        public abstract void Visit(Banana food);
        public abstract void Visit(Milk food);
    }

    class Counter : Person
    {
        public Counter(string name) : base(name) { }
        public override void Visit(Banana food)
        {
            Console.WriteLine("收银员{0}，对{1}过称.", Name, food.GetType().ToString());
            Console.WriteLine("收银员{0}，检查{1}的质量{2},计算价格，为{3}.", Name, food.GetType().ToString(), food.Quality,food.Count*food.Price);
        }
        public override void Visit(Milk food)
        {
            Console.WriteLine("收银员{0}，检查{1}的质量{2},计算价格，为{3}.", Name, food.GetType().ToString(), food.Quality, food.Count * food.Price);
        }
    }

    class Customer : Person
    {
        public Customer(string name) : base(name) { }
        public override void Visit(Banana food)
        {
            Console.WriteLine("顾客{0}确认商品，{1}质量{2}.",Name,food.GetType().ToString(),food.Quality);
        }
        public override void Visit(Milk food)
        {
            Console.WriteLine("顾客{0}确认商品，{1}质量{2}.", Name, food.GetType().ToString(), food.Quality);
        }
    }

    class ShoppingCart
    {
        private ArrayList list = new ArrayList();

        public void AddFood(IFood food)
        {
            list.Add(food);
        }

        public void Accept(Person person)
        {
            foreach (object obj in list)
            {
                ((IFood)obj).Accept(person);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IFood banana, milk;
            Person clerck, customer;
            banana = new Banana(10,"新鲜",2);
            milk = new Milk(50,"过期",3);
            clerck = new Counter("小张");
            customer = new Customer("何建");

            ShoppingCart cart = new ShoppingCart();
            cart.AddFood(banana);
            cart.AddFood(milk);

            cart.Accept(customer);
            Console.WriteLine();
            cart.Accept(clerck);
            Console.Read();

        }
    }
}
