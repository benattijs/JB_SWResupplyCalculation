using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JB_SWResupplyCalculationCore.Entities;

namespace JB_SWResupplyCalculationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = 0;
            while (distance==0)
            { 
                Console.WriteLine("Please enter a valid travel distance in MegaLights (only numbers greater than zero allowed): ");
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, @"^[0-9-]+$"))//If matches to only numbers, parse input, otherwise ask for the input again
                {
                    distance = Int32.Parse(input);
                }
                
            }
            Console.Clear();
            Console.WriteLine("Please wait while we do our maths...\n");

            JB_SWResupplyCalculationCore.Calculations calculations = new JB_SWResupplyCalculationCore.Calculations();
            List<StarshipOverride> results = calculations.calculateResuppliesForAll(distance);

            Console.WriteLine("Given the distance in MegaLights of " + distance);

            foreach (StarshipOverride starshipOverride in results)
            {
                Console.WriteLine("\n  Starship name: " + starshipOverride.name + " \n" +
                                    " Stops required: " + starshipOverride.necessaryResupplyString);
            }

            Console.ReadKey();
        }
    }
}
