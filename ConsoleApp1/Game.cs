using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        private readonly Random _random = new Random();
        /* 
        (6+6)/1+
        (6+6)/2+
        (6+6)/3+
        (6+6)/4+
        (6+6)/5+
        (6+6)/6 = 35
        */
        private const int WorstRoundPoints = 35;

        public void RunGame()
        {
            int firstGamerResult = 0;
            int secondGamerResult = 0;
            for (int i = 0; i < 5; i++)
            {
               firstGamerResult += StartThrowing();
               secondGamerResult += StartThrowing();
            }
            if(firstGamerResult < secondGamerResult)
            {
                Console.WriteLine("First player is a winner");
                ShowResultOfGame(firstGamerResult, secondGamerResult);
            }
            else if (secondGamerResult < firstGamerResult)
            {
                Console.WriteLine("Second player is a winner");
                ShowResultOfGame(firstGamerResult, secondGamerResult);
            }
            else
            {
                Console.WriteLine("No one is a winner");
                ShowResultOfGame(firstGamerResult, secondGamerResult);
            }
        }
        public void ShowResultOfGame(int firstGamerResult, int secondGamerResult)
        {
            Console.WriteLine($"First Gamer Sum point:{firstGamerResult}");
            Console.WriteLine($"Second Gamer Sum point:{secondGamerResult}");
        }
        public int StartThrowing()
        {
            var sumOfPoint = 0;
            for (int i = 1; i < 11; i++)
            {
                int firstThrow = RandomNumber();
                int secondThrow = RandomNumber();
                int sumOfThrows = SumOfThrows(firstThrow, secondThrow);
                           
                if(sumOfThrows == 5)
                {
                    return sumOfPoint;
                }
                else if (i == 1)
                {
                    if (sumOfThrows == 7 || sumOfThrows == 11)
                    {
                        return sumOfPoint;
                    }
                    else if (sumOfThrows == 2 || sumOfThrows == 12)
                    {
                        return WorstRoundPoints;
                    }
                }              
                sumOfPoint += sumOfThrows / i;                        
            }
            return sumOfPoint;
        }
        public int SumOfThrows(int firstThrow, int secondThrow)
        {
            return firstThrow + secondThrow;
        }
        public int RandomNumber()
        {
            return _random.Next(1, 6);
        }
    }
}
