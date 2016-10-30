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
        public int visitors;
        public int days = 0;
        double runningProfit;
        string randomName;
        string input = " ";
        public string taste = " ";

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
                Display.UpdateMoney(this);
                Display.ClearLines(15, 13);
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
            Console.WriteLine("\n   How much would you like to sell your lemonade for?");
            Console.WriteLine("   Consider your expenses so that you can make a profit.");
            Console.WriteLine("\t\tEach cup costs {0} to make.", expenses);
            try { 
            input = Console.ReadLine();
            drinkCost = Double.Parse(input);
            }
            catch(Exception e)
            {
                Display.ClearLines(11, 10);
                setPrice();
            }
            Display.ClearLines(9, 10);
        }
        public void nightlyOverview()
        {
            Console.WriteLine("\n\t\t\t{0}!!", name);
            Console.WriteLine("\t{0} neighbors visited your stand today.", visitors);
            Console.WriteLine("\n\t{0}\n",taste);
            Console.WriteLine("\tYou sold {0} cups of lemonade for {1:C} each.", cupsSold, drinkCost);
            Console.WriteLine("\tEach cup cost you {0:C} to make.", expenses);
            Console.WriteLine("\n\tYou made {0:C} in profit today! \n\tYou've made {1:C} since opening the lemonade stand.\n\n\t\t\tYou now have {2:C}.", profit,runningProfit, money);
            Console.WriteLine("");
            Console.WriteLine("\n\tHit return to continue.  Type save to save.");
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

        public void getProfit()
        {

            profit = (cupsSold * drinkCost) - (expenses * pantry.cupsMade);
            runningProfit = profit + runningProfit;
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

        public void addVisitor(bool reset)
        {
            if (reset)
            {
                visitors = 0;
            }
            visitors++;
        }
    }
}
