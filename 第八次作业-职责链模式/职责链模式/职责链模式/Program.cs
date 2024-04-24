using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 职责链模式
{
    public class RestApply
    {
        protected string rname;
        protected string result;
        protected int days;
        public RestApply(string name,string result,int days)
        {
            rname = name;
            this.result = result;
            this.days = days;
        }

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        public int Days
        {
            get { return days; }
            set { days = value; }
        }

        public string Rname
        {
            get { return rname; }
            set { rname = value; }
        }
    }

   public  abstract class Approver
    {
        protected Approver successor; 
        protected string name; 

        public Approver(string name)
        {
            this.name = name;
        }

        //设置后继者
        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        //抽象请求处理方法
        public abstract void ProcessRequest(RestApply request);
    }

    //班主任（ClassAdviser）  小于或等于两天
    public class ClassAdviser: Approver
    {
        public ClassAdviser(string name) : base(name)
        {
        }
        public override void ProcessRequest(RestApply request)
        {
            if (request.Days<=2)
            {
                Console.WriteLine("班主任{0}处理请假条-理由：{1}，天数：{2}天，请假人：{3}。",name,request.Result,request.Days,request.Rname );
            }
            else
            {
                this.successor.ProcessRequest(request);  //转发请求
            }
        }
    }

    //系主任(DepartmentHead) 小于或等于七天
    public class DepartmentHead : Approver
    {
        public DepartmentHead(string name) : base(name)
        {
        }
        public override void ProcessRequest(RestApply request)
        {
            if (request.Days <= 7)
            {
                Console.WriteLine("系主任{0}处理请假条-理由：{1}，天数：{2}天，请假人：{3}。", name, request.Result, request.Days, request.Rname);
            }
            else
            {
                this.successor.ProcessRequest(request);  //转发请求
            }
        }
    }

    //院长(Dean)  小于或等于十天
    public class Dean : Approver
    {
        public Dean(string name) : base(name)
        {
        }
        public override void ProcessRequest(RestApply request)
        {
            if (request.Days <= 10)
            {
                Console.WriteLine("院长{0}处理请假条-理由：{1}，天数：{2}天，请假人：{3}。", name, request.Result, request.Days, request.Rname);
            }
            else
            {
                Console.WriteLine("不予批准。");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            RestApply rp1,rp2,rp3,rp4;
            rp1 = new RestApply("小学生1", "不需要理由", 2);
            rp2 = new RestApply("学生2","想不出理由",6);
            rp3 = new RestApply("学生3", "??",10);
            rp4 = new RestApply("学生4", "!!!",20);

            Approver ca, da, de;
            ca = new ClassAdviser("A");
            da = new DepartmentHead("B");
            de = new Dean("C");

            ca.SetSuccessor(da);
            da.SetSuccessor(de);

            ca.ProcessRequest(rp1);
            ca.ProcessRequest(rp2);
            ca.ProcessRequest(rp3);
            ca.ProcessRequest(rp4);
            Console.Read();
        }
    }
}
