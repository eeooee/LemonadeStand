using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemonade
    {

        public string taste = "";
        public double tasteMultiplier;

        public double acidity;
        public double waterRatio;
        public double sweetness;
        public double coolness;
        double costs;
        int cupsPerLiter = 8;
        int cupsLemonade;



        public void useIngredients(Player player, int liters, int sugarCups, int usedLemons, int cubesIce)
        {
            player.pantry.waterLiters = player.pantry.waterLiters - liters;
            player.pantry.cupsSugar = player.pantry.cupsSugar - sugarCups;
            player.pantry.lemons = player.pantry.lemons - usedLemons;
            player.pantry.iceCubes = player.pantry.iceCubes - cubesIce;
            cupsLemonade = liters * cupsPerLiter;
            player.pantry.cupsMade = cupsLemonade;
            player.pantry.cupsLemonade = cupsLemonade;

            costs = determineCost(player, cupsLemonade, sugarCups, usedLemons, cubesIce);
            Display.ClearLines(16, 13);
            Console.WriteLine("\n\tYou've made {0} cups of lemonade!", cupsLemonade);
            Console.WriteLine("\tYour lemonade costs ${0} per glass to make!\n", costs);
            Taste(liters, sugarCups, usedLemons, cubesIce);
            player.taste = taste;
            Console.ReadLine();
            player.setExpenses(costs);
        }

        public double determineCost(Player player, int cups, int sugarCups, int usedLemons, int iceCubesUsed)
        {
            if (cups == 0)
            {
                return 0;
            }
            else
            {
                double profit = ((sugarCups * player.pantry.sugarPrice) + (usedLemons * player.pantry.lemonPrice) + (iceCubesUsed * (player.pantry.icePrice / 10)));
                profit = profit / cups;
                return Math.Round(profit, 2);
            }

        }

        public void Taste(int liters, int sugar, int lemons, int ice)
        {  //if there are no lemons or sugar the lemonade just sucks, sorry 
            if (lemons == 0)
            {
                tasteMultiplier = .001;
                taste = "Wow, this tastes terrible. You forgot the lemons.";
            }
            else if (sugar == 0)
            {
                tasteMultiplier = .001;
                taste = "A truly horrendous batch of lemonade.  You forgot sugar.";
            }
            else if (liters == 0)
            {
                tasteMultiplier = .001;
                taste = "Without water you just made an acidic slop. Gross.";
            }
            //perfect lemonade has an acidity of .5, sweetness of .4, and a coolness of 2.5
            else
            {
                double cups = liters * cupsPerLiter;
                acidity = lemons / cups;
                sweetness = sugar /cups;
                coolness = ice / cups;
                setTasteMultiplier(acidity, sweetness, coolness);
            }
        }

        public string tasteMessage()
        {

            return taste;
        }
        public void setTasteMultiplier(double acid, double sweet, double cool)
        {
            if (acid < .25 || acid > 1.15)
            {
                tasteMultiplier = .5;
                taste = "This is lemonade.  \n\tYou have to respect the primary ingredient.";
            }
           else if (sweet < .10 || sweet > 1)
            {
                tasteMultiplier = .5;
                taste = "Something was off.  Too much sugar or not enough?";
            }
           else if (coolness < 2.5)
            {
                tasteMultiplier = .8;
                    taste = "No one likes warm lemonade.  Try some ice next time.";
            }
            else {
                tasteMultiplier = 1;
                    taste = "You made some delightful lemonade.";
                }
        }


    }
}
