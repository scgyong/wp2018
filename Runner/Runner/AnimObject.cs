using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner {
    class AnimObject: GameObject {
        private int frameCount;
        private int frameIndex;
        private RectangleF srcRect;

        public int index {
            get { return frameIndex; }
            set {
                frameIndex = value % frameCount;
                srcRect.X = frameIndex * srcRect.Width;
            }
        }

        public AnimObject(Bitmap bitmap, int frameCount)
            : base(bitmap)
        {
            this.frameCount = frameCount;
            this.rect.Width = this.rect.Width / frameCount;
            this.srcRect = rect;
            this.frameIndex = 0;
        }

        public override void draw(Graphics g)
        {
            g.DrawImage(bitmap, rect, srcRect, GraphicsUnit.Pixel);
        }
    }
}
