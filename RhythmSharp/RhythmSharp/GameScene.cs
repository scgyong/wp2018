using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmSharp {
    class GameScene: Scene {
        internal Song song;
        double time = 0;
        public override void init()
        {
            base.init();
            timerEnabled = true;
            time = 0;
        }
        public override void update(double seconds)
        {
            base.update(seconds);
            time += seconds;

            if (time > song.duration) {
                goBackToTitleScene();
            }
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, form.ClientRectangle);
            for (int i = 0; i < 6; i++) {
                int x = Coord.x(i + 1);
                if (presseds[i]) {
                    g.FillRectangle(Brushes.Orange,
                        (float)x, 0,
                        Coord.NOTE_WIDTH, Coord.WINDOW_HEIGHT);
                }
                g.FillRectangle(Brushes.Blue,
                    (float)(x + Coord.NOTE_WIDTH / 2 - Coord.VLINE_WIDTH / 2),
                    0,
                    Coord.VLINE_WIDTH, Coord.WINDOW_HEIGHT
                );
            }
            g.FillRectangle(Brushes.HotPink,
                0, Coord.y(0.0), Coord.WINDOW_WIDTH, Coord.NOTE_HEIGHT);
            song.draw(g, time);
        }
        private bool[] presseds = new bool [6];

        private static Keys[] keys = new Keys[] {
            Keys.S, Keys.D, Keys.F,
            Keys.J, Keys.K, Keys.L,
        };
        public override void handleKeyDown(Keys key)
        {
            if (key == Keys.Escape) {
                goBackToTitleScene();
            }
            for (int i = 0; i < 6; i++) {
                if (key == keys[i]) {
                    presseds[i] = true;
                }
            }
        }
        public override void handleKeyUp(Keys key)
        {
            base.handleKeyUp(key);
            for (int i = 0; i < 6; i++) {
                if (key == keys[i]) {
                    presseds[i] = false;
                }
            }
        }

        private static void goBackToTitleScene()
        {
            Scene.currentScene = new TitleScene();
        }
    }
}
