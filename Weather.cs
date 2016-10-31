using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public double weatherMultiplier;
        public bool weatherActive;
        public double temperatureMultiplier;
        public string weatherMessage;
        public string temperatureMessage;
        Random random = new Random();

        //Weather options are stored in an integer

        public void Forecast()
        {
            GetWeather();
            getTemperature();
        }

        public void RealWeather()
        {
            if (random.NextDouble() < .6)
            {
                weatherOn();
                //  Console.WriteLine("Seems like the forecaster was right!  It's {0} and {1}.", weatherMessage, temperatureMessage);
            }
            else
            {
                weatherOff();

            }
        }

        private void GetWeather()
        {
            int weatherPick = weatherOptionRange();
            switch (weatherPick)
            {    //sunny weather offers an advantage because more people are outside
                case 0:
                    weatherMultiplier = 2;
                    weatherMessage = "sunny";
                    break;
                //rainy weather keeps people away 
                case 1:
                    weatherMultiplier = .25;
                    weatherMessage = "rainy";
                    break;
                //cloudy weather offers a slight disadvantage
                case 2:
                    weatherMultiplier = .75;
                    weatherMessage = "cloudy";
                    break;
                //partly sunny offers no advantage of disadvantage
                case 3:
                    weatherMultiplier = 1;
                    weatherMessage = "partly sunny";
                    break;
            }

        }

        //generates a random number 1-10 to allow different weather and temperature options to happen at different rates
        private int weatherOptionRange()
        {
            int randomWeather = random.Next(0, 10);
            if (randomWeather >= 0 && randomWeather <= 1)
            {
                return 0;
            }
            else if (randomWeather >= 2 && randomWeather < 3)
            {
                return 1;
            }
            else if (randomWeather >= 3 && randomWeather <= 4)
            {
                return 2;
            }
            else
            {
                return 3;
            }

        }

        private void getTemperature()
        {
            int temperaturePick = TemperatureOptionRange();
            switch (temperaturePick)
            {
                //hot weather makes people buy more lemonade
                case 0:
                    temperatureMultiplier = 2;
                    temperatureMessage = "hot";
                    break;
                //no one wants lemonade when it's cold
                case 1:
                    temperatureMultiplier = .50;
                    temperatureMessage = "cold";
                    break;
                //when it's balmy, there is no advantage or disadvantage
                case 2:
                    temperatureMultiplier = 1;
                    temperatureMessage = "balmy";
                    break;
            }

        }

        private int TemperatureOptionRange()
        {

            int randomWeather = random.Next(0, 10);
            if (randomWeather >= 0 && randomWeather <= 2)
            {
                return 0;
            }
            else if (randomWeather >= 3 && randomWeather <= 4)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private void weatherOn()
        {
            this.weatherActive = true;

        }
        private void weatherOff()
        {

            this.weatherActive = false;
            weatherMessage = "partly sunny";
            temperatureMessage = "balmy";
            temperatureMultiplier = 1;
            weatherMultiplier = 1;
        }
    }
}
