using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_after_5_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());

            day = day + 5;

            var daysinmonth = 31;

            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                daysinmonth = 30;
            }
            else if (month == 2)
            {
                daysinmonth = 28;
            }

            if (day > daysinmonth)
            {
                day = day - daysinmonth;
                month++;
                if (month == 13)
                {
                    month = 1;
                }
            }

            Console.WriteLine("{0}.{1:00}",day, month);
        }
    }
}
