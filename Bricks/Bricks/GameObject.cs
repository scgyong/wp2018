using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bricks {
    class GameObject {
        protected Bitmap bitmap;
        protected RectangleF rect;
        public GameObject(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Size size = bitmap.Size;
            rect = new RectangleF(0, 0, size.Width, size.Height);
        }
        public GameObject(float width, float height) {
            this.bitmap = null;
            rect = new RectangleF(0, 0, width, height);
        }
        public RectangleF bounds {
            get {
                return rect;
            }
        }
        public virtual RectangleF collisionBounds {
            get {
                return rect;
            }
        }
        public float sizeDiff = 0.0f;
        public void setPosition(float x, float y)
        {
            rect.X = x;
            rect.Y = y;
        }
        public int tag = 0;

        public virtual void draw(Graphics g)
        {
            g.DrawImage(bitmap, rect);
        }

        public void move(int dx, int dy)
        {
            rect.X += dx;
            rect.Y += dy;
        }

        public bool collides(GameObject other)
        {
            return this.collisionBounds.IntersectsWith(other.collisionBounds);
        }

        public virtual void handleKeyDownEvent(Keys keyCode) { }

        public virtual void updateFrame(int msec) { }
    }
}
