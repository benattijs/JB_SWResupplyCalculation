using System;
using System.Collections.Generic;
using System.Text;
using SharpTrooper.Entities;

namespace JB_SWResupplyCalculationCore.Entities
{
    public class StarshipOverride : Starship
    {
        public string consumablesInHours
        {
            get;
            set;
        }
        public string necessaryResupply
        {
            get;
            set;
        }
    }
}
