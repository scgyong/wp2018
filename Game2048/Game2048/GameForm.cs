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
        Label[,] board = new Label[4, 4];
        public GameForm()
        {
            InitializeComponent();
            board = new Label[4, 4] {
                { label13, label14, label15, label16 },
                { label9, label10, label11, label12 },
                { label5, label6, label7, label8 },
                { label1, label2, label3, label4 },
            };
        }

        int x = 0, y = 0;

        private int score = 0;
        private void increaseScore(int diff)
        {
            score += diff;
            scoreLabel.Text = score.ToString();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            if (x > 0) {
                x--;
                board[y, x].Text = score.ToString();
            }
            increaseScore(-1);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            if (x < 3) {
                x++;
                board[y, x].Text = score.ToString();
            }
            increaseScore(1);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (y > 0) {
                y--;
                board[y, x].Text = score.ToString();
            }
            increaseScore(10);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (y < 3) {
                y++;
                board[y, x].Text = score.ToString();
            }
            increaseScore(-10);

        }
    }
}
