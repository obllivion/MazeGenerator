using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeGenerator.Generators;
using MazeGenerator.Solvers;
using System.Threading;

namespace MazeGenerator
{
    public partial class MainForm : Form
    {

        Generator usedAlgorithm = null;
        Type usedType = typeof(RecursiveBacktracker);
        Pen myPen = new System.Drawing.Pen(Color.Violet);
        Graphics fGraphics;
        Thread th;
        Random rnd;

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usedAlgorithm = returnObjectInstance((int)nupWidth.Value, (int)nupHeight.Value);
            usedAlgorithm.Generate();
            usedAlgorithm.DrawMaze(gbMaze);

        }

        private void recursiveBacktrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.recursiveBacktrackerToolStripMenuItem.Checked = true;
            this.ellerToolStripMenuItem.Checked = false;
            usedType = typeof(RecursiveBacktracker);
        }

        private void ellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ellerToolStripMenuItem.Checked = true;
            this.recursiveBacktrackerToolStripMenuItem.Checked = false;
            usedType = typeof(Eller);
        }

        private Generator returnObjectInstance(int w, int h)
        {
            if (usedType == typeof(RecursiveBacktracker))
                return new RecursiveBacktracker(w, h);
            else if (usedType == typeof(Eller))
                return new Eller(w, h);

            return null;
        }

        private void bSolve_Click(object sender, EventArgs e)
        {
            Solver solv = new RandomMouse(usedAlgorithm.maze, usedAlgorithm.startPosition, usedAlgorithm.finalDestination);
            fGraphics = gbMaze.CreateGraphics();
            Action a = () =>
            {
                solv.Solve(this);
            };

            
            th = new Thread(() =>
                {
                    a();
                });

            th.Start();
        }

        public void UpdateStatus(Point currentPoint, Point nextPoint)
        {
            int size = 20;
            fGraphics.DrawLine(myPen, currentPoint.X * size + size / 2, currentPoint.Y * size + size / 2, nextPoint.X * size + size / 2, nextPoint.Y * size + size / 2);
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            th.Abort();
        }

        public void ChangePen()
        {
            myPen.Color = Color.FromArgb(rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(0, 200));
        }
    }
}
