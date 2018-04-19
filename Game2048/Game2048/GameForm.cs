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
                label.Text = "";
            }

            generateRandomNumber();
        }

        private bool isFull()
        {
            for (int y = 0; y < 4; y++) {
                for (int x = 0; x < 4; x++) {
                    int value;
                    if (!Int32.TryParse(board[y, x].Text, out value)) {
                        return false;
                    }
                }
            }
            return true;
        }
        private void generateRandomNumber()
        {
            if (isFull()) {
                return;
            }

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

        private void moveLeft()
        {
            for (int y = 0; y < 4; y++) {
                for (int x = 0; x < 4; x++) {
                    if (board[y, x].Text.Length > 0) {
                        continue;
                    }
                    for (int x2 = x + 1; x2 < 4; x2++) {
                        if (board[y, x2].Text.Length > 0) {
                            System.Diagnostics.Debug.WriteLine(y + ": " + x2 + "->" + x);
                            board[y, x].Text = board[y, x2].Text;
                            board[y, x2].Text = "";
                            break;
                        }
                    }
                }
            }
        }
        private void moveRight()
        {
            for (int y = 0; y < 4; y++) {
                for (int x = 3; x >= 0; x--) {
                    if (board[y, x].Text.Length > 0) {
                        continue;
                    }
                    for (int x2 = x - 1; x2 >= 0; x2--) {
                        if (board[y, x2].Text.Length > 0) {
                            System.Diagnostics.Debug.WriteLine(y + ": " + x2 + "->" + x);
                            board[y, x].Text = board[y, x2].Text;
                            board[y, x2].Text = "";
                            break;
                        }
                    }
                }
            }
        }
        private void leftButton_Click(object sender, EventArgs e)
        {
            moveLeft();
            generateRandomNumber();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            moveRight();
            generateRandomNumber();
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
