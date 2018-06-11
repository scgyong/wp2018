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
        int time = 0;
        public override void init()
        {
            base.init();
            timerEnabled = true;
            time = 0;
        }
        public override void update(int msec)
        {
            base.update(msec);
            time += msec;

            if (time / 1000.0 > song.duration) {
                goBackToTitleScene();
            }
        }
        public override void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, form.ClientRectangle);
            song.draw(g, time);
        }
        public override void handleKeyEvent(Keys key)
        {
            if (key == Keys.Escape) {
                goBackToTitleScene();
            }
        }

        private static void goBackToTitleScene()
        {
            Scene.currentScene = new TitleScene();
        }
    }
}
