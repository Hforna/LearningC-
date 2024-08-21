using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.IO;

class Student
{
    public double Code;

    public Student(double code)
    {
        Code = code;
    }


    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Student))
        {
            return false;
        }

        Student other = obj as Student;
        return Code.Equals(other.Code);
    }

}

class Program
{
    static void Main()
    {
        Console.Write("How many students for course A: ");
        int numS = int.Parse(Console.ReadLine());
        List<Student> courseA = new List<Student>();
        for (int i = 0; i < numS; i++)
        {
            courseA.Add(new Student(double.Parse(Console.ReadLine())));
        }

        Console.Write("How many students for course B: ");
        int numB = int.Parse(Console.ReadLine());
        List<Student> courseB = new List<Student>();
        for (int i = 0; i < numB; i++)
        {
            courseB.Add(new Student(double.Parse(Console.ReadLine())));
        }

        Console.Write("How many students for course C: ");
        int numC = int.Parse(Console.ReadLine());
        List<Student> courseC = new List<Student>();
        for (int i = 0; i < numC; i++)
        {
            courseC.Add(new Student(double.Parse(Console.ReadLine())));
        }

        int sumStudents = courseA.Count() + courseB.Count() + courseC.Count();
        HashSet<Student> hashStudent = new HashSet<Student>();
        for (int i = 1; i <= 3; i++)
        {
            var listCourses = courseA;
            switch (i)
            {
                case 1:
                    listCourses = courseA;
                    break;
                case 2:
                    listCourses = courseB;
                    break;
                case 3:
                    listCourses = courseC;
                    break;

            }
            for (int c = 0; c < listCourses.Count(); c++)
            {
                hashStudent.Add(listCourses[c]);
            }
        }
        int ddd = 0;
        foreach(Student pr in hashStudent)
        {
            ddd += 1;
        }
        Console.WriteLine(ddd);
    }
}