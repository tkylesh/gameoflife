using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public interface IGameOfLife
    {
        //a black cell with less than 2 black neighbours goes white
        //a black cell with 2 or 3 black neighbours stays the same
        //a black cell with more than 3 black neighbours goes white
        //a white cell with three black neighbours becomes black

        //4 Rules of Conway's Game of Life
        //    4.  Any dead cell with exactly three live neighbours becomes alive cell, as if by reproduction.
        void Reproduction(object input);
        //1.  Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        void UnderPopulation(object input);
        //    3.  Any live cell with more than three live neighbours dies, as if by overcrowding.
        void OverPopulation(object input);
        //    2.  Any live cell with two or three live neighbours lives on to the next generation.
        void LiveOn(object input);
    }
}
