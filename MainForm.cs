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

namespace MazeGenerator
{
    public partial class MainForm : Form
    {

        Generator usedAlgorithm = null;
        Type usedType = typeof(RecursiveBacktracker);

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generator gen = returnObjectInstance((int)nupWidth.Value,(int)nupHeight.Value);
            gen.Generate();
            gen.DrawMaze(gbMaze);

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
    }
}
