using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGenerator.Util;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace MazeGenerator.Solvers
{
    class RandomMouse : Solver
    {
        Random rnd;

        public RandomMouse(MazeCell[][] mc, Point sp, Point ep)
        {
            maze = mc;
            startPoint = sp;
            endPoint = ep;
        }

        public override void Solve(MainForm form)
        {
            rnd = new Random();
            bool foundExit = false;
            Point nextPoint, currentPoint;
            currentPoint = startPoint;
            Point prevPoint = new Point(-1,-1);

            while (!foundExit)
            {
                
                nextPoint = chooseNextPosition(currentPoint, prevPoint, form);

                if (currentPoint.X == endPoint.X && currentPoint.Y == endPoint.Y)
                {
                    foundExit = true;
                    continue;
                }

                form.UpdateStatus(currentPoint, nextPoint);

                prevPoint = currentPoint;
                currentPoint = nextPoint;
                Thread.Sleep(100);
            }

        }

        private Point chooseNextPosition(Point curr, Point prevPoint, MainForm mFrom)
        {
            MazeCell mc = maze[curr.X][curr.Y];

            List<Point> availableMoves = new List<Point>();

            if (mc.East != null)
                availableMoves.Add(new Point(curr.X + 1, curr.Y));
            if(mc.South != null)
                availableMoves.Add(new Point(curr.X, curr.Y + 1));
            if (mc.West != null)
                availableMoves.Add(new Point(curr.X - 1, curr.Y));
            if (mc.North != null)
                availableMoves.Add(new Point(curr.X, curr.Y - 1));

            if (prevPoint.X != -1 && availableMoves.Count > 1)
                availableMoves.Remove(prevPoint);
            else
                mFrom.ChangePen();

            int nextP = rnd.Next(0, availableMoves.Count);

            return availableMoves[nextP];
        }
    }
}
