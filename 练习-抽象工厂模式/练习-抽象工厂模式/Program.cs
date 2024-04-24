using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace 练习_抽象工厂模式
{
    #region ---------------------------------四道菜接口
    interface IYuxiangqiezi
    {
        void Display();
    }

    interface IGongbaojiding
    {
        void Display();
    }

    interface IXihongshichaodan
    {
        void Display();
    }

    interface IMapodoufu
    {
        void Display();
    }
    #endregion

    #region  ---------------------------------江西四道菜
    class JiangxiYuxiangqiezi : IYuxiangqiezi
    {
        public void Display()
        {
            Console.WriteLine("江西的鱼香茄子偏辣。");
        }
    }

    class JiangxiGongbaojiding : IGongbaojiding
    {
        public void Display()
        {
            Console.WriteLine("江西的宫爆鸡丁偏辣。");
        }
    }

    class JiangxiXihongshichaodan : IXihongshichaodan
    {
        public void Display()
        {
            Console.WriteLine("江西的西红柿炒蛋偏辣。");
        }
    }

    class JiangxiMapodoufu : IMapodoufu
    {
        public void Display()
        {
            Console.WriteLine("江西的麻婆豆腐偏辣。");
        }
    }

    #endregion

    #region --------------------------------- 四川四道菜
    class SichuanYuxiangqiezi : IYuxiangqiezi
    {
        public void Display()
        {
            Console.WriteLine("四川的鱼香茄子偏麻。");
        }
    }

    class SichuanGongbaojiding : IGongbaojiding
    {
        public void Display()
        {
            Console.WriteLine("四川的宫爆鸡丁偏麻。");
        }
    }

    class SichuanXihongshichaodan : IXihongshichaodan
    {
        public void Display()
        {
            Console.WriteLine("四川的西红柿炒蛋偏麻。");
        }
    }

    class SichuanMapodoufu : IMapodoufu
    {
        public void Display()
        {
            Console.WriteLine("四川的麻婆豆腐偏麻。");
        }
    }
    #endregion

    #region  ---------------------------------广东四道菜
    class GuangdongYuxiangqiezi : IYuxiangqiezi
    {
        public void Display()
        {
            Console.WriteLine("广东的鱼香茄子偏淡。");
        }
    }

    class GuangdongGongbaojiding : IGongbaojiding
    {
        public void Display()
        {
            Console.WriteLine("广东的宫爆鸡丁偏淡。");
        }
    }

    class GuangdongXihongshichaodan : IXihongshichaodan
    {
        public void Display()
        {
            Console.WriteLine("广东的西红柿炒蛋偏淡。");
        }
    }

    class GuangdongMapodoufu : IMapodoufu
    {
        public void Display()
        {
            Console.WriteLine("广东的麻婆豆腐偏淡。");
        }
    }
    #endregion

    #region  ---------------------------------上海四道菜
    class ShanghaiYuxiangqiezi : IYuxiangqiezi
    {
        public void Display()
        {
            Console.WriteLine("上海的鱼香茄子偏甜。");
        }
    }

    class ShanghaiGongbaojiding : IGongbaojiding
    {
        public void Display()
        {
            Console.WriteLine("上海的宫爆鸡丁偏甜。");
        }
    }

    class ShanghaiXihongshichaodan : IXihongshichaodan
    {
        public void Display()
        {
            Console.WriteLine("上海的西红柿炒蛋偏甜。");
        }
    }

    class ShanghaiMapodoufu : IMapodoufu
    {
        public void Display()
        {
            Console.WriteLine("上海的麻婆豆腐偏甜。");
        }
    }
    #endregion

    #region  ---------------------------------汇集后的一个工厂
    class Province
    {
        //IYuxiangqiezi CreateYuxiangqiezi();
        //IGongbaojiding CreateGongbaojiding();
        //IXihongshichaodan CreateXihongshichaodan();
        //IMapodoufu CreateMapodoufu();
        private static string province = ConfigurationManager.AppSettings["四川"];
        private static string AssemblyName = "练习-抽象工厂模式";
        private static string SpaceName = "练习_抽象工厂模式";
        public static IYuxiangqiezi CreateYuxiangqiezi()
        {
            return (IYuxiangqiezi)Assembly.Load(AssemblyName).CreateInstance(SpaceName+"." + province + "Yuxiangqiezi");
        }
        public static IGongbaojiding CreateGongbaojiding()
        {
            return (IGongbaojiding)Assembly.Load(AssemblyName).CreateInstance(SpaceName + "." + province + "Gongbaojiding");
        }

        public static IXihongshichaodan CreateXihongshichaodan()
        {
            return (IXihongshichaodan)Assembly.Load(AssemblyName).CreateInstance(SpaceName+"."  + province + "Xihongshichaodan");
        }
        public static IMapodoufu CreateMapodoufu()
        {
            return (IMapodoufu)Assembly.Load(AssemblyName).CreateInstance(SpaceName + "." + province + "Mapodoufu");
        }
    }
    #endregion

    //#region  工厂接口及产品族工厂
    //interface Factory
    //{
    //    IYuxiangqiezi CreateYuxiangqiezi();
    //    IGongbaojiding CreateGongbaojiding();
    //    IXihongshichaodan CreateXihongshichaodan();
    //    IMapodoufu CreateMapodoufu();
    //}
    //#endregion

    //#region 江西产品族
    //class JiangXi : Factory
    //{
    //    public IYuxiangqiezi CreateYuxiangqiezi()
    //    {
    //        return new JiangxiYuxiangqiezi();
    //    }
    //    public IGongbaojiding CreateGongbaojiding()
    //    {
    //        return new JiangxiGongbaojiding();
    //    }

    //    public IXihongshichaodan CreateXihongshichaodan()
    //    {
    //        return new JiangxiXihongshichaodan();
    //    }
    //    public IMapodoufu CreateMapodoufu()
    //    {
    //        return new JiangxiMapodoufu();
    //    }
    //}
    //#endregion

    //#region 四川产品族
    //class SiChuan : Factory
    //{
    //    public IYuxiangqiezi CreateYuxiangqiezi()
    //    {
    //        return new SichuanYuxiangqiezi();
    //    }
    //    public IGongbaojiding CreateGongbaojiding()
    //    {
    //        return new SichuanGongbaojiding();
    //    }

    //    public IXihongshichaodan CreateXihongshichaodan()
    //    {
    //        return new SichuanXihongshichaodan();
    //    }
    //    public IMapodoufu CreateMapodoufu()
    //    {
    //        return new SichuanMapodoufu();
    //    }
    //}
    //#endregion

    //#region 广东产品族
    //class GuangDong : Factory
    //{
    //    public IYuxiangqiezi CreateYuxiangqiezi()
    //    {
    //        return new GuangdongYuxiangqiezi();
    //    }
    //    public IGongbaojiding CreateGongbaojiding()
    //    {
    //        return new GuangdongGongbaojiding();
    //    }

    //    public IXihongshichaodan CreateXihongshichaodan()
    //    {
    //        return new GuangdongXihongshichaodan();
    //    }
    //    public IMapodoufu CreateMapodoufu()
    //    {
    //        return new GuangdongMapodoufu();
    //    }
    //}
    //#endregion

    //#region 上海产品族
    //class ShangHai : Factory
    //{
    //    public IYuxiangqiezi CreateYuxiangqiezi()
    //    {
    //        return new ShanghaiYuxiangqiezi();
    //    }
    //    public IGongbaojiding CreateGongbaojiding()
    //    {
    //        return new ShanghaiGongbaojiding();
    //    }

    //    public IXihongshichaodan CreateXihongshichaodan()
    //    {
    //        return new ShanghaiXihongshichaodan();
    //    }
    //    public IMapodoufu CreateMapodoufu()
    //    {
    //        return new ShanghaiMapodoufu();
    //    }
    //}
    //#endregion

    #region  ---------------------------------客户端程序
    class Program
    {
        static void Main(string[] args)
        {
            IYuxiangqiezi yx;
            IGongbaojiding gb;
            IXihongshichaodan xhs;
            IMapodoufu df;

            //string province = ConfigurationManager.AppSettings["上海"];
            //Factory factory = (Factory)Assembly.Load("练习-抽象工厂模式").CreateInstance("练习_抽象工厂模式." + province);
            

            yx = Province.CreateYuxiangqiezi();
            gb = Province.CreateGongbaojiding();
            xhs = Province.CreateXihongshichaodan();
            df = Province.CreateMapodoufu();

            yx.Display();
            gb.Display();
            xhs.Display();
            df.Display();
            Console.Read();
        }
    }
    #endregion
}
