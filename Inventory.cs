using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        //the perfect lemonade recipe is 4 lemons, 1 cup of sugar, and 10 ice cubes per liter of water. 
        //each liter of water makes 8 cups of lemonade

        //sugar is 20 cent a cup
        public int cupsSugar;

        public double sugarPrice = .20;
        //lemons are 50 cent each
        public int lemons;
        public double lemonPrice = .50;
        //ice cubes are 100 for 10 cent 
        public int iceCubes;
        public double icePrice = .10;
        //water is free, because you get it from the tap
        public int waterLiters;

        public int cupsLemonade;
        public int cupsMade;
        int cupsPerLiter = 8;
        string input;
        int selection;
        public double costs;

        public Inventory()
        {
            cupsSugar = 2;
            lemons = 4;
            iceCubes = 100;
            waterLiters = 2;
        }

        //returns the cost per cup 
        public void useIngredients(Player player, int liters, int sugarCups, int usedLemons, int cubesIce)
        {
            waterLiters = waterLiters - liters;
            cupsSugar = cupsSugar - sugarCups;
            lemons = lemons - usedLemons;
            iceCubes = iceCubes - cubesIce;
            cupsLemonade = liters * cupsPerLiter;
            cupsMade = cupsLemonade;
            costs = determineCost(cupsLemonade, sugarCups, usedLemons, cubesIce);
            Display.ClearLines(18, 11);
            Console.WriteLine("  You've made {0} cups of lemonade!", cupsLemonade);
            Console.WriteLine("  Your lemonade costs ${0} per glass to make!\n", costs);
            player.setExpenses(costs);
        }

        public double determineCost(int cups, int sugarCups, int usedLemons, int iceCubesUsed)
        {
            double profit = ((sugarCups * sugarPrice) + (usedLemons * lemonPrice) + (iceCubesUsed * (icePrice / 10)));
            profit = profit / cups;
            return Math.Round(profit, 2);

        }

        private void buyLemons(int quantity, Player player)
        {
            lemons = lemons + quantity;
            Console.Write("\tBought {0} lemons!", quantity);
            input = Console.ReadLine();
        }

        private void buyIce(int quantity, Player player)
        {
            iceCubes = iceCubes + (quantity * 100);
            Console.Write("\tBought {0} ice cubes!", quantity);
            input = Console.ReadLine();
        }

        private void buySugar(int quantity, Player player)
        {
            this.cupsSugar = this.cupsSugar + quantity;
            Console.Write("\tBought {0} cups of sugar!", quantity);
            input = Console.ReadLine();
        }

        private void getWater(int quantity, Player player)
        {
            this.waterLiters = this.waterLiters + quantity;
            Console.Write("\tGot {0} liters from the tap!", quantity);
            input = Console.ReadLine();
        }

        public void pickItem(string input, Player player)
        {
            try
            {
                selection = int.Parse(input);
                whichItem(selection, player);
            }
            catch (Exception e)
            {
                Console.WriteLine("\tYou entered {0}.  Please enter 0, 1, 2, or 3. \n", input);
                input = Console.ReadLine();
                pickItem(input, player);
            }
        }

        private void whichItem(int selection, Player player)
        {
            switch (selection)
            {
                case 0:
                    buyLemons(HowMany(player, lemonPrice), player);
                    break;
                case 1:
                    buySugar(HowMany(player, sugarPrice), player);
                    break;
                case 2:
                    buyIce(HowMany(player, icePrice), player);
                    break;
                case 3:
                    getWater(HowMany(player, 0), player);
                    break;
                default:
                    pickItem("selection", player);
                    break;
            }
        }

        private int HowMany(Player player, double price)
        {
            int numInput = 0;
            Console.WriteLine("\tHow many would you like?");
            try
            {
                input = Console.ReadLine();
                numInput = int.Parse(input);
                player.Pay(price * numInput);
                return numInput;
            }
            catch (Exception e)
            {
                Console.WriteLine("\tYou entered {0}.  Please try again", input);
                HowMany(player, price);
            }
            return numInput;
        }

        private void checkQuantities(int inPantry, int requested)
        {
            if (inPantry < requested)
            {
                Console.WriteLine("\tYou can't make lemonade with more ingredients than you have!");
                throw new Exception("\tNot enough items in pantry for this! ");
            }
        }

        public int PickQuantity(int inPantry, string message)
        {
            Console.WriteLine("\tHow many {0} would you like?", message);
            int numInput;
            input = Console.ReadLine();
            try
            {
                numInput = int.Parse(input);
                checkQuantities(inPantry, numInput);
                return numInput;
            }
            catch (Exception e)
            {
                PickQuantity(inPantry, message);
                return 0;
            }
        }

        public void PickRecipe(Player player)
        {
            useIngredients(player,
            PickQuantity(waterLiters, "liters of water"),
            PickQuantity(cupsSugar, "cups of sugar"),
            PickQuantity(lemons, "lemons"),
            PickQuantity(iceCubes, "ice cubes"));
        }

        public void soldLemonade()
        {
            this.cupsLemonade--;
        }
    }
}



