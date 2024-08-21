using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> set = new HashSet<string>();

        for(int i = 1; i <= 10; i++)
        {
            set.Add($"Henrique{i}");
        }
        foreach(string name in set)
        {
            Console.WriteLine(name);
        }

        SortedSet<int> sortset = new SortedSet<int>() {1, 2, 20, 6, 8, 10};
        SortedSet<int> sortsetd = new SortedSet<int>() { 1, 2, 212, 3, 558, 10 };
        SortedSet<int> ssd = new SortedSet<int>(sortset);
        ssd.IntersectWith(sortsetd);
        foreach (int ss in ssd)
        {
            Console.WriteLine(ss);
        }
        Console.WriteLine(set.Contains("Henrique2"));
    }
}