using System;

namespace 观察者
{
    class Sensor
    {
        string name;
        public Sensor(string name)
        {
            this.name = name;
        }
        public delegate void GetTempEventHandler(object sender, GetTempEventArgs args);
        public event GetTempEventHandler   GetTemp;

        public void Alert()
        {
            Console.WriteLine("{0}，达到温度，作出反应.", name);

            if (GetTemp != null)
            {
                GetTempEventArgs e = new GetTempEventArgs();
                e.Name = this.name;
                GetTemp(this, e);
            }
        }
    }

    public class GetTempEventArgs : EventArgs
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    class Light
    {
        string name;
        public Light(string name)
        {
            this.name = name;
        }
        public void Flash(object sender, GetTempEventArgs args)
        {
            Console.WriteLine("收到{0}警报，警示灯{1}闪烁。", args.Name,name);
        }
    }
    class Alarm
    {
        string name;
        public Alarm(string name)
        {
            this.name = name;
        }
        public void SendMsg(object sender, GetTempEventArgs args)
        {
            Console.WriteLine("收到{0}警报，报警器{1}发出警报。", args.Name, name);
        }
    }
    class SafeDoor
    {
        string name;
        public SafeDoor(string name)
        {
            this.name = name;
        }
        public void Open(object sender, GetTempEventArgs args)
        {
            Console.WriteLine("收到{0}警报，安全逃生门{1}自动开启。", args.Name,name);
        }
    }
    class NoHotDoor
    {
        string name;
        public NoHotDoor(string name)
        {
            this.name = name;
        }

        public void Close(object sender, GetTempEventArgs args)
        {
            Console.WriteLine("收到{0}警报，隔热门{1}自动关闭。", args.Name, name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sensor sensor = new Sensor("二楼3号温度传感器");
            Light light = new Light("1号信号灯");
            Alarm alarm = new Alarm("1号报警器");
            SafeDoor safeDoor = new SafeDoor("安全逃生门");
            NoHotDoor noHot = new NoHotDoor("隔热门");
            sensor.GetTemp += new Sensor.GetTempEventHandler(light.Flash);
            sensor.GetTemp += new Sensor.GetTempEventHandler(alarm.SendMsg);
            sensor.GetTemp += new Sensor.GetTempEventHandler(safeDoor.Open);
            sensor.GetTemp += new Sensor.GetTempEventHandler(noHot.Close);

            sensor.Alert();

            Console.Read();
        }
    }
}
