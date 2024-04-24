using System;
using System.Collections;

namespace 备忘录
{
    class PersonInfo
    {
        private string name;
        private int age;
        private string sex;

        public PersonInfo(string name,int age,string sex)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        internal PersonInfoMemento Save()
        {
            return new PersonInfoMemento(this.Name, this.Age, this.Sex);
        }

        //恢复  相当于Undo
        internal void Restore(PersonInfoMemento memento)
        {
            this.Name = memento.Name;
            this.Sex = memento.Sex;
            this.Age = memento.Age;
        }

        //撤销恢复 Redo
        internal void Redo(PersonInfoMemento memento)
        {
            this.Name = memento.Name;
            this.Sex = memento.Sex;
            this.Age = memento.Age;
        }

        public void Display()
        {
            Console.WriteLine("{0},今年{1},性别 {2}。", Name, Age, Sex);
        }
    }

    class PersonInfoMemento
    {
        private string name;
        private int age;
        private string sex;

        public PersonInfoMemento(string name, int age, string sex)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    public class MementoCaretaker
    {
        private Stack mementostack = new Stack();
        private Stack redostack = new Stack();
        //进栈备份
        internal void SetMemento(PersonInfoMemento memento)
        {
            mementostack.Push(memento);
        }

        //出栈还原
        internal PersonInfoMemento GetMemento()
        {
            return (PersonInfoMemento)mementostack.Pop();
        }

        //恢复
        internal PersonInfoMemento RestoreMemento(PersonInfoMemento orign)
        {
            PersonInfoMemento result;
            //拿到该值
            result = GetMemento();
            //放入Redo站栈中
            redostack.Push(orign);
            return result;
        }

        //Redo  
        internal PersonInfoMemento RedoMemento(PersonInfoMemento mement)
        {
            //redo栈 栈顶元素放回 mementostack栈，同时返回该状态
            PersonInfoMemento result;
            result = (PersonInfoMemento)redostack.Pop();
            mementostack.Push(mement);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MementoCaretaker mc = new MementoCaretaker();
            PersonInfo info = new PersonInfo("阿强",18,"男");
            info.Display();
            mc.SetMemento(info.Save());
            Console.WriteLine("修改年龄20");
            info.Age=20;
            info.Display();
            mc.SetMemento(info.Save());
            Console.WriteLine("修改年龄30");
            info.Age = 30;
            info.Display();

            Console.WriteLine("撤销");
            info.Restore(mc.RestoreMemento(info.Save()));
            info.Display();//预计显示20

            Console.WriteLine("撤销");
            info.Restore(mc.RestoreMemento(info.Save()));
            info.Display();//预计显示18

            Console.WriteLine("Redo");
            info.Redo(mc.RedoMemento(info.Save()));
            info.Display();//预计显示20

            Console.WriteLine("Redo");
            info.Redo(mc.RedoMemento(info.Save()));
            info.Display();//预计显示30

            Console.Read();
        }
    }
}
