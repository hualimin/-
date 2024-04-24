using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式
{
   abstract  class Command
    {
        public abstract void Execute();
    }
    class Keypad
    {
        private Command command;
        private string name;

        public Keypad(string name,Command cmd)
        {
            this.name = name;
            this.command = cmd;
        }
        public Command Command
        {
            get { return command; }
            set { command = value; }
        }

        public void Click()
        {
            Console.WriteLine("点击{0}键！",name);
            command.Execute();
        }
    }
    class PlayCommand: Command
    {
        private PlayClass pc;
        public PlayCommand()
        {
            pc= new PlayClass();
        }
        public override void Execute()
        {
            pc.Play();
        }
    }

    class RewindCommand : Command
    {
        private RewindClass rc;
        public RewindCommand()
        {
            rc = new RewindClass();
        }
        public override void Execute()
        {
            rc.Rewind();
        }
    }
    class StopCommand : Command
    {
        private StopClass sc;
        public StopCommand()
        {
            sc = new StopClass();
        }
        public override void Execute()
        {
            sc.Stop();
        }
    }
    class PlayClass
    {
        public void Play()
        {
            Console.WriteLine("播放磁带！");
            Console.WriteLine("啊八八八八");
        }
    }

    class RewindClass
    {
        public void Rewind()
        {
            Console.WriteLine("倒放磁带！");
            Console.WriteLine("八八八八啊");
        }
    }

    class StopClass
    {
        public void Stop()
        {
            Console.WriteLine("暂停磁带！");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Keypad playk, rewindk, stopk;
            Command play, rewind, stop;
            play = new PlayCommand();
            rewind = new RewindCommand();
            stop = new StopCommand();

            playk = new Keypad("播放",play);
            rewindk = new Keypad("倒带", rewind);
            stopk = new Keypad("暂停", stop);

            playk.Click();
            stopk.Click();
            rewindk.Click();

            Console.Read();
        }
    }
}
