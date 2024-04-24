using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 状态模式
{
    class User
    {
        string name;
        int score;
        UserState us;

        public User(string name)
        {
            this.name = name;
            this.score = 0;
            us = new GreenHand(this);
            Console.WriteLine("{0}创建账号，初始积分为{1}", this.name, score);
            Console.WriteLine("---------------------------------------------");
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public void SetClass(UserState userState)
        {
            this.us = userState;
        }
        public void SendBlog()
        {
            Console.WriteLine("{0}发博文", this.name);
            us.SendBlog(); //调用状态对象的Deposit()方法
            Console.WriteLine("现在积分为{0}", this.score);
            Console.WriteLine("现在用户等级为{0}", this.us.GetType().ToString());
            Console.WriteLine("---------------------------------------------");
        }

        public void CommentBlog()
        {
            Console.WriteLine("{0}评论博文", this.name);
            us.CommentBlog(); //调用状态对象的Deposit()方法
            Console.WriteLine("现在积分为{0}", this.score);
            Console.WriteLine("现在用户等级为{0}", this.us.GetType().ToString());
            Console.WriteLine("---------------------------------------------");
        }

        public void DownLoad()
        {
            Console.WriteLine("{0}评论博文", this.name);
            us.DownLoad(); //调用状态对象的Deposit()方法
            Console.WriteLine("现在积分为{0}", this.score);
            Console.WriteLine("现在用户等级为{0}", this.us.GetType().ToString());
            Console.WriteLine("---------------------------------------------");
        }

    }

    abstract class UserState
    {
        private User users;

        public User Users
        {
            get { return users; }
            set { users = value; }
        }

        public abstract void SendBlog();
        public abstract void CommentBlog();
        public abstract void DownLoad();
        public abstract void CheckState();
    }

    class GreenHand : UserState
    {
        public GreenHand(User users)
        {
            this.Users = users;
        }
        public override void SendBlog()
        {
            Users.Score += 20;
            CheckState();
            Console.WriteLine("成功发表博文，积分+20！");
        }
        public override void CommentBlog()
        {
            Users.Score += 10;
            CheckState();
            Console.WriteLine("成功评论博文，积分+10！");
        }
        public override void DownLoad()
        {
            Console.WriteLine("新手不能下载博文！");
        }
        public override void CheckState()
        {
            if (Users.Score>=100)
            {
                Users.SetClass(new Master(this.Users));
            }
            else if (Users.Score >= 1000)
            {
                Users.SetClass(new Expert(this.Users));
            }
        }
    }

    class Master : UserState
    {
        public Master(User users)
        {
            this.Users = users;
        }
        public override void SendBlog()
        {
            Users.Score += 40;
            CheckState();
            Console.WriteLine("成功发表博文，享受高级特权，获取双倍积分，积分+40！");
        }
        public override void CommentBlog()
        {
            Users.Score += 10;
            CheckState();
            Console.WriteLine("成功评论博文，积分+10！");
        }
        public override void DownLoad()
        {
            if (Users.Score-50<0)
            {
                Console.WriteLine("无法下载此文件！");
            }
            Users.Score -= 50;
            CheckState();
            Console.WriteLine("下载成功，积分-50！");
        }
        public override void CheckState()
        {
            if (Users.Score <100)
            {
                Users.SetClass(new GreenHand(this.Users));
            }
            else if (Users.Score >= 1000)
            {
                Users.SetClass(new Expert(this.Users));
            }
        }
    }

    class Expert : UserState
    {
        public Expert(User users)
        {
            this.Users = users;
        }
        public override void SendBlog()
        {
            Users.Score += 40;
            CheckState();
            Console.WriteLine("成功发表博文，享受专家特权，获取双倍积分，积分+40！");
        }
        public override void CommentBlog()
        {
            Users.Score += 10;
            CheckState();
            Console.WriteLine("成功评论博文，积分+10！");
        }
        public override void DownLoad()
        {
            Users.Score -= 50;
            CheckState();
            Console.WriteLine("下载成功，享受专家特权，积分扣除减半，积分-25！");
        }
        public override void CheckState()
        {
            if (Users.Score<1000&&Users.Score>=100)
            {
                Users.SetClass(new Master(this.Users));
            }
            else if ( Users.Score<100)
            {
                Users.SetClass(new GreenHand(this.Users));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("小张");
            user.DownLoad();
            user.SendBlog();
            user.CommentBlog();
            user.SendBlog(); user.SendBlog(); user.SendBlog(); user.SendBlog();
            user.SendBlog();
            user.DownLoad();

            Console.Read();
        }
    }
}
