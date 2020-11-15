using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            //Multiple multiple = new Multiple();
            //Date date = new Date();

            //multiple.CheckMultiple();
            //var c = date.DateValidation(30, 13, 2001);

            EanCode eancs = new EanCode();

            var c  = eancs.CheckBarCode("75678182323", 4);

            //Game game = new Game();
            //game.RunGame();

        }

    }
}
