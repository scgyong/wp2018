using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Brick : GameObject {
        public Brick() : base(null)
        {
        }

        public override void draw(Graphics g)
        {
            //base.draw(g);
            g.FillRectangle(Brushes.DarkSlateBlue, rect);
        }
    }
}
