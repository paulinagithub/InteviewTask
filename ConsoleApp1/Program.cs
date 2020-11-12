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
            //Data date = new Data();

            //multiple.CheckMultiple();
            //var c  = date.DateValidation(12,2, 2002);

            EanCode eancs = new EanCode();

            var c  = eancs.CheckBarCode("075678180", 1);

            //Game game = new Game();
            //game.RunGame();

        }

    }
}
