using System;
using System.Collections.Generic;
using JB_SWResupplyCalculationCore.Entities;

namespace JB_SWResupplyCalculationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 1000000;
            JB_SWResupplyCalculationCore.Calculations calculations = new JB_SWResupplyCalculationCore.Calculations();
            List<StarshipOverride> results = calculations.calculateResuppliesForAll(input);

            Console.WriteLine("Given the distance in Mega Lights of " + input);

            foreach (StarshipOverride starshipOverride in results)
            {
                Console.WriteLine("Starship name: " +starshipOverride.name + " MGLT: "+starshipOverride.mglt+" - Consumables: "+starshipOverride.consumables +" - Necessary Resuplies: "+starshipOverride.necessaryResupply);
            }

            Console.ReadKey();
        }
    }
}
