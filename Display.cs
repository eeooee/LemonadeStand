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

        public void newDayScreen(Player player,Weather weather)
        {
            string helper = "║    Today, it's supposed to be " + weather.weatherMessage+" and " + weather.temperatureMessage + ".";
            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("                    ");

            Console.Write("\t{0}.".PadRight(20), player.name);
            Console.WriteLine("wallet:${0}\tprofit:${1}".PadLeft(15), player.money, player.profit);
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
            Console.Write("\t{0}.".PadRight(20), player.name);
            Console.WriteLine("wallet:${0}\tprofit:${1}".PadLeft(15), player.money, player.profit);
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

          
            string helper = "║              Outside, it's " + weather.weatherMessage+" and " + weather.temperatureMessage + ".";
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
            Console.Write("\t{0}.".PadRight(20), player.name);
            Console.WriteLine("wallet:${0}\tprofit:${1}".PadLeft(15), player.money, player.profit);
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║                        LEMONADE                          ║");
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.Write("║"+helper2.PadRight(58));
            Console.WriteLine("║");
            Console.Write(helper.PadRight(59));
            Console.WriteLine("║");
            Console.WriteLine("║                      ...how will that affect your sales? ║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.SetCursorPosition(7, 11);

        }   

        public void endOfDay(Player player)
        {

            string helper = " ";
                Console.Clear();
                Console.SetWindowSize(61, 30);
                Console.BufferWidth = 61;
                Console.BufferHeight = 30;
                Console.Title = "Lemonade Stand";
                Console.WriteLine("                    ");

                Console.Write("\t{0}.".PadRight(20), player.name);
                Console.WriteLine("wallet:${0}\tprofit:${1}".PadLeft(15), player.money, player.profit);
                Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
                Console.WriteLine("║                IT'S THE END OF THE DAY                   ║");
                Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
                Console.WriteLine("║                                                          ║");
                Console.Write(helper.PadRight(59));
                Console.WriteLine("║");


                Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
                Console.SetCursorPosition(7, 10);
            } 


        public void GameScreen(Player player)
        {
            Console.Clear();
            Console.SetWindowSize(61, 30);
            Console.BufferWidth = 61;
            Console.BufferHeight = 30;
            Console.Title = "Lemonade Stand";
            Console.WriteLine("");
            Console.WriteLine("╓──────────────────────────────────────────────────────────╖");
            Console.WriteLine("║                                                          ║" );
            Console.WriteLine("╟──────────────────────────────────────────────────────────╢");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("╙──────────────────────────────────────────────────────────╜");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("           ");
            Console.WriteLine("            ");
            Console.WriteLine("        ");
            Console.WriteLine("        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("║                                                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.WriteLine("");
            Console.WriteLine("                 quit");
            Console.SetCursorPosition(15, 18);
            Console.ReadLine();

        }


    }
}
