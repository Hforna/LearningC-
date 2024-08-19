using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


class Tasks
{
    public string Name { get; set; }
    public DateTime Date = DateTime.Now;
    public string Description;
    private bool Complete = false;

    public Tasks(string Name, string Description)
    {
        this.Name = Name;
        this.Description = Description;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Name);
        sb.AppendLine(Date.ToString());
        sb.AppendLine(Description);
        return sb.ToString();
    }

    public void CompleteTask()
    {
        Complete = true;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Tasks[] listTasks = new Tasks[6];
        Directory.CreateDirectory("tasksdir");
        for(int i = 1; i <= 6; i++)
        {
            listTasks[i] = new Tasks($"learn i in c#{i}", "Learn interfaces description in c#");     
        }
        FileStream fs = File.Create("tasksdir/taks.txt");
        IEnumerable<Tasks> orderBy = listTasks.OrderBy(x => x.Date);
        using(StreamWriter wr = new StreamWriter(fs))
        {
            foreach(Tasks task in listTasks)
            {
                wr.WriteLine(task);
            }
        }

    }
}
