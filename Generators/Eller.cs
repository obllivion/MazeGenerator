using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGenerator.Util;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGenerator.Generators
{
    class Eller : Generator
    {
        private int _set;
        private List<setStruct> setList;

        private struct setStruct
        {
            public int startPos;
            public int endPos;
            public int setNum;
        }

        public Eller(int w, int h)
        {
            width = w;
            height = h;

            maze = new MazeCellEller[width][];

            for (int i = 0; i < width; i++)
            {
                maze[i] = new MazeCellEller[height];

                for (int j = 0; j < height; j++)
                {
                    maze[i][j] = new MazeCellEller();
                    maze[i][j].X = i;
                    maze[i][j].Y = j;
                }
            }
            _set = 0;
            setList = new List<setStruct>();
        }

        public override void Generate()
        {
            int j=0;
            Random rand = new Random();

            while (j < height - 1)
            {
                for (int i = 0; i < width; i++)
                {
                    if ((maze[i][j] as MazeCellEller).Set == -1)
                        (maze[i][j] as MazeCellEller).Set = _set++;
                }
                                
                Dictionary<int, int> uniqueInt = new Dictionary<int, int>();
                for (int k = 0; k < width; k++)
                    uniqueInt[(maze[k][j] as MazeCellEller).Set] =  1;

                int toBeJoined = rand.Next(1, uniqueInt.Count);
                for (int i = 0; i < toBeJoined; i++)
                {
                    int nextJoin = rand.Next(0, width - 1);
                    while (maze[nextJoin][j].East != null && (maze[nextJoin][j] as MazeCellEller).Set == (maze[nextJoin + 1][j] as MazeCellEller).Set)
                        nextJoin = rand.Next(0, width - 1);

                    maze[nextJoin][j].East = maze[nextJoin + 1][j];
                    maze[nextJoin + 1][j].West = maze[nextJoin][j];
                }

                for (int i = 0; i < width - 1; i++)
                {
                    if (maze[i][j].East != null)
                    {
                        (maze[i][j].East as MazeCellEller).Set = (maze[i][j] as MazeCellEller).Set;
                    }
                }

                int ii = 0;
                while (ii < width)
                {
                    MazeCellEller current = maze[ii][j] as MazeCellEller;
                    setStruct sStruct = new setStruct();
                    sStruct.setNum = current.Set;
                    sStruct.startPos = current.X;
                    MazeCellEller next = current.East as MazeCellEller;
                    MazeCellEller last = current;
                    while (next != null)
                    {
                        last = next;
                        next = next.East as MazeCellEller;
                    }
                    sStruct.endPos = last.X;
                    setList.Add(sStruct);
                    ii = last.X + 1;
                }

                for (int i = 0; i < setList.Count; i++)
                {
                    int timesOpen = rand.Next(1, setList[i].endPos - setList[i].startPos + 1);

                    for (int jj = 0; jj < timesOpen; jj++)
                    {
                        int southPos = rand.Next(setList[i].startPos, setList[i].endPos);

                        while (maze[southPos][j].South != null)
                            southPos = rand.Next(setList[i].startPos, setList[i].endPos);

                        maze[southPos][j].South = maze[southPos][j + 1];
                        maze[southPos][j + 1].North = maze[southPos][j];
                        (maze[southPos][j + 1] as MazeCellEller).Set = (maze[southPos][j] as MazeCellEller).Set;
                    }
                }

                setList.Clear();
                j++;
            }

            for (int i = 0; i < width; i++)
            {
                if ((maze[i][j] as MazeCellEller).Set == -1)
                    (maze[i][j] as MazeCellEller).Set = _set++;
            }

            for (int i = 0; i < width - 1; i++)
            {
                if ((maze[i][j] as MazeCellEller).Set != (maze[i + 1][j] as MazeCellEller).Set)
                {
                    maze[i][j].East = maze[i + 1][j];
                    maze[i + 1][j].West = maze[i][j];
                }
            }
        }

        public override void Solve()
        {
            throw new NotImplementedException();
        }

        public void DrawMaze(GroupBox canvas)
        {
            Pen myPen = new System.Drawing.Pen(Color.Red);

            Graphics fGraphics = canvas.CreateGraphics();
            fGraphics.Clear(Color.Gray);

            //fGraphics.DrawLine(myPen, 0, 0, 100, 100);
            int size = 20;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    MazeCellEller currCell = maze[i][j] as MazeCellEller;

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

            myPen.Dispose();
            fGraphics.Dispose();
        }
    }
}
