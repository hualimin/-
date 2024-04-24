using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    class Program
    {
        static public int tot_price;
        abstract class Starbuzz
        {
            protected string cfname;
            protected int price;
            //public int totot_price;
            public abstract void Display();

        }

        class HouseBlend : Starbuzz
        {
            public HouseBlend()
            {
                cfname = "综合";
                tot_price=price = 25;
            }
            public override void Display()
            {
                Console.Write("一杯"+cfname + "咖啡,");
            }

        }
        class DarkRost : Starbuzz
        {
            public DarkRost()
            {
                cfname = "深培";
                tot_price=price = 20;
            }
            public override void Display()
            {
                Console.Write("一杯" + cfname+"咖啡,");
            }
        }

        class Decat : Starbuzz
        {
            public Decat()
            {
                cfname = "低咖啡因";
                tot_price=price = 30;
            }
            public override void Display()
            {
                Console.Write("一杯" + cfname + "咖啡,");
            }
        }

        class Espresso : Starbuzz
        {
            public Espresso()
            {
                cfname = "浓缩";
                tot_price=price = 25;
            }
            public override void Display()
            {
                Console.Write("一杯" + cfname + "咖啡,");
            }
        }

        class Peiliao : Starbuzz
        {
            private Starbuzz coffee;

            public Peiliao(Starbuzz coffee)
            {
                this.coffee = coffee;
            }
            public override void Display()
            {
                coffee.Display();
            }
        }

        class Milk:Peiliao
        {
            private int price;

            public Milk(Starbuzz cofee):base(cofee)
            {
                this.price =6;
            }
            public void Add()
            {
                //显示
                Console.Write("加了一份牛奶,");
                //修改价格
                tot_price += price;
            }
            public override void Display()
            {
                base.Display();
                this.Add();
            }
        }

        class Soy : Peiliao
        {
            private int price;

            public Soy(Starbuzz cofee) : base(cofee)
            {
                this.price = 4;
            }
            public void Add()
            {
                //显示
                Console.Write("加了一份豆浆,");
                //修改价格
                tot_price += price;
            }
            public override void Display()
            {
                base.Display();
                this.Add();
            }
        }

        class Mocha : Peiliao
        {
            private int price;

            public Mocha(Starbuzz cofee) : base(cofee)
            {
                this.price = 10;
            }
            public void Add()
            {
                //显示
                Console.Write("加了一份摩卡,");
                //修改价格
                tot_price += price;
            }
            public override void Display()
            {
                base.Display();
                this.Add();
            }
        }
        class Whip : Peiliao
        {
            private int price;

            public Whip(Starbuzz cofee) : base(cofee)
            {
                this.price = 8;
            }
            public void Add()
            {
                //显示
                Console.Write("加了一份奶泡,");
                //修改价格
                tot_price += price;
            }
            public override void Display()
            {
                base.Display();
                this.Add();
            }
        }

        static void Main(string[] args)
        {
            Starbuzz coffee,milk,soy,mocha,whip;
            coffee = new Espresso();
            milk = new Milk(coffee);
            soy = new Soy(milk);
            mocha = new Mocha(soy);
            whip = new Whip(mocha);
            whip.Display();
            Console.WriteLine("总计"+tot_price+"元。");
            Console.Read();
        }
    }
}
