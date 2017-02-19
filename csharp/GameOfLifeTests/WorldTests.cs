using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void EnsureICanCreateTheWorld()
        {
            //view port/ size of world
            int[,] cell_holder = { { 2, 10 }, { 50,50 } };

            World world = new World(cell_holder);

            Assert.IsNotNull(world);

        }

        [TestMethod]
        public void EnsureReproductionWithStillLife()
        {

        }

        [TestMethod]
        public void EnsureOverPopulationWithStillLife()
        {

        }

        [TestMethod]
        public void EnsureUnderPopulationWithStillLife()
        {

        }

        [TestMethod]
        public void EnsureLiveOnWithOscillator()
        {

        }

        [TestMethod]
        public void EnsureICanCountLiveNeighbors()
        {
            //How do we inject live cells into out World?
            /*int[,] cell_holder = new int[2,4];*/  //4-cells each with 2 coordinates
            //cell_holder[0, 0] = 17; //Live cell at coordinate (17,17)
            //cell_holder[1, 0] = 17;

            //same as above
            int[,] cell_holder = { { 17, 17 }, {17, 18 } };


            World world = new World(cell_holder);
            

            //Act
           int actual_count = world.CountLiveNeighbors(17, 17);
            int expected_count = 1;
            Assert.AreEqual(expected_count, actual_count);
        }

        [TestMethod]
        public void EnsureReproductionWithOscillator()
        {

        }
    }
}
