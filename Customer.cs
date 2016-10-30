using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        string name;
        double maxPayment;
        double chanceOfPurchasing;
        int cupsBought;
        int cupsSkipped;
        Random random = new Random();
        bool isRegular = false;


       public Customer(string generatedName)
        {
            this.name = generatedName;
            this.maxPayment = MaxPayment();
            this.cupsBought = 0;
            this.cupsSkipped = 0;
            this.chanceOfPurchasing = DetermineChance();

           // Console.WriteLine("\t\tMy name is {0}, I'll spend maximum ${1}.  I have a {2}% chance of purchasing lemonade.", this.name, this.maxPayment, this.chanceOfPurchasing);
    
        }


        //regulars will visit the Lemonade stand every day, 
        //however it is very rare to get a regular
        public void MakeRegular(Customer customer) {
            this.isRegular = true;
            this.chanceOfPurchasing = 1.00;
        }

        private double MaxPayment()
        {
            int max = random.Next(15, 200);
            double convertToDecimal;
            this.maxPayment = System.Convert.ToDouble(max);
            convertToDecimal = this.maxPayment / 100.00;
            this.maxPayment = convertToDecimal;
            return this.maxPayment;
        }

        public bool BuyDrink(double price, double weatherMultiplier, double lemonadeTaste, double temperatureMultiplier, Player player)
        {
            //if this returns true, then they at least visist the lemonade stand. 
            if (chanceToBuy(this, weatherMultiplier)) {
                player.addVisitor(false);
                return checkChance(price, lemonadeTaste, temperatureMultiplier, player);
            }
            else
            {
                return false;
            }
        }

        private bool checkChance(double price, double lemonadeTaste, double temperatureMultiplier, Player player  )
        {
            double chance = random.NextDouble();
            if(chance < lemonadeTaste) { 
            //temperature controls how much people are willing to pay
            if (price <= (this.maxPayment*temperatureMultiplier))
            {
                Console.WriteLine("\t{0} has bought a glass for ${1}", this.name, price);
                cupsBought++;
                return true;
            }
            else
            {
                Console.WriteLine("\t{0} did not have enough money today.\nMaybe ${1} is too much?", this.name, price);
                cupsSkipped++;
                return false;
            }
            }
            else
            {
                Console.WriteLine("\t{0} thought your lemonade was too gross to buy.", this.name);
                cupsSkipped++;
                return false;
            }
        }

        private double DetermineChance()
        {
            double chance = random.NextDouble();
            chance = Math.Round(chance, 2);
            return chance;

        }

        private bool chanceToBuy(Customer customer, double chanceMultiplier)
        {
            double chance = random.NextDouble();
            if (chance < (customer.chanceOfPurchasing*chanceMultiplier))
            {
                return true;
            }
            else { return false; }

        }
    }
}
