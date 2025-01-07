using System;

class Program
{
    static void Main()
    {
        int number = 12;
        Console.WriteLine(number.ToString());
        
        bool boolean = true;
        Console.WriteLine(boolean.ToString());
        
        DateTime now = DateTime.Now;
        Console.WriteLine(now.ToString());
        
        object me = new object();
        Console.WriteLine(me.ToString());
    }
}
