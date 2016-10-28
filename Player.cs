using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public string name;
        public double money;
        public double profit;
        double expenses;
        double drinkCost=.45;
        double startingFunds = 2.00;
        public Inventory pantry = new Inventory();
        static string path ="randomnames.txt";
       public  List<Customer> customers = new List<Customer>();
        string[] names = File.ReadAllLines(path);
        int numberOfCustomers = 20;
        int numInput;
        int cupsSold;
        public int days = 1;
        double runningProfit;
        string randomName;
        string input = " ";

        public Player()
        {
            Console.WriteLine("\t What would you like to be called?");
            this.name = Console.ReadLine();
            this.money = startingFunds;
            pantry = new Inventory();
            createCustomers();

        }

        //this constructor is for loaded files
       public Player(string name, double money, double profit)
        {
            this.name = name;
            this.money = money;
            pantry = new Inventory();
            createCustomers();

        }
        

        private void createCustomers()
        {
            for (int i = 0; i <= numberOfCustomers; i++)
            {
                customers.Add(new Customer(names[i]));
                Thread.Sleep(20);
            }
            Console.WriteLine("\tDone populating the neighborhoood.  Hit return!");
        }

        public void Shop()
        {
            Console.WriteLine("\n\t\tYou decided to visit the store.");
            Console.WriteLine("\t\tWhat would you like to buy? ");
            Console.WriteLine("\n   0: Lemons \t 1: Sugar \t 2: Ice \t 3: Water");
            input = Console.ReadLine();
            while (!input.Contains("leave"))
            {
                pantry.pickItem(input, this);
                Display.ClearLines(8, 15);
                Console.WriteLine("   0: Lemons \t 1: Sugar \t 2: Ice \t 3: Water");
               // Display.ClearLines(7, 15);
                input = Console.ReadLine();
            }
        }

        public void Pay(double cost)
        {
            if(this.money -cost < 0)
            {
                Console.WriteLine("You don't have enough money for this purchase!");
                throw new Exception("You don't have enough money for this purchase!");
            }
            this.money = money - cost;
            
        }

        public void makeLemonade()
        {
            Console.WriteLine("\tTo make lemonade you must break a few lemons!!  \n\n\tThink carefully about your recipe.");
            Console.WriteLine("\tRemember, each liter of water makes you 8 cups \n\tof lemonade.\n");
            pantry.PickRecipe(this);

        }

        public void setPrice()
        {
            Console.WriteLine("\tHow much would you like to sell your lemonade for?  ");
            Console.WriteLine("\tConsider your expenses so that you can make a profit.", expenses);
            input = Console.ReadLine();
            drinkCost = Double.Parse(input);
        }
        public void nightlyOverview()
        {
            profit = (cupsSold* drinkCost) - (expenses * pantry.cupsMade);
            runningProfit = profit + runningProfit;
            Console.WriteLine("Today you sold {0} cups of lemonade for ${1} each for a total of ${2}.", cupsSold, drinkCost, cupsSold*drinkCost);
            Console.WriteLine("Each cup cost you {0} to make.", expenses);
            Console.WriteLine("You made ${0} in profit today!  You've made ${1} since opening the lemonade stand.  You now have ${2}.", profit,runningProfit, money);
        }

        public void morningReview()
        {
            Console.WriteLine("\n\t\t\t Wake up {0}!", name);
            Console.WriteLine("\t\tIt's time to sell some lemonade.");

            Console.Write("\n\t\tYou have");
            Console.WriteLine(" {0} lemons\n\t\t\t {1} cups of sugar\n\t\t\t {2} ice cubes\n\t\t\t {3} liters of water".PadRight(50), pantry.lemons, pantry.cupsSugar, pantry.iceCubes, pantry.waterLiters);

            Console.WriteLine("\n\t\"At my lemonade stand I used to give the first \n      glass away free and charge five dollars for the \n      second glass. \n\n\t\tThe refill contained the antidote.\"");
            
            Console.WriteLine("\n\n\t\tHit return to go about your day.");
            
            



        }
        public void setExpenses(double costPerCup)
        {
            expenses = costPerCup;
        }

        public double getCost()
        {
            return drinkCost;
        }
        
        public int cups()
        {
            return pantry.cupsLemonade;
        }
        public void soldDrink()
        {
            money = money + drinkCost;
            pantry.soldLemonade();
            cupsSold++;
        }

        public void addDay()
        {
            days++;
        }
    }
}
