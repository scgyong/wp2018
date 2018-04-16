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
        Random random = new Random();

        public GameForm()
        {
            InitializeComponent();
            board = new Label[4, 4] {
                { label13, label14, label15, label16 },
                { label9, label10, label11, label12 },
                { label5, label6, label7, label8 },
                { label1, label2, label3, label4 },
            };

            foreach (Label label in board) {
                label.Text = ".";
            }

            generateRandomNumber();
        }

        private void generateRandomNumber()
        {
            int x, y, value;
            while (true) {
                x = random.Next(4);
                y = random.Next(4);
                if (!Int32.TryParse(board[y, x].Text, out value)) {
                    break;
                }
            }
            value = (random.Next(2) == 0) ? 2 : 4;
            board[y, x].Text = value.ToString();
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
            generateRandomNumber();
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
