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
        const int PADDLE_Y = 550;
        const int PADDLE_W = 100;

        Paddle paddle;
        Ball ball;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(WIDTH, HEIGHT);
            paddle = new Paddle();
            paddle.setPosition(0, PADDLE_Y);

            ball = new Ball();
            ball.setPosition(WIDTH / 2, HEIGHT / 2);

            previousTime = DateTime.Now;
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X - PADDLE_W / 2;
            if (x < 0) {
                x = 0;
            } else if (x >= WIDTH - PADDLE_W) {
                x = WIDTH - PADDLE_W;
            }
            debugLabel.Text = e.X + " - " + x;
            paddle.setX(x);
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            paddle.draw(e.Graphics);
            ball.draw(e.Graphics);
        }

        DateTime previousTime;

        private void timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var elapsed = now - previousTime;
            previousTime = now;
            var msec = (int)elapsed.TotalMilliseconds;
            ball.updateFrame(msec);

            Invalidate();
        }
    }
}
