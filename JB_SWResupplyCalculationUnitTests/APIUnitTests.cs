using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTrooper.Core;
using SharpTrooper.Entities;

namespace JB_SWResupplyCalculationUnitTests
{
    [TestClass]
    public class APIUnitTests
    {
        SharpTrooperCore sharpTrooperClient = new SharpTrooperCore();

        [TestMethod]
        public void ConnectivityTest()
        {
            People people = sharpTrooperClient.GetPeople("1");
            Assert.IsTrue(people.name.Length > 0);
        }

        //Only doing Connectivity Test at this stage.

    }
}
