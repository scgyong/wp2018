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
    }
}
