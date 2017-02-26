using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_on_Segment
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstend = int.Parse(Console.ReadLine());
            var secondend = int.Parse(Console.ReadLine());
            var point = int.Parse(Console.ReadLine());

            var left = Math.Min(firstend, secondend);
            var right = Math.Max(firstend, secondend);

            var pointonsegment = (point >= left) && (point <= right);

            var leftdistance = Math.Abs(point - left);
            var rightdistance = Math.Abs(point - right);

            var distance = Math.Min(leftdistance, rightdistance);

            if (pointonsegment)
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine("out");
            }
            Console.WriteLine("{0}",distance);
        }
    }
}
