using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner {
    class GameObject {
        protected Bitmap bitmap;
        protected RectangleF rect;
        public GameObject(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Size size = bitmap.Size;
            rect = new RectangleF(0, 0, size.Width, size.Height);
        }
        public RectangleF bounds {
            get {
                return rect;
            }
        }
        public void setPosition(float x, float y)
        {
            rect.X = x;
            rect.Y = y;
        }

        public virtual void draw(Graphics g)
        {
            g.DrawImage(bitmap, rect);
        }

        public void move(int dx, int dy)
        {
            rect.X += dx;
            rect.Y += dy;
        }
    }
}
