using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bricks {
    public partial class GameForm : Form {
        const int WIDTH = 800;
        const int HEIGHT = 600;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(WIDTH, HEIGHT);
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            debugLabel.Text = e.X.ToString();
        }
    }
}
