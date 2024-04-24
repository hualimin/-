using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    abstract class Duck
    {
        internal string name;
        IShout shoutway;
        IFly flyway;
        public Duck(string name)
        {
            this.name = name;
        }

        public void QuackWay(IShout way)
        {
            this.shoutway = way;
        }
        public void FlyWay(IFly way)
        {
            this.flyway = way;
        }

        public string Name
        {
            get{ return name; }
        }

        public abstract void Display();

        public void Imitate()
        {
            Display();
            shoutway.Quack();
            flyway.Fly();
        }
    }

    class MallardDuck:Duck
    {
        string type= "灰鸭";
        public MallardDuck(string name) : base(name) {  }

        public override void Display()
        {
        Console.WriteLine("{0}属于{1}，外观灰色羽毛",name,type);
        }
    }
    class RedHadDuck : Duck
    {
        string type= "红头鸭";
        public RedHadDuck(string name) : base(name)  {  }

        public override void Display()
        {
            Console.WriteLine("{0}属于{1}，外观灰色羽毛，头部红色", name, type);
        }
    }
    class CotttonDuck : Duck
    {
        string type = "棉花鸭";
        public CotttonDuck(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine("{0}属于{1}，外观白色", name, type);
        }
    }
    class RubberDuck : Duck
    {
        string type = "橡皮鸭";
        public RubberDuck(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine("{0}属于{1}，外观黑白橡皮", name, type);
        }
    }
    interface IShout { void Quack(); }
    interface IFly { void Fly(); }

    class QuackShout : IShout
    {
        public void Quack()
        {
            Console.WriteLine("嘎嘎叫");
        }
    }

    class QuackNoWay : IShout
    {
        public void Quack()
        {
            Console.WriteLine("不发声");
        }
    }

    class Squeak : IShout
    {
        public void Quack()
        {
            Console.WriteLine("发出橡皮与空气磨擦声");
        }
    }

    class FlyWithWings : IFly
    {
        public void Fly()
        {
            Console.WriteLine("用翅膀飞");
        }
    }

    class FlyNoWay : IFly
    {
        public void Fly()
        {
            Console.WriteLine("不能飞行");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Duck duck1 = new MallardDuck("阿黑");
            Duck duck2 = new RedHadDuck("阿红");
            Duck duck3 = new CotttonDuck("阿花");
            Duck duck4 = new RubberDuck("阿ga");
            IShout shout1 =new QuackShout();
            IShout shout2 = new QuackNoWay();
            IShout shout3= new Squeak();

            IFly fly1 = new FlyWithWings();
            IFly fly2 = new FlyNoWay();

            duck1.QuackWay(shout1);
            duck1.FlyWay(fly1);

            duck2.QuackWay(shout1);
            duck2.FlyWay(fly1);

            duck3.QuackWay(shout2);
            duck3.FlyWay(fly2);

            duck4.QuackWay(shout3);
            duck4.FlyWay(fly2);

            duck1.Imitate();
            duck2.Imitate();
            duck3.Imitate();
            duck4.Imitate();

            Console.Read();
        }
    }
}
