using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Ball : GameObject {
        const int INITIAL_SPEED_X = 300;
        const int INITIAL_SPEED_Y = 200;
        PointF speed;
        public Ball() : base(Properties.Resources.spr_ball_0)
        {
            speed.X = INITIAL_SPEED_X;
            speed.Y = INITIAL_SPEED_Y;
        }

        public override void updateFrame(int msec)
        {
            base.updateFrame(msec);

            rect.X += speed.X * msec / 1000;
            rect.Y += speed.Y * msec / 1000;

            if (rect.X < 0) {
                rect.X = -rect.X;
                speed.X = Math.Abs(speed.X);
            } else if (rect.X >= GameForm.WIDTH - bounds.Width) {
                rect.X = GameForm.WIDTH - bounds.Width;
                speed.X = -Math.Abs(speed.X);
            }
            if (rect.Y < 0) {
                rect.Y = -rect.Y;
                speed.Y = Math.Abs(speed.Y);
            } else if (rect.Y >= GameForm.HEIGHT) {
                rect.Y = GameForm.HEIGHT;
                speed.Y = -Math.Abs(speed.Y);
            }
        }

        internal void bounceY()
        {
            speed.Y = -speed.Y;
        }

        public bool didBounce(GameObject o)
        {
            if (!this.collides(o)) {
                return false;
            }

            var mcb = collisionBounds;
            var ocb = o.collisionBounds;

            var box = ocb;
            box.Width = ocb.Width / 20;
            if (mcb.IntersectsWith(box)) {
                // 왼쪽 사각형에 맞음
                speed.X = -speed.X;
                return true;
            }

            box.X += 19 * box.Width;
            if (mcb.IntersectsWith(box)) {
                // 오른쪽 사각형에 맞음
                speed.X = -speed.X;
                return true;
            }

            speed.Y = -speed.Y;
            //float y = mcb.Y + mcb.Height / 2;
            //float oy = ocb.Y + ocb.Height / 2;

            ////int y_sign;
            //if (y > oy) {
            //    //y_sign = 1;
            //    speed.Y = -speed.Y
            //} else {
            //    //y_sign = -1;
            //}


            return true;
        }
    }
}
