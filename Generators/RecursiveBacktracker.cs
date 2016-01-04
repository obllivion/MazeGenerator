using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using MazeGenerator.Util;

namespace MazeGenerator.Generators
{
    class RecursiveBacktracker : Generator
    {
        private Stack<MazeCell> stack;
        int totalNumber;

        public RecursiveBacktracker(int w, int h)
        {
            width = w;
            height = h;
            totalNumber = w * h;

            maze = new MazeCell[width][];

            for (int i = 0; i < width; i++)
            {
                maze[i] = new MazeCell[height];

                for (int j = 0; j < height; j++)
                {
                    maze[i][j] = new MazeCell();
                    maze[i][j].X = i;
                    maze[i][j].Y = j;
                }
            }

            Random rand = new Random();

            startPosition = new Point(rand.Next(0, width), rand.Next(0, height));

            stack = new Stack<MazeCell>();

        }

        public override void Generate()
        {
            Generate(maze[startPosition.X][startPosition.Y]);

            //crtkanje
        }

        static int Compare1(KeyValuePair<Sides, int> a, KeyValuePair<Sides, int> b)
        {
            return b.Value.CompareTo(a.Value);
        }

        public void Generate(MazeCell current, Point position)
        {
            if (current == null)
                return;

            while (totalNumber > 0)
            {
                current.Visited = 2;
                position.X = current.X;
                position.Y = current.Y;

                // Randomize
                Random rand = new Random();
                int east = rand.Next(0, 99);
                int west = rand.Next(0, 99);
                int north = rand.Next(0, 99);
                int south = rand.Next(0, 99);

                List<KeyValuePair<Sides, int>> paths = new List<KeyValuePair<Sides, int>>();
                paths.Add(new KeyValuePair<Sides, int>(Sides.East, east));
                paths.Add(new KeyValuePair<Sides, int>(Sides.West, west));
                paths.Add(new KeyValuePair<Sides, int>(Sides.North, north));
                paths.Add(new KeyValuePair<Sides, int>(Sides.South, south));

                paths.Sort(Compare1);

                // to be separated...
                List<KeyValuePair<Sides, int>> filteredPaths = findUnvisited(paths, position);

                if (filteredPaths.Count == 0)
                {
                    current = stack.Pop();
                    position.X = current.X;
                    position.Y = current.Y;
                }

                var path = filteredPaths[0];

                if (path.Key == Sides.East)
                {
                    current.East = maze[position.X + 1][position.Y];
                    maze[position.X + 1][position.Y].West = current;
                    stack.Push(current);
                    current = maze[position.X + 1][position.Y];
                    totalNumber--;
                }

                if (path.Key == Sides.West)
                {
                    current.West = maze[position.X - 1][position.Y];
                    maze[position.X - 1][position.Y].East = current;
                    stack.Push(current);
                    current = maze[position.X - 1][position.Y];
                    current.X = position.X - 1;
                    current.Y = position.Y - 1;
                    totalNumber--;
                }

                if (path.Key == Sides.North)
                {
                    current.North = maze[position.X][position.Y - 1];
                    maze[position.X][position.Y - 1].South = current;
                    stack.Push(current);
                    current = maze[position.X][position.Y - 1];
                    totalNumber--;
                }

                if (path.Key == Sides.South)
                {
                    current.South = maze[position.X][position.Y + 1];
                    maze[position.X][position.Y + 1].North = current;
                    stack.Push(current);
                    current = maze[position.X][position.Y + 1];
                    totalNumber--;
                }
            }
        }

        public void Generate(MazeCell current)
        {
            current.Visited = 2;

            while (totalNumber > 0)
            {
                //current = stack.Pop();

                Random rand = new Random();
                int east = rand.Next(0, 99999);
                int west = rand.Next(0, 99999);
                int north = rand.Next(0, 99999);
                int south = rand.Next(0, 99999);

                List<KeyValuePair<Sides, int>> paths = new List<KeyValuePair<Sides, int>>();
                paths.Add(new KeyValuePair<Sides, int>(Sides.East, east));
                paths.Add(new KeyValuePair<Sides, int>(Sides.West, west));
                paths.Add(new KeyValuePair<Sides, int>(Sides.North, north));
                paths.Add(new KeyValuePair<Sides, int>(Sides.South, south));

                paths.Sort(Compare1);

                List<KeyValuePair<Sides, int>> filteredPaths = findUnvisited(paths, new Point(current.X,current.Y));

                if (filteredPaths.Count == 0)
                {
                    if (stack.Count == 0)
                        break;
                    current = stack.Pop();
                }
                else
                {
                    var path = filteredPaths[0];
                    if (path.Key == Sides.East)
                    {
                        stack.Push(current);
                        current.East = maze[current.X + 1][current.Y];
                        maze[current.X + 1][current.Y].West = current;
                        current = maze[current.X + 1][current.Y];
                        current.Visited = 2;
                        totalNumber--;
                    }

                    if (path.Key == Sides.West)
                    {
                        stack.Push(current);
                        current.West = maze[current.X - 1][current.Y];
                        maze[current.X - 1][current.Y].East = current;
                        current = maze[current.X - 1][current.Y];
                        current.Visited = 2;
                        totalNumber--;
                    }

                    if (path.Key == Sides.North)
                    {
                        stack.Push(current);
                        current.North = maze[current.X][current.Y - 1];
                        maze[current.X][current.Y - 1].South = current;
                        current = maze[current.X][current.Y - 1];
                        current.Visited = 2;
                        totalNumber--;
                    }

                    if (path.Key == Sides.South)
                    {
                        stack.Push(current);
                        current.South = maze[current.X][current.Y + 1];
                        maze[current.X][current.Y + 1].North = current;
                        current = maze[current.X][current.Y + 1];
                        current.Visited = 2;
                        totalNumber--;
                    }
                }
            }
        }

        public override void Solve()
        {
            throw new NotImplementedException();
        }

        public void DrawMaze(MainForm mForm)
        {
            Pen myPen = new System.Drawing.Pen(Color.Red);

            Graphics fGraphics = mForm.CreateGraphics();
            fGraphics.Clear(Color.Gray);

            //fGraphics.DrawLine(myPen, 0, 0, 100, 100);
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

            myPen.Dispose();
            fGraphics.Dispose();
        }

        private List<KeyValuePair<Sides, int>> findUnvisited(List<KeyValuePair<Sides, int>> paths, Point position)
        {
            if (position.Y > 0 && maze[position.X][position.Y - 1].Visited == 0)
            {
               // maze[position.X][position.Y - 1].Visited = 1;
            }
            else
            {
                paths.Remove(paths.Where(o => o.Key == Sides.North).First());
            }

            if (position.Y < height - 1 && maze[position.X][position.Y + 1].Visited == 0)
            {
               // maze[position.X][position.Y + 1].Visited = 1;
            }
            else
            {
                paths.Remove(paths.Where(o => o.Key == Sides.South).First());
            }

            if (position.X > 0 && maze[position.X - 1][position.Y].Visited == 0)
            {
               // maze[position.X - 1][position.Y].Visited = 1;
            }
            else
            {
                paths.Remove(paths.Where(o => o.Key == Sides.West).First());
            }

            if (position.X < width - 1 && maze[position.X + 1][position.Y].Visited == 0)
            {
              //  maze[position.X + 1][position.Y].Visited = 1;
            }
            else
            {
                paths.Remove(paths.Where(o => o.Key == Sides.East).First());
            }

            return paths;
        }
    }
}
