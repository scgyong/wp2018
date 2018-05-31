using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Brick : GameObject {
        public Brick(int w = 0, int h = 0) : base(w, h)
        {
        }

        public override void draw(Graphics g)
        {
            //base.draw(g);
            g.FillRectangle(Brushes.DarkSlateBlue, rect);
        }
    }
}
