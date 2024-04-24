using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 组合模式
{
    class Program
    {
        abstract class AbstractSchool
        {
            protected string name;
            protected string content;
            public AbstractSchool(string name)
            {
                this.name = name;
                content = "";
            }

            public string Content 
            {
                get { return content; }
                set { content = value; }
            }
            public abstract void Add(AbstractSchool depart);
            public abstract void Remove(AbstractSchool depart);
            public abstract AbstractSchool GetChild(int i);
            public abstract void SendFile(int depth);
        }

        class ConcreteSchool : AbstractSchool
        {
            private List<AbstractSchool> children = new List<AbstractSchool>();

            public ConcreteSchool(string name)
                : base(name)
            { }

            public override void Add(AbstractSchool c)
            {
                children.Add(c);
            }

            public override void Remove(AbstractSchool c)
            {
                children.Remove(c);
            }
            public override AbstractSchool GetChild(int i)
            {
                return (AbstractSchool)children[i];
            }

            //下发公文
            public override void SendFile(int depth)
            {

                Console.Write(new String('-', depth) + name+"下发公文:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(content);
                Console.ForegroundColor = ConsoleColor.White;

                foreach (AbstractSchool c in children)
                {
                    c.Content = this.content;
                    c.SendFile(depth + 2);
                }
            }    

        }

        class Department : AbstractSchool
        {
            public Department(string name)
                : base(name)
            { }

            public override void Add(AbstractSchool c)
            {
            }

            public override void Remove(AbstractSchool c)
            {
            }
            public override AbstractSchool GetChild(int i)
            {
                return null;
            }
            //下发公文
            public override void SendFile(int depth)
            {
                Console.Write(new String('-', depth) + name + "收到公文:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(content);
                Console.ForegroundColor = ConsoleColor.White;
            } 
        }
        static void Main(string[] args)
        {
            AbstractSchool bj, bjjw, bjxz, hn, hnjw, hnxz, cs, csjw, csxz, xt, xtjw, xtxz;
            bj = new ConcreteSchool("北京总部");
            bjjw = new Department("教务办公室");
            bjxz= new Department("行政办公室");

            hn = new ConcreteSchool("湖南分校");
            hnjw = new Department("湖南教务办公室");
            hnxz = new Department("湖南行政办公室");

            cs = new ConcreteSchool("长沙分校");
            csjw = new Department("长沙教务办公室");
            csxz = new Department("长沙行政办公室");

            xt = new ConcreteSchool("湘潭分校");
            xtjw = new Department("湘潭教务办公室");
            xtxz = new Department("湘潭行政办公室");

            bj.Add(bjjw);
            bj.Add(hn);
            bj.Add(bjxz);

            hn.Add(hnjw);
            hn.Add(hnxz);

            hn.Add(cs);
            hn.Add(xt);

            cs.Add(csjw);
            cs.Add(csxz);

            xt.Add(xtjw);
            xt.Add(xtxz);

            
            string content = "紧急文件";
            bj.Content = content;
            bj.SendFile(1);

            Console.Read();
        }
    }
}
