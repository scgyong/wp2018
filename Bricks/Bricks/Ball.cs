﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Ball : GameObject {
        const int INITIAL_SPEED_X = 200;
        const int INITIAL_SPEED_Y = 100;
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
    }
}