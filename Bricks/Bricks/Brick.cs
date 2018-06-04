using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Brick : GameObject {
        private Brush[] brushes = new Brush[] {
            Brushes.AliceBlue,
            Brushes.DarkSlateBlue,
            Brushes.YellowGreen,
            Brushes.Wheat,
            Brushes.Tomato,
            Brushes.SkyBlue
        };
        private int _type;
        //private Color color;
        public int type {
            get {
                return _type + 1;
            }
            set {
                if (value > 0 && value <= brushes.Length) {
                    _type = value - 1;
                }
            }
        }
        public Brick(int w = 0, int h = 0) : base(w, h)
        {
        }

        public override void draw(Graphics g)
        {
            //base.draw(g);
            g.FillRectangle(brushes[_type], rect);
        }
    }
}
