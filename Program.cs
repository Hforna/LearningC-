using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.IO;

delegate void IntNumberOperator(double first, double second);

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
        Dictionary<int, string> dict = new Dictionary<int, string>();
        dict.Add(2, "henrique");
        Console.WriteLine(dict[2]);
        static void Sum(double num1, double num2)
        {
            Console.WriteLine(num1 + num2);
        }
        static void Plus(double num1, double num2)
        {
            Console.WriteLine(num1 * num2);
        }
        IntNumberOperator ss = Sum;
        ss += Plus;
        double[] listD = new double[4];
        ss(2, 4);
        
    }
}