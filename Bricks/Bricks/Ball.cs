using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Ball : GameObject {
        const int INITIAL_SPEED_X = 60;
        const int INITIAL_SPEED_Y = 40;
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
        }
    }
}
