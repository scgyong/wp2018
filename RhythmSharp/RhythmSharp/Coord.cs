﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmSharp {
    class Coord {
        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;

        public const int NOTE_WIDTH = 60;
        public const int NOTE_HEIGHT = 20;
        public const int VLINE_WIDTH = 10;
        public const int CENTER_MARGIN = 50;
        public const int PRESS_Y = 500;
        public const int PIXELS_PER_SEC = 300;

        public static int x(int line)
        {
            int x = line * NOTE_WIDTH;
            if (line >= 4) {
                x += CENTER_MARGIN;
            }
            return x;
        }

        internal static int y(double seconds)
        {
            int y = (int)(PRESS_Y - PIXELS_PER_SEC * seconds);
            return y - NOTE_HEIGHT / 2;
        }
    }
}
