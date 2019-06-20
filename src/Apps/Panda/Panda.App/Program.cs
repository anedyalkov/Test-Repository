using SIS.MvcFramework;
using System;

namespace Panda.App
{
    public class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
