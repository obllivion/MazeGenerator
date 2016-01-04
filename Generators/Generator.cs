using MazeGenerator.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.Generators
{
    abstract class Generator
    {
        protected MazeCell[][] maze;

        protected int width, height;

        protected Point startPosition;

        public abstract void Generate();
        public abstract void Solve();
    }
}
