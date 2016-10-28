using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Player tycoon;
            Display display = new Display();
            display.StartScreen();
            Game game = new Game();
            tycoon = game.SetUp();

            Day today = new Day(tycoon, 4);
        }
    }
}
