using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        //on an average day you get up, shop, make lemonade, then go to your stand and sell it.

        Weather weather = new Weather();
        Display display = new Display();
        public Day(Player player, int days)
        {
            for(int i = 1; i<=days; i++) {


                weather.Forecast();

                display.newDayScreen(player, weather);
                player.morningReview();
              // display.newDayScreen(player, weather);
                    Console.ReadLine();
                display.Store(player);
                player.Shop();
                weather.RealWeather();
                display.Prepare(player, weather);
                player.makeLemonade();
                player.setPrice();
                display.SellLemonade(player, weather);
            VisitsStand(player.customers, player, weather);
            player.nightlyOverview();
                player.addDay();
                Console.ReadLine();
            }

        }

        public void VisitsStand(List<Customer> list, Player player, Weather weather)
        {
            double weatherMultiplier = 1; 
            if (weather.weatherActive) {
                weatherMultiplier = weather.weatherMultiplier;
            }

            for(int i=0; i<list.Count; i++)
            {
                //can't sell lemonade if you're out of lemonade
                if (player.cups() > 0)
                {
                    //weather and cost of drink determine whether or not buy will purchase 
                    if (list[i].BuyDrink(player.getCost(), weatherMultiplier))
                    {
                        player.soldDrink();
                    }
                 
                }
                else
                {
                    Console.WriteLine("You've run out of lemonade!  Time to go home.");
                    break;
                }
            }
        }

    }
}
