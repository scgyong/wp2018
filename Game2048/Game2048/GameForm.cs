using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048 {
    public partial class GameForm : Form {
        public GameForm()
        {
            InitializeComponent();
        }

        private int score = 0;
        private void increaseScore(int diff)
        {
            score += diff;
            scoreLabel.Text = score.ToString();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            increaseScore(-1);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            increaseScore(1);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            increaseScore(10);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            increaseScore(-10);

        }
    }
}
