using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Varian.RomanNumerals.DI;
using Varian.StringTransform.DI;
using Varian.StringTransform.Services.Interfaces;

namespace Varian.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new RomanNumeralModule(), new StringTransformModule());
            var transform = kernel.Get<IStringTransform>();

            for(; ; )
            {
                Console.WriteLine("Give input string...");
                var input = Console.ReadLine();
                Console.WriteLine("Output string is :");
                Console.WriteLine(transform.Transform(input));

                Console.WriteLine();
                Console.WriteLine("Press Enter to try again or Esc to exit.");
                var key = Console.ReadKey();
                if(key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
            Console.WriteLine("By!");
            Thread.Sleep(500);
        }    
    }
}
