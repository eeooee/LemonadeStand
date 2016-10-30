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
            int days;
            Display display = new Display();
            display.StartScreen();
            Game game = new Game();
            tycoon = game.SetUp();
            display.rules(tycoon);
            days = game.pickDays();
            Day today = new Day(tycoon, days);
            display.Done(tycoon);
            Console.ReadLine();
        }
    }
}
