using System;
using System.Collections.Generic;
using System.Text;
using SharpTrooper.Entities;

namespace JB_SWResupplyCalculationCore.Entities
{
    public class StarshipOverride : Starship
    {
        public double consumablesInHours
        {
            get;
            set;
        }
        public double necessaryResupply
        {
            get;
            set;
        }
        public string necessaryResupplyString
        {
            get;
            set;
        }
    }
}
