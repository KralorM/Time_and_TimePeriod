using Time_TimePeriod;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
           Time time = new Time(2,4,44);
           Time t1 = new Time(11);
           Time time1 = new Time(12,43,56);
           Time_period_1 t3 = new Time_period_1(3,45,43);
           Time_period_1 time2 = new Time_period_1(23,15,26);
            Console.WriteLine(t1.ToString());
           Console.WriteLine(time.ToString());
            Console.WriteLine(time.Equals(time1));
            Console.WriteLine(time != time1);
            Console.WriteLine(t3 == time2);
            Console.WriteLine(t3+time2);
            Console.WriteLine(time.Minus(t3));
            Console.WriteLine(time.Plus(t3));
            Console.WriteLine();
        }
    }
}