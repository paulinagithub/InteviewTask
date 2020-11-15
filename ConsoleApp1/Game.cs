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
            int firstPlayerResult = 0;
            int secondPlayerResult = 0;

            for (int i = 0; i < 5; i++)
            {
               firstPlayerResult += TurnScore();
               secondPlayerResult += TurnScore();
            }
            if(firstPlayerResult < secondPlayerResult)
            {
                Console.WriteLine("First player is a winner");
            }
            else if (secondPlayerResult < firstPlayerResult)
            {
                Console.WriteLine("Second player is a winner");
            }
            else
            {
                Console.WriteLine("It is a tie");
            }
            ShowResultOfGame(firstPlayerResult, secondPlayerResult);
        }

        private void ShowResultOfGame(int firstGamerResult, int secondGamerResult)
        {
            Console.WriteLine($"First Gamer Sum point:{firstGamerResult}");
            Console.WriteLine($"Second Gamer Sum point:{secondGamerResult}");
        }
        private int TurnScore()
        {
            var sumOfPoint = 0;
            for (int rollNumber = 1; rollNumber < 11; rollNumber++)
            {
                int firstRoll = RandomNumber();
                int secondRoll = RandomNumber();
                int sumOfDice = firstRoll + secondRoll;
                           
                if(sumOfDice == 5)
                {
                    return sumOfPoint;
                }

                if (rollNumber == 1)
                {
                    if (sumOfDice == 7 || sumOfDice == 11)
                    {
                        return sumOfPoint;
                    }
                    
                    if (sumOfDice == 2 || sumOfDice == 12)
                    {
                        return WorstRoundPoints;
                    }
                }                
                sumOfPoint += sumOfDice / rollNumber;                        
            }
            return sumOfPoint;
        }
        private int RandomNumber()
        {
            return _random.Next(1, 6);
        }
    }
}
