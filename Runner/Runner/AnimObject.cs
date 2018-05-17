﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner {
    class AnimObject: GameObject {
        private int frameCount;
        private int frameIndex;
        private float framesPerSecond;
        private int millisecondsElapsed;
        private RectangleF srcRect;

        public int index {
            get { return frameIndex; }
            set {
                frameIndex = value % frameCount;
                srcRect.X = frameIndex * srcRect.Width;
            }
        }

        public AnimObject(Bitmap bitmap, int frameCount, float framesPerSecond)
            : base(bitmap)
        {
            this.frameCount = frameCount;
            this.rect.Width = this.rect.Width / frameCount;
            this.srcRect = rect;
            this.frameIndex = 0;
            this.framesPerSecond = framesPerSecond;
            this.millisecondsElapsed = 0;
        }

        public void updateFrame(int msec)
        {
            millisecondsElapsed += msec;
            var msecPerFrame = 1000 / framesPerSecond;
            index = (int)(millisecondsElapsed / msecPerFrame);
        }

        public override void draw(Graphics g)
        {
            g.DrawImage(bitmap, rect, srcRect, GraphicsUnit.Pixel);
        }
    }
}
