using System;
using System.Collections.Generic;
using System.IO;

public static class Solution {
    
}

class Program
{
    static void Main(string[] args)
    {
    FileStream file = new FileStream("../pj.csv", FileMode.Open); // add a file here
    List<string> listfile = new List<string>();
    using(StreamReader filest = new StreamReader(file))
    {
        while(!filest.EndOfStream)
        {
            string fileline = filest.ReadLine();
            listfile.Add(fileline);
        }
    }
    Directory.CreateDirectory("out");
    List<string> fin = new List<string>();
    foreach(string list in listfile)
    {
        var s = list.Split(", ");
        double db = int.Parse(s[1].Trim()) * int.Parse(s[2].Trim());
        fin.Add($"{s[0]}: {db}\n");
    }
    //Stream sss = File.Create("out/summary.csv");
    using(StreamWriter write = File.AppendText("out/summary.csv"))
    {
        foreach(string line in fin)
        {
            write.WriteLine(line);
        }
    }
    }
}