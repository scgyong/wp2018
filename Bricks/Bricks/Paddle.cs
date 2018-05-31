using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Paddle : GameObject {
        public Paddle() : base(Properties.Resources.paddle)
        {
        }

        internal void setX(int x)
        {
            rect.X = x;
        }

        public bool didBounce(Ball ball)
        {
            if (!collides(ball)) {
                return false;
            }

            var speed = ball.getSpeed();

            var pb = collisionBounds;
            var bb = ball.collisionBounds;

            float bx = (bb.Left + bb.Right) / 2;
            float by = (bb.Top + bb.Bottom) / 2;

            float ox1 = pb.Left + pb.Height / 2;
            float ox2 = pb.Right - pb.Height / 2;

            if (ox1 < bx && bx < ox2) {
                ball.setSpeed(speed.X, -Math.Abs(speed.Y));
                System.Diagnostics.Debug.Print("Normal Bounce: " +
                    bb.X + " > " + (pb.X + pb.Height) + " / " +
                    bb.Right + " < " + (pb.Right - pb.Height)
                    );
                return true;
            }


            var midPaddleX = (pb.Left + pb.Right) / 2;
            float ox = bx < midPaddleX ? ox1 : ox2;
            float oy = (pb.Top + pb.Bottom) / 2;

            float dx = bx - ox;
            float dy = by - oy;

            //System.Diagnostics.Debug.Print("(sx,sy) = " + speed.X + "," + speed.Y);
            //System.Diagnostics.Debug.Print("(bx,by) = " + bx + "," + by);
            //System.Diagnostics.Debug.Print("(ox,oy) = " + ox + "," + oy);
            //System.Diagnostics.Debug.Print("(dx,dy) = " + dx + "," + dy);

            double dist = Math.Sqrt(speed.X * speed.X + speed.Y * speed.Y);
            double angle = Math.Atan2(dy, dx);
            const double maxAngle = 0.9 * Math.PI;
            if (angle < -maxAngle) {
                angle = -maxAngle;
            } else if (angle > maxAngle) {
                angle = maxAngle;
            }

            System.Diagnostics.Debug.Print("Angle: " + angle + " Dist: " + dist);

            float nx = (float)(dist * Math.Cos(angle));
            float ny = (float)(dist * Math.Sin(angle));
            //System.Diagnostics.Debug.Print("(nx,ny) = " + nx + "," + ny);

            ball.setSpeed(nx, ny);

            return true;
        }
    }
}
