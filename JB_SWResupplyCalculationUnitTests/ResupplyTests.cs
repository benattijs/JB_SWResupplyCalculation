using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTrooper.Entities;
using JB_SWResupplyCalculationCore.Entities;


namespace JB_SWResupplyCalculationUnitTests
{
    [TestClass]
    public class ResupplyTests
    {
        JB_SWResupplyCalculationCore.Calculations helper = new JB_SWResupplyCalculationCore.Calculations();

        [TestMethod]
        public void MilleniumFalconTest()
        {
            //distance = 1,000,000
            /*
            {
            "name": "Millennium Falcon",
            "consumables": "2 months", 
            "MGLT": "75", 
            }, 
             */
            int distance = 1000000;
            Starship starship = returnStartshipObject("Millennium Falcon", "75", "2 months");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("9", calculation.necessaryResupplyString);
        }

        [TestMethod]
        public void YwingTest()
        {
            //distance = 1,000,000
            /*
            {
            "name": "Y-Wing",
            "consumables": "1 week", 
            "MGLT": "80", 
            }, 
             */
            int distance = 1000000;
            Starship starship = returnStartshipObject("Y-wing", "80", "1 week");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("74", calculation.necessaryResupplyString);
        }

        [TestMethod]
        public void RebelTransportTest()
        {
            //distance = 1,000,000
            /*
            {
            "name": "Rebel transport",
            "consumables": "6 months", 
            "MGLT": "20", 
            }, 
             */
            int distance = 1000000;
            Starship starship = returnStartshipObject("Rebel transport", "20", "6 months");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("11", calculation.necessaryResupplyString);
        }


        [TestMethod]
        public void _15HoursResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInDays", "630", "15 hours");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("105", calculation.necessaryResupplyString);
        }


        [TestMethod]
        public void _1HourResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInDays", "630", "1 hour");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("1587", calculation.necessaryResupplyString);
        }

        [TestMethod]
        public void _15DaysResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInDays", "120", "15 days");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("23", calculation.necessaryResupplyString);
        }


        [TestMethod]
        public void _1DayResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInDays", "120", "1 day");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("347", calculation.necessaryResupplyString);
        }


        [TestMethod]
        public void _15WeeksResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInWeeks", "40", "15 Weeks");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("9", calculation.necessaryResupplyString);
        }

        [TestMethod]
        public void _1WeekResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInWeek", "40", "1 week");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("148", calculation.necessaryResupplyString);
        }
        [TestMethod]
        public void _7MonthsResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInMonths", "60", "7 months");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("3", calculation.necessaryResupplyString);
        }

        [TestMethod]
        public void _1MonthResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInMonth", "60", "1 Month");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("22", calculation.necessaryResupplyString);
        }
        [TestMethod]
        public void _3YearsResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInYears", "8", "3 Years");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("4", calculation.necessaryResupplyString);
        }

        [TestMethod]
        public void _1YearResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeInYear", "8", "1 year");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual("14", calculation.necessaryResupplyString);
        }


        [TestMethod]
        public void _UnknownMGLTResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeShip", "unknown", "3 Years");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual(helper.BadDataResponse, calculation.necessaryResupplyString);
        }

        [TestMethod]
        public void _UnknownConsumablesTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeShip", "5", "unknown");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual(helper.BadDataResponse, calculation.necessaryResupplyString);
        }


        [TestMethod]
        public void _ZeroMGLTResupplyTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeShip", "0", "3 Years");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual(helper.BadDataResponse, calculation.necessaryResupplyString);
        }

        [TestMethod]
        public void _ZeroConsumablesTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeShip", "5", "0 years");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual(helper.BadDataResponse, calculation.necessaryResupplyString);
        }


        [TestMethod]
        public void _WrongConsumablesTest()
        {
            //distance = 1,000,000
            int distance = 1000000;
            Starship starship = returnStartshipObject("FakeShip", "5", "4 fortnights");
            StarshipOverride calculation = returnCalculations(starship, distance);
            Assert.AreEqual(helper.BadDataResponse, calculation.necessaryResupplyString);
        }

        private Starship returnStartshipObject(string name, string mglt, string consumables)
        {
            Starship starship = new Starship();
            
            starship.name = name;
            starship.mglt = mglt;
            starship.consumables = consumables;

            return starship;
        }

        private StarshipOverride returnCalculations(Starship starship, int distance)
        {
            return helper.mapToEntityWithValues(starship, distance);
        }
        //unkwodn MGTL
        //Dividing by zero
        //Wrong consbumables
        //0days
        //0mglt
    }
}
