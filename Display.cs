using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Display
    {


        public void StartScreen()
        {

            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            //lovely ascii splash screen text curtosy of http://patorjk.com/software/taag/#p=testall&h=2&f=Blocks&t=welcome
            //used the bloody font
            Console.WriteLine("  █     █░▓█████  ██▓    ▄████▄  ▒█████   ███▄ ▄███▓▓█████ ");
            Console.WriteLine(" ▓█░ █ ░█░▓█   ▀ ▓██▒   ▒██▀ ▀█ ▒██▒  ██▒▓██▒▀█▀ ██▒▓█   ▀ ");
            Console.WriteLine(" ▒█░ █ ░█ ▒███   ▒██░   ▒▓█    ▄▒██░  ██▒▓██    ▓██░▒███   ");
            Console.WriteLine(" ░█░ █ ░█ ▒▓█  ▄ ▒██░   ▒▓▓▄ ▄██▒██   ██░▒██    ▒██ ▒▓█  ▄ ");
            Console.WriteLine(" ░░██▒██▓ ░▒████▒░██████▒ ▓███▀ ░ ████▓▒░▒██▒   ░██▒░▒████▒");
            Console.WriteLine(" ░ ▓░▒ ▒  ░░ ▒░ ░░ ▒░▓  ░ ░▒ ▒  ░ ▒░▒░▒░ ░ ▒░   ░  ░░░ ▒░ ░");
            Console.WriteLine("   ▒ ░ ░   ░ ░  ░░ ░ ▒  ░ ░  ▒    ░ ▒ ▒░ ░  ░      ░ ░ ░  ░");
            Console.WriteLine("   ░   ░     ░     ░ ░  ░       ░ ░ ░ ▒  ░      ░      ░   ");
            Console.WriteLine("     ░       ░  ░    ░  ░ ░         ░ ░         ░      ░  ░");
            Console.WriteLine("                        ░                                  ");
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                               ");
            Console.WriteLine("                                   ");
            Console.WriteLine("                                 ");
            Console.WriteLine("                              ");
            Console.WriteLine("                    ");
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║            YOU'RE NOW PLAYING LEMONADE STAND             ║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.WriteLine("║              Hit enter to start a new game               ║");
            Console.WriteLine("║         Type continue to load an existing game           ║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");





        }


        public void rules(Player player)
        {
            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            string helper = "║                      Hey," + player.name + "!";
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║       Selling lemonade can be very profitable....        ║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.WriteLine("");
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║     1. Each day you will wake up, go to the store,       ║");
            Console.WriteLine("║      prepare your lemonade, then sell it outside.        ║");
            Console.WriteLine("║     2. Your recipe is important.  The best lemonade      ║");
            Console.WriteLine("║      is sweet yet acidic, cold, and refreshing.          ║");
            Console.WriteLine("║     3. Pay attention to the forecast.  Although it's     ║");
            Console.WriteLine("║      not always right, the weather effects how many      ║");
            Console.WriteLine("║      people visit your stand and how much they'll pay.   ║");
            Console.WriteLine("║     4. The price of your lemonade matters.  Try to       ║");
            Console.WriteLine("║      make as much money as you can.                      ║");
            Console.WriteLine("║     5.  You choose how many days you'd like to play      ║");
            Console.WriteLine("║      for.                                                ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.WriteLine("                   Do you wanna be rich?            ");
            Console.SetCursorPosition(0, 26);
        }

        public void newDayScreen(Player player, Weather weather)
        {
            string helper = "║    Today, it's supposed to be " + weather.weatherMessage + " and " + weather.temperatureMessage + ".";
            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("                    ");

            Console.Write("\t{0}.".PadRight(9), player.name);
            Console.WriteLine("wallet:{0:C}\tprofit:${1:0.00}", player.money, player.profit);
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║                   WELCOME TO A NEW DAY                   ║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.WriteLine("║                                                          ║");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");


            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.SetCursorPosition(27, 4);
            Console.Write("Day {0}.", player.days);
            Console.SetCursorPosition(7, 10);

        }

        public void Store(Player player)
        {

            string helper = ("║     lemons-" + player.pantry.lemonPrice.ToString("C") + "  sugar-" + player.pantry.sugarPrice.ToString("C") + "  ice-" + player.pantry.icePrice.ToString("C") + "  water-free ");
            string helper2 = "║             type leave  to exit the store";
            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("                    ");
            Console.Write("\t{0}.".PadRight(9), player.name);
            Console.WriteLine("wallet:{0:C}\tprofit:${1:0.00}", player.money, player.profit);
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║                          PRICES                          ║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");
            Console.WriteLine("║                                                          ║");
            Console.Write(helper2.PadRight(59));
            Console.WriteLine("║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.SetCursorPosition(3, 11);

        }

        public void Prepare(Player player, Weather weather)
        {


            string helper = "║              Outside, it's " + weather.weatherMessage + " and " + weather.temperatureMessage + ".";
            string helper2 = " ";
            if (weather.weatherActive)
            {
                helper2 = "    Looks like the weatherperson was right!";
            }
            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("                    ");
            Console.Write("\t{0}.".PadRight(9), player.name);
            Console.WriteLine("wallet:{0:C}\tprofit:${1:0.00}", player.money, player.profit);
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║                    MAKE SOME LEMONADE                    ║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.Write("║" + helper2.PadRight(58));
            Console.WriteLine("║");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");
            Console.WriteLine("║                      ...how will that affect your sales? ║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.SetCursorPosition(7, 11);

        }


        public void SellLemonade(Player player, Weather weather)
        {


            string helper = "║              You go outside and set up your stand.";
            string helper2 = " Now to wait.  ";
            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("                    ");
            Console.Write("\t{0}.".PadRight(9), player.name);
            Console.WriteLine("wallet:{0:C}\tprofit:${1:0.00}", player.money, player.profit);
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║                    SELL SOME LEMONADE                    ║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");
            Console.Write("║" + helper2.PadRight(58));
            Console.WriteLine("║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║                                                          ║");
            Console.SetCursorPosition(7, 11);

        }



        


        public void nightScreen(Player player, Weather weather)
        {
            string helper = "║        Today, it was " + weather.weatherMessage + " and " + weather.temperatureMessage + ".";
            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("                    ");
            Console.Write("\t{0}.".PadRight(9), player.name);
            Console.WriteLine("wallet:{0:C}\tprofit:${1:0.00}", player.money, player.profit);
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║                   IT'S BEEN A LONG DAY                   ║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.WriteLine("║                                                          ║");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");


            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.SetCursorPosition(25, 4);
            Console.Write("Night {0}.", player.days);
            Console.SetCursorPosition(7, 10);

        }

        public void Done(Player player)
        {
            Console.Clear();
            string days = "" + player.days;
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("                    ");
            Console.WriteLine("\t{0}.".PadRight(9), player.name);
            string helper = "║               You sold lemonade for " + days + " days.";
            string helper2 = String.Format("║                   Total Profit: ${0:0.00}", player.profit);
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.Write(helper2.PadRight(59));
            Console.WriteLine("║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                           Good work.               ");

            Console.WriteLine("");
            Console.WriteLine("            Ultimately, you served {0} cups of lemonade   ", player.runningCups);

            Console.WriteLine("");
            Console.WriteLine("       to {0} neighbors.  Your stand was visited {1}   ", player.numberOfCustomers, player.runningVisitors);

            Console.WriteLine("");
            Console.WriteLine("       times over the " + days + " days you were in business.");

            Console.WriteLine("");
            Console.WriteLine("       You now have {0:C} in your wallet.", player.money);


        }


        public void GameOver(Player player)
        {
            string helper = "GAME OVER";
            Console.WriteLine("                    ");
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.WriteLine("║                    OOPS, YOU'RE BROKE.                   ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
        }

        //clears a certain amount of lines, then resets the cursor to a height passed to it 
        public static void ClearLines(int height, int lines)
        {

            Console.SetCursorPosition(0, height);
            for (int i = 0; i < lines; i++)
            {
                Console.Write(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, height);
        }

        public static void UpdateMoney(Player player)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                    ");
            Console.Write("\t{0}.".PadRight(15), player.name);
            Console.WriteLine("wallet:{0:C}\tprofit:${1:0.00}", player.money, player.profit);
            Console.SetCursorPosition(0, 15);
        }
    }
}


