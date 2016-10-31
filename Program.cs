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
            Player player;
            Game LemonadeStand = new Game();
            Display display = new Display();

            display.StartScreen();
            player = LemonadeStand.SetUp();
            LemonadeStand.Start(player);
            display.Done(player);
        }
    }
}
