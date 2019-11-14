using System;
using JB_SWResupplyCalculationCore.Helpers;
using JB_SWResupplyCalculationCore.Entities;
using SharpTrooper.Entities;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace JB_SWResupplyCalculationCore
{
    public class Calculations
    {
        //HoursUntilResupply = consumables converted to years * 24 * 365
        //MGLT until Resupply = MGLT * HoursUntilResupply
        //Stops = input mglt / MGLT until Resupply


        public string BadDataResponse = "Not enough data to calculate";
        private string consumablesRegex = @"[0-9]\b\s(hour|hours|days|day|weeks|week|months|month|years|year)\b";
        private string numericRegex = @"^[0-9-]+$";

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


            if(canBeCalculated(starship))
            {
                double consumablesInHours = convertConsumablesToHours(starship.consumables);
                int mglt = parseMGLT(starship.mglt);

                if (consumablesInHours > 0 && mglt > 0)
                {
                    starshipOverride.consumablesInHours = consumablesInHours;
                    starshipOverride.necessaryResupply = Math.Floor(distance / (mglt * consumablesInHours));
                    
                    starshipOverride.necessaryResupplyString = starshipOverride.necessaryResupply.ToString();
                }
                else //Means it can't calculate how long until next stop.
                {

                    starshipOverride.necessaryResupplyString = BadDataResponse;
                }
            }
            else
            {
                starshipOverride.necessaryResupplyString = BadDataResponse;
            }

            return starshipOverride;
        }
        public bool canBeCalculated(Starship starship)
        {
            bool regexConsumables = Regex.IsMatch(starship.consumables, consumablesRegex, RegexOptions.IgnoreCase);
            bool regexMGLT = Regex.IsMatch(starship.mglt, numericRegex);

            if (String.IsNullOrWhiteSpace(starship.consumables) ||
                String.IsNullOrWhiteSpace(starship.mglt) || 
                !regexConsumables||
                !regexMGLT)
            {
                return false;
            }
            return true;

        }

        public int parseMGLT(string mgltString)
        {
            int parsedMGLT = 0;

            Regex regex = new Regex(@"^([0-9])*$");
            if (regex.IsMatch(mgltString)) //Only try to parse to int if it's numberic only
            {
                parsedMGLT = Int32.Parse(mgltString);
            }

            return parsedMGLT;

        }

        public double convertConsumablesToHours(string consumables)
        {
            double consumablesInHours = 0;
            if (string.IsNullOrWhiteSpace(consumables))
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

                case TimeFrames.Hours:
                case TimeFrames.Hour:
                    consumablesInHours = unit;
                    break;

                default:
                    consumablesInHours = 0;
                    break;
            }
            return consumablesInHours;
        }
    }
}
