using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace 桥接器模式
{
    class Program
    {
        abstract class MusicImp
        {
            public abstract void Load();
        }

        class WindowsImp:MusicImp
        {
            string name = "Windows";
            public override void Load()
            {
                Console.WriteLine("在"+name+"系统下加载：");
            }
        }

        class LinuxImp : MusicImp
        {
            string name = "Linux";
            public override void Load()
            {
                Console.WriteLine("在" + name + "系统下加载：");
            }
        }

        class UnixImp : MusicImp
        {
            string name = "Unix";
            public override void Load()
            {
                Console.WriteLine("在" + name + "系统下加载：");
            }
        }


        abstract class Music
        {
            protected MusicImp imp;

            public void SetMusicImp(MusicImp imp)
            {
                this.imp = imp;
            }

            public abstract void Play(string fileName);
        }

        class Mp3Music : Music
        {
            string type = "MP3";
            public override void Play(string fileName)
            {
                imp.Load();
                Console.WriteLine("播放"+type+"格式音乐："+fileName);
            }
        }

        class WavMusic : Music
        {
            string type = "Wav";
            public override void Play(string fileName)
            {
                imp.Load();
                Console.WriteLine("播放" + type + "格式音乐：" + fileName);
            }
        }

        class WmaMusic : Music
        {
            string type = "Wma";
            public override void Play(string fileName)
            {
                imp.Load();
                Console.WriteLine("播放" + type + "格式音乐：" + fileName);
            }
        }

        class ApeMusic : Music
        {
            string type = "Ape";
            public override void Play(string fileName)
            {
                Console.WriteLine("播放" + type + "格式音乐：" + fileName);
            }
        }
        static void Main(string[] args)
        {
            MusicImp imp = new LinuxImp();
            Music music = new Mp3Music();

            //string type = ConfigurationManager.AppSettings["Type"];
            //string system = ConfigurationManager.AppSettings["System"];
            //MusicImp imp = (MusicImp)Assembly.Load("桥接器模式").CreateInstance("桥接器模式." + system);
            //Music music = (Music)Assembly.Load("桥接器模式").CreateInstance("桥接器模式." + type);

            music.SetMusicImp(imp);

            music.Play("两只老虎");
            Console.Read();

        }
    }
}
