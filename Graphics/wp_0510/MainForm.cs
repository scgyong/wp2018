using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wp_0510 {
    public partial class MainForm : Form {
        public MainForm()
        {
            InitializeComponent();
            tickCount = 0;
        }

        int tickCount;
        private void timer_Tick(object sender, EventArgs e)
        {
            tickCount++;
            //drawContent(CreateGraphics());
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            drawContent(e.Graphics);
        }

        private void drawContent(Graphics g)
        {
            Font f = new Font("Helvetica", 20);
            string text = "Timer number #" + tickCount;
            g.DrawString(text, f, Brushes.BlueViolet, 10.0f, 20.0f);
            f.Dispose();
        }
    }
}
