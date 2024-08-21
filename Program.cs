using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;

class Logs : IComparable
{
    public string Name;
    public DateTime Date;

    public Logs(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }

    public override string ToString()
    {
        return $"Name: {Name} Date: {Date}";
    }

    public int CompareTo(object obj)
    {
        if(!(obj is Logs))
        {
            return 0;
        }

        Logs other = obj as Logs;
        return Date.CompareTo(other.Date);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if(!(obj is Logs))
        {
            return false;
        }
        Logs other = obj as Logs;
        return Name.Equals(other.Name);
    }
}

class Program
{
    static void Main()
    {
        string path = "logs.txt";

        HashSet<Logs> hashLogs = new HashSet<Logs>();

        try
        {
            using (StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(" ");
                    hashLogs.Add(new Logs(line[0], DateTime.ParseExact(line[1], "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture)));
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        foreach(Logs i in hashLogs)
        {
            Console.WriteLine(i);
        }
    }
}