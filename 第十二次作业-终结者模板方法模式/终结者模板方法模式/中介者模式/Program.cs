using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 中介者模式
{
    abstract class UnitedNations
    {
        public abstract void SendMsg(string message, Country colleague);
    }

    class WHO: UnitedNations
    {
        China china;
        USA usa;
        Japan Japan;

        public China Colleague1
        {
            set { china = value; }
        }
        public USA Colleague2
        {
            set { usa = value; }
        }
        public Japan Colleague3
        {
            set { Japan = value; }
        }

        public override void SendMsg(string message, Country colleague)
        {
            if (colleague == china)
            {
                usa.GetMsg(message);
                Japan.GetMsg(message);
            }
            else if(colleague == usa)
            {
                china.GetMsg(message);
                Japan.GetMsg(message);
            }
            else if (colleague == Japan)
            {
                china.GetMsg(message);
                usa.GetMsg(message);
            }
        }
    }

    abstract class Country
    {
        protected UnitedNations unitedNations;
        public Country(UnitedNations unitedNations)
        {
            this.unitedNations = unitedNations;
        }

    }

    class China:Country
    {
        public China(UnitedNations unitedNations) : base(unitedNations) { }

        public void SendMsg(string msg)
        {
            unitedNations.SendMsg(msg,this);
        }

        public void GetMsg(string msg)
        {
            Console.WriteLine("中国接到消息："+msg);
        }
    }

    class USA : Country
    {
        public USA(UnitedNations unitedNations) : base(unitedNations) { }

        public void SendMsg(string msg)
        {
            unitedNations.SendMsg(msg, this);
        }

        public void GetMsg(string msg)
        {
            Console.WriteLine("美国接到消息：" + msg);
        }
    }
    class Japan : Country
    {
        public Japan(UnitedNations unitedNations) : base(unitedNations) { }

        public void SendMsg(string msg)
        {
            unitedNations.SendMsg(msg, this);
        }

        public void GetMsg(string msg)
        {
            Console.WriteLine("日本接到消息：" + msg);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WHO who = new WHO();
            China china = new China(who);
            USA usa = new USA(who);
            Japan japan = new Japan(who);

            who.Colleague1 = china;
            who.Colleague2 = usa;
            who.Colleague3 = japan;

            china.SendMsg("中国疫情得到控制！");
            usa.SendMsg("美国已经放弃治疗！");
            japan.SendMsg("日本，你们想不想喝核水？");

            Console.Read();
        }
    }
}
