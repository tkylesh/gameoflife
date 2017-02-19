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

        int[,] contents = new int[50, 50];//Where's my origin?
        // ^ 2-D array of zeros!! :D

        List<string> about_to_live = new List<string>();
        List<string> about_to_die = new List<string>();

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
            throw new NotImplementedException();
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

       public List<object> GetDeadNeighbors(int x, int y)
        {
            throw new NotImplementedException();
        }

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
        public void LiveOn(object input)
        {
            throw new NotImplementedException();
        }

        public void OverPopulation(object input)
        {
            throw new NotImplementedException();
        }

        public void Reproduction(object input)
        {
            //Iterate to find live cells and find their dead neighbors.
            //GetDeadNeighbors
            //Iterate through all collected dead neighbors and call CountLiveNeighbors
            //Stash the dead cells that have more than 3 live neighbors then add it to the
            //about_to_live list
            throw new NotImplementedException();
        }

        public void UnderPopulation(object input)
        {
            for (int y = 0; y < 50; y++)
            {
                for (int x = 0; x < 50; x++)
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
