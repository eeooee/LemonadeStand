﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        string input;
        string path = @"";
        public string loadedName = "";
        public double wallet;
        public double profit;
        Display display = new Display();
        Time time = new Time();

        public Player SetUp()
        {
            input = Console.ReadLine();
            if (input.ToLower().Contains("continue"))
            {
                readFile();
                Console.WriteLine("Welcome back {0}.  You currently have ${1}, and you've made {2} total.", loadedName, wallet, profit);
                Console.ReadLine();


                return new Player(loadedName, wallet, profit);

            }
            else
            {
                Player tycoon = new Player();
                Console.ReadLine();
                return tycoon;
            }
        }

        public void Start(Player player)
        {
            display.rules(player);
            int days = pickDays();
            CheckDays(player, days);
        }

        public void CheckDays(Player player, int days)
        {
            if (days <= 0)
            {
                return;
            }
            else
            {
                time.PlayForDays(player, days);
                display.Done(player);
                Console.ReadLine();

            }
        }

        private void LoadGame(string path)
        {
            using (StreamReader stream = new StreamReader(path))
            {
                string s = "";
                while ((s = stream.ReadLine()) != null)
                {
                    loadedName = s;
                    wallet = Double.Parse(stream.ReadLine());
                    profit = Double.Parse(stream.ReadLine());
                }
            }
        }

        private void readFile()
        {

            Console.WriteLine("Enter the name of your save file.  It's your player's name.");
            path = Console.ReadLine();
            if (File.Exists(path))
            {

                LoadGame(path);
            }
            else
            {
                readFile();
            }
        }

        public static void saveFile(Player player)
        {
            string fileName = player.name;
            //creates a new save file named after the player.  false operand ensures that if the file xists already that it is written over 
            using (StreamWriter stream = new StreamWriter(fileName, false))
            {
                stream.WriteLine(player.name);
                stream.WriteLine(player.money);
                stream.WriteLine(player.profit);
            }
        }

        public int pickDays()
        {
            string input = Console.ReadLine();
            if (input.Contains("yes"))
            {
                int days = checkDays();
                return days;

            }
            else
            {
                return -1;
            }
        }

        public static int checkDays()
        {
            int days = -1;
            Console.WriteLine("\tHow many days do you want to play for?");
            string input = Console.ReadLine();
            int.TryParse(input, out days);
            return days;
        }
    }
}
