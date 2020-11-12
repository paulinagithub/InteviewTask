using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    /*
 *
Napisz program, który wypisuje liczby od 1 do 100. Ale dla wielokrotności trójki wyświetl "Fizz" zamiast
liczby oraz dla wielokrotności piątki wyświetl "Buzz". Dla liczb będących wielokrotnościami trójki oraz
piątki wyświetl "FizzBuzz".

*/
    public class Multiple
    {
        public void CheckMultiple()
        {
            for (int i = 1; i < 100; i++)
            {

                if(IsDivisible(i,3))
                {
                    if(IsDivisibleByFive(i))
                    {
                        Console.WriteLine("FizzBuzz");
                    }
                    else
                    {
                        Console.WriteLine("Fizz");
                    }
                }
                else if(IsDivisibleByFive(i))
                {
                    Console.WriteLine("Buzz");                  
                }
                else
                {
                    Console.WriteLine($"Number: {i}");
                }
            }
        }

        public bool IsDivisible(int number, int divisibleNumber)
        {
            return (number % divisibleNumber) == 0;
        }
        public bool IsDivisibleByThree(int number)
        {
            return (number % 3) == 0;
        }
        public bool IsDivisibleByFive(int number)
        {
            return (number % 5) == 0;
        }
    }

}
