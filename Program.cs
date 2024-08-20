using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

interface IVehilce
{
    public string Start();
    public string Stop();
}

class Bike : IVehilce
{
    public string Start()
    {
        return "Pedal";
    }

    public string Stop()
    {
        return "stop pedal";
    }
}

class Car : IVehilce
{
    public string Start()
    {
        return "turn key";
    }

    public string Stop()
    {
        return "take off feet of car";
    }
}

class ListAll<T>
{
    public List<T> Values = new List<T>();

    public void AddValue(T vl)
    {
        Values.Add(vl);
    }

    public void RemoveValue(T v1)
    {
        Values.Remove(v1);
    }
}

static class ListAlls
{
    public static double plus(this int s, double f)
    {
        return s * f;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListAll<int> obj = new ListAll<int>();
        ListAll<string> objs = new ListAll<string>();
        int d = 2;
        d.plus(2);
        Console.WriteLine(d.plus(4));
        
        for(int i = 0; i <= 10; i++)
        {
            obj.AddValue(i);
        }
        for(int i = 0; i < obj.Values.Count; i++)
        {
            Console.WriteLine(obj.Values[i]);
        }
        for(int s = 0; s <= 10; s++)
        {
            objs.AddValue($"string number {s}");
        }
        for(int s = 0; s <= 10; s++)
        {
            Console.WriteLine(objs.Values[s]);
        }
    }
}