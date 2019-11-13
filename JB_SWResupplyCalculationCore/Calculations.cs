using System;
using JB_SWResupplyCalculationCore.Helpers;
using JB_SWResupplyCalculationCore.Entities;
using SharpTrooper.Entities;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace JB_SWResupplyCalculationCore
{
    public class Calculations
    {   //HoursUntilResupply = consumables converted to years * 24 * 365
        //MGLT until Resupply = MGLT * HoursUntilResupply()
        //imput mglt / MGLT until Resupply
        public List<StarshipOverride> calculateResuppliesForAll(int distance)
        { 
            SharpTrooperHelper helper = new SharpTrooperHelper();
            List<Starship> results = helper.GetAllStarships();

            List<StarshipOverride> resultOverride = new List<StarshipOverride>();

            foreach (Starship starship in results)
            {
                resultOverride.Add(mapToEntityWithValues(starship, distance));
            }
            return resultOverride;

        }

        public StarshipOverride mapToEntityWithValues(Starship starship, int distance)
        {
            StarshipOverride starshipOverride = new StarshipOverride();

            starshipOverride.name = starship.name;
            starshipOverride.mglt = starship.mglt;
            starshipOverride.consumables = starship.consumables;


            if (starship.consumables.Contains("unknown") || starship.mglt.Contains("unknown"))
            {
                starshipOverride.necessaryResupply = "unknown";
            }
            else
            {
                double consumablesInHours = convertConsumablesToHours(starship.consumables);
                starshipOverride.consumablesInHours = consumablesInHours.ToString();
                starshipOverride.necessaryResupply = Math.Floor(distance / (parseMGLT(starship.mglt) * consumablesInHours)).ToString();

            }

            return starshipOverride;
        }

        public int parseMGLT(string mgltString)
        {
            int parsedMGLT = 0;

            Regex regex = new Regex(@"[0-9-]");
            if (regex.IsMatch(mgltString)) //Only try to parse to int if it's numberic
            {
                parsedMGLT = Int32.Parse(mgltString);
            }

            return parsedMGLT;

        }

        public double convertConsumablesToHours(string consumables)
        {
            double consumablesInHours = 0;
            if (string.IsNullOrWhiteSpace(consumables) || consumables.Contains("unknown"))
            {
                return consumablesInHours;
            }

            double unit = Double.Parse(consumables.Substring(0, consumables.IndexOf(" ")).Trim());
            string period = consumables.Substring(consumables.IndexOf(" ")).Trim();

            switch (period.ToLower())
            {
                case TimeFrames.Years:
                case TimeFrames.Year:
                    consumablesInHours = unit * 365 * 24;
                    break;

                case TimeFrames.Months:
                case TimeFrames.Month:
                    consumablesInHours = (double)(unit / 12) * 365 * 24;
                    break;

                case TimeFrames.Weeks:
                case TimeFrames.Week:
                    consumablesInHours = unit * 7 * 24;
                    break;

                case TimeFrames.Days:
                case TimeFrames.Day:
                    consumablesInHours = unit * 24;
                    break;

                default:
                    consumablesInHours = 0;
                    break;
            }
            return consumablesInHours;
        }
    }
}
