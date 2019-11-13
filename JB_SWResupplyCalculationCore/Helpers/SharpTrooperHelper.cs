using System;
using System.Collections.Generic;
using System.Text;
using JB_SWResupplyCalculationCore.Entities;
using SharpTrooper.Core;
using SharpTrooper.Entities;

namespace JB_SWResupplyCalculationCore.Helpers
{
    public class SharpTrooperHelper
    {

        //public SharpEntityResults<StarshipOverride> GetAllStarships(string pageNumber = "1")
        //{

        //}
        public List<Starship> GetAllStarships(string pageNumber = "1")
        {
            string nextPage = pageNumber;
            //int currentPage = 0;
            List<Starship> resultList = new List<Starship>();
            while (!String.IsNullOrWhiteSpace(nextPage))//Make multiple calls until next page is null.
            {
                SharpTrooperCore sharpTrooperClient = new SharpTrooperCore();
                SharpEntityResults<Starship> result = sharpTrooperClient.GetAllStarships(nextPage);
                
                //Add results to Returning List
                resultList.AddRange(result.results);

                nextPage = result.nextPageNo;
            }
            //SharpEntityResults<StarshipOverride> resultOverride = new SharpEntityResults<StarshipOverride>();
            //resultOverride.results = new List<StarshipOverride>();

            //foreach (Starship starship in result.results)
            //{
            //    StarshipOverride starshipOverride = new StarshipOverride();
                
            //    resultOverride.results.Add(starshipOverride);
                
            //}
            return resultList;
            
        }
         
    }
}
