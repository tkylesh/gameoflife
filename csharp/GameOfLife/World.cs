using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World : IGameOfLife
    {
        //Conway's Game of Life The Rules
        //    1.  Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        //    2.  Any live cell with two or three live neighbours lives on to the next generation.
        //    3.  Any live cell with more than three live neighbours dies, as if by overcrowding.
        //    4.  Any dead cell with exactly three live neighbours becomes alive cell, as if by reproduction.

        int[,] contents = new int[50, 50];//Where's my origin?
        // ^ 2-D array of zeros!! :D

        public List<string> about_to_live = new List<string>();
        public List<string> about_to_die = new List<string>();

        public World()
        {

        }

        public World(int[,] live_cells)//cell_holder are live cells in 50x50 grid world
        {
            for(int i = 0; i < (live_cells.Length)/2; i++)
            {
                //i represents a live cell (position)
                int live_cell_x_coord = live_cells[i, 0];
                int live_cell_y_coord = live_cells[i, 1];

                //It's Alive!!!
                contents[live_cell_x_coord, live_cell_y_coord] = 1; 
                
            }
        }

        private void BirthCells()
        {
            //look inside of about_to_live 
            foreach(string cell in about_to_live)
            {
                //(x,y)
                Match coord = Regex.Match(cell, @"((?<x>\d+),(?<y>\d+))");
                //and set position to 1 
                int x = int.Parse(coord.Groups['x'].Value);
                int y = int.Parse(coord.Groups['y'].Value);
                //add them to the contents
                contents[x, y] = 1;
            }
        }

        private void KillCells()
        {
            //look inside of about_to_die and set position to 0 
            //(x,y)
            foreach (string cell in about_to_die)
            {
                Match coord = Regex.Match(cell, @"((?<x>\d+),(?<y>\d+))");
                int x = int.Parse(coord.Groups['x'].Value);
                int y = int.Parse(coord.Groups['y'].Value);
                contents[x, y] = 0;
            }
        }

        public void Tick() //represents passsage of time
        {
            LiveOn(null);
            Reproduction(null);
            UnderPopulation(null);
            OverPopulation(null);

            KillCells(); //cells will be removed from defined grid
            BirthCells(); //cells will be brought into existence on defined grid
        }

        // 1.Needs to be a method to retrieve dead neighbors
        // 2.now count the live neighbors relative to the dead neighbors positions

       public List<int> GetDeadNeighbors(int x, int y)
        {
            //get all neighbors like in countliveneighbors method
            int top, bottom, left, right, top_left, top_right;
            int bottom_left, bottom_right;

            top = contents[x, y + 1];
            bottom = contents[x, y - 1];
            left = contents[x - 1, y];
            right = contents[x + 1, y];
            bottom_left = contents[x - 1, y - 1];
            top_left = contents[x - 1, y + 1];
            bottom_right = contents[x + 1, y - 1];
            top_right = contents[x + 1, y + 1];

            //if neighboring cell == 0
            List<int> temp = new List<int> { top, bottom, left, right, bottom_left, bottom_right, top_left, top_right };

            List<int> returnList = new List<int> { };
            // add to list
            foreach(var item in temp)
            {
                if(item == 0)
                {
                    returnList.Add(item);
                }
            }
            //return list
            return returnList;
        }

        //pass an x and y value to check all neighboring cells for live cell
        public int CountLiveNeighbors(int x, int y)
        {
            int top, bottom, left, right, top_left, top_right;
            int bottom_left, bottom_right;

            top = contents[x, y + 1];
            bottom = contents[x, y - 1];
            left = contents[x-1, y];
            right = contents[x+1, y];
            bottom_left = contents[x-1, y-1];
            top_left = contents[x-1, y+1];
            bottom_right = contents[x+1 , y-1];
            top_right = contents[x+1, y+1];

            return top + bottom + bottom_left + bottom_right + left + right + top_left + top_right;
        }

        //    2.  Any live cell with two or three live neighbours lives on to the next generation.
        public void LiveOn(object input)
        {
            throw new NotImplementedException();
        }

        //    3.  Any live cell with more than three live neighbours dies, as if by overcrowding.
        public void OverPopulation(object input)
        {
            for (int y = 1; y < 49; y++)
            {
                for (int x = 1; x < 49; x++)
                {
                    if (contents[y, x] == 1)
                    {
                        //cell is alive
                        int neighbors = CountLiveNeighbors(x, y);
                        if (neighbors > 3)
                        {
                            about_to_die.Add($"({x},{y})");
                        }

                    }

                }
            }
        }

        //    4.  Any dead cell with exactly three live neighbours becomes alive cell, as if by reproduction.
        public void Reproduction(object input)
        {
            //Iterate to find live cells and find their dead neighbors.
            for(var x=1; x<49; x++)
            {
                for(var y=1; y<49; y++)
                {
                    //GetDeadNeighbors
                    if(contents[x,y]==0)
                    {
                        //Iterate through all collected dead neighbors and call CountLiveNeighbors
                        //Stash the dead cells that have more than 3 live neighbors then add it to the
                        //about_to_live list
                        int neighbors = CountLiveNeighbors(x, y);
                        if(neighbors == 3)
                        {
                            about_to_live.Add($"({x},{y})");
                        }
                    }
                }
            }
        }

        //    1.  Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        public void UnderPopulation(object input)
        {
            for (int y = 1; y < 49; y++)
            {
                for (int x = 1; x < 49; x++)
                {
                    if(contents[y,x] == 1)
                    {
                        //cell is alive
                        int neighbors = CountLiveNeighbors(x, y);
                        if(neighbors < 2)
                        {
                            about_to_die.Add($"({x},{y})");
                        }

                    }

                }
            }
        }
    }
}
