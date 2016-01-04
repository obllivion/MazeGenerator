using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.Util
{
    enum Sides
    {
        East,
        West,
        North,
        South
    };

    class MazeCell
    {
        private MazeCell east, west, north, south;

        public int Visited { get; set; }

        public int X, Y;

        public MazeCell East
        {
            get
            {
                return east;
            }
            set
            {
                east = value;
            }
        }

        public MazeCell West
        {
            get
            {
                return west;
            }
            set
            {
                west = value;
            }
        }

        public MazeCell North
        {
            get
            {
                return north;
            }
            set
            {
                north = value;
            }
        }

        public MazeCell South
        {
            get
            {
                return south;
            }
            set
            {
                south = value;
            }
        }

        public MazeCell()
        {
            east = west = north = south = null;
            X = Y = -1;
            Visited = 0;
        }
    }
}
