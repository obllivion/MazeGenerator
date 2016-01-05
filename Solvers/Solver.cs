using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGenerator.Util;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGenerator.Solvers
{
    abstract class Solver
    {
        protected MazeCell[][] maze;
        protected Point startPoint, endPoint;

        public abstract void Solve(MainForm mForm);
    }
}
