using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.Util
{
    class MazeCellEller : MazeCell
    {
        public int Set { get; set; }

        public MazeCellEller() : base()
        {
            Set = -1;
        }
    }
}
