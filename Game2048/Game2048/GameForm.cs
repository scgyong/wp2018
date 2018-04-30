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

            for (int y = 0; y < 4; y++) {
                for (int x = 0; x < 4; x++) {
                    set(x, y, 0);
                }
            }

            generateRandomNumber();
        }

        private bool isFull()
        {
            for (int y = 0; y < 4; y++) {
                for (int x = 0; x < 4; x++) {
                    if (get(x, y) == 0) {
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
                if (get(x, y) == 0) {
                    break;
                }
            }
            value = (random.Next(2) == 0) ? 2 : 4;
            set(x, y, value);
            //board[y, x].Text = value.ToString();
        }

        private int score = 0;
        private void increaseScore(int diff)
        {
            score += diff;
            scoreLabel.Text = score.ToString();
        }

        private int get(int x, int y)
        {
            int value;
            if (Int32.TryParse(board[y, x].Text, out value)) {
                return value;
            }
            return 0;
        }
        private void set(int x, int y, int value)
        {
            string str = value != 0 ? value.ToString() : "";
            board[y, x].Text = str;
        }
        private delegate void Translator(int x, int y, out int ox, out int oy);
        private bool move(Translator translator)
        {
            bool moved = false;
            for (int y = 0; y < 4; y++) {
                for (int x = 0; x < 4; x++) {
                    int ox, oy; translator(x, y, out ox, out oy);
                    int number = get(ox, oy);
                    if (number == 0) {
                        // 비어있으므로 채워온다.
                        for (int x2 = x + 1; x2 < 4; x2++) {
                            int ox2, oy2; translator(x2, y, out ox2, out oy2);
                            number = get(ox2, oy2);
                            if (number > 0) {
                                // 숫자를 찾으면 해당 숫자를 x, y 로 가져오고 찾은 곳은 0 으로 만든다.
                                set(ox, oy, number);
                                set(ox2, oy2, 0);
                                moved = true;
                                break;
                            }
                        }
                        if (number == 0) {
                            // 끝으로 갔는데도 숫자가 없으면 이 줄은 더 이상 하지 않아도 된다.
                            break;
                        }
                    }
                    for (int x2 = x + 1; x2 < 4; x2++) {
                        int ox2, oy2; translator(x2, y, out ox2, out oy2);
                        int n2 = get(ox2, oy2);
                        if (number == n2) {
                            // 같은 숫자가 발견되면 2배 값을 적고 발견된 곳은 0 으로 만든다.
                            int value = 2 * number;
                            set(ox, oy, value);
                            set(ox2, oy2, 0);
                            increaseScore(value);
                            moved = true;
                            break;
                        } else if (n2 > 0) {
                            // 다른 숫자가 발견되었으므로 더 이상 할 일이 없다.
                            break;
                        }
                    }
                }
            }
            return moved;
        }

        private void translateLeft(int x, int y, out int ox, out int oy)
        {
            ox = x; oy = y;
        }
        private void translateRight(int x, int y, out int ox, out int oy)
        {
            ox = 3 - x; oy = y;
        }
        private void translateUp(int x, int y, out int ox, out int oy)
        {
            ox = y; oy = x;
        }
        private void translateDown(int x, int y, out int ox, out int oy)
        {
            ox = 3 - y; oy = 3 - x;
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            bool moved = false;
            switch (e.KeyCode) {
            case Keys.Left:
                moved = move(translateLeft);
                break;
            case Keys.Right:
                moved = move(translateRight);
                break;
            case Keys.Up:
                moved = move(translateUp);
                break;
            case Keys.Down:
                moved = move(translateDown);
                break;
            default:
                return;
            }
            if (moved) {
                generateRandomNumber();
            }
        }

        private bool moveLeft()
        {
            bool moved = false;
            for (int y = 0; y < 4; y++) {
                for (int x = 0; x < 4; x++) {
                    int number = get(x, y);
                    if (number == 0) {
                        // 비어있으므로 채워온다.
                        for (int x2 = x + 1; x2 < 4; x2++) {
                            number = get(x2, y);
                            if (number > 0) {
                                // 숫자를 찾으면 해당 숫자를 x, y 로 가져오고 찾은 곳은 0 으로 만든다.
                                set(x, y, number);
                                set(x2, y, 0);
                                moved = true;
                                break;
                            }
                        }

                        if (number == 0) {
                            // 끝으로 갔는데도 숫자가 없으면 이 줄은 더 이상 하지 않아도 된다.
                            break;
                        }
                    }
                    for (int x2 = x + 1; x2 < 4; x2++) {
                        int n2 = get(x2, y);
                        if (number == n2) {
                            // 같은 숫자가 발견되면 2배 값을 적고 발견된 곳은 0 으로 만든다.
                            int value = 2 * number;
                            set(x, y, value);
                            set(x2, y, 0);
                            moved = true;
                            break;
                        } else if (n2 > 0) {
                            // 다른 숫자가 발견되었으므로 더 이상 할 일이 없다.
                            break;
                        }
                    }
                }
            }

            return moved;
        }
        private void moveRight()
        {
            for (int y = 0; y < 4; y++) {
                for (int x = 3; x >= 0; x--) {
                    if (get(x, y) > 0) {
                        continue;
                    }
                    for (int x2 = x - 1; x2 >= 0; x2--) {
                        if (get(x2, y) > 0) {
                            System.Diagnostics.Debug.WriteLine(y + ": " + x2 + "->" + x);

                            set(x, y, get(x2, y));
                            set(x2, y, 0);
                            break;
                        }
                    }
                }
            }
        }
        private void leftButton_Click(object sender, EventArgs e)
        {
            //moveLeft();
            if (move(translateLeft)) {
                generateRandomNumber();
            }
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            //moveRight();
            if (move(translateRight)) {
                generateRandomNumber();
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (move(translateUp)) {
                generateRandomNumber();
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (move(translateDown)) {
                generateRandomNumber();
            }
        }

    }
}
