using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Multiple
    {       
        public void CheckMultiple()
        {
            for (int i = 1; i < 100; i++)
            {
                if(IsDivisibleByThree(i) && IsDivisibleByFive(i))
                {
                    Console.WriteLine("FizzBuzz");                   
                }
                else if(IsDivisibleByFive(i))
                {
                    Console.WriteLine("Buzz");                  
                }
                else if (IsDivisibleByThree(i))
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine($"Number: {i}");
                }
            }
        }

        private bool IsDivisibleByThree(int number)
        {
            return (number % 3) == 0;
        }
        private bool IsDivisibleByFive(int number)
        {
            return (number % 5) == 0;
        }
    }
}
