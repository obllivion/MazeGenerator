using MazeGenerator.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGenerator.Generators
{
    abstract class Generator
    {
        public MazeCell[][] maze;

        protected int width, height;

        public Point startPosition;

        public Point finalDestination;

        public abstract void Generate();

        public abstract void Solve();

        public void DrawMaze(GroupBox canvas)
        {
            Pen myPen = new System.Drawing.Pen(Color.Red);
            SolidBrush mBrush = new SolidBrush(Color.LawnGreen);
            Graphics fGraphics = canvas.CreateGraphics();
            fGraphics.Clear(Color.Gray);

            Random rand = new Random();

            startPosition = new Point(rand.Next(0, width), rand.Next(0, height));
            finalDestination = new Point(rand.Next(0, width), rand.Next(0, height));

            int size = 20;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    MazeCell currCell = maze[i][j];

                    if (currCell.North == null)
                        fGraphics.DrawLine(myPen, i * size, j * size, (i + 1) * size, j * size);

                    if (currCell.South == null)
                        fGraphics.DrawLine(myPen, i * size, (j + 1) * size, (i + 1) * size, (j + 1) * size);

                    if (currCell.East == null)
                        fGraphics.DrawLine(myPen, (i + 1) * size, j * size, (i + 1) * size, (j + 1) * size);

                    if (currCell.West == null)
                        fGraphics.DrawLine(myPen, i * size, j * size, i * size, (j + 1) * size);
                }
            }

            //drawing startin and ending point
            fGraphics.FillRectangle(mBrush, startPosition.X * size + size / 2, startPosition.Y * size + size / 2, size / 2, size / 2);
            mBrush.Color = Color.SteelBlue;
            fGraphics.FillRectangle(mBrush, finalDestination.X * size + size / 2, finalDestination.Y * size + size / 2, size / 2, size / 2);

            myPen.Dispose();
            fGraphics.Dispose();
            mBrush.Dispose();
        }
    }
}
