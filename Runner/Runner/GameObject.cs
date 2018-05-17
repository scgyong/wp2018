using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner {
    class GameObject {
        Bitmap bitmap;
        RectangleF rect;
        public GameObject(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Size size = bitmap.Size;
            rect = new RectangleF(0, 0, size.Width, size.Height);
        }
        public void setPosition(float x, float y)
        {
            rect.X = x;
            rect.Y = y;
        }

        internal void draw(Graphics g)
        {
            g.DrawImage(bitmap, rect);
        }
    }
}
