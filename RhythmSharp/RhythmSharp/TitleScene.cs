using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmSharp {
    class TitleScene: Scene {
        public override void init()
        {
            base.init();
            timerEnabled = false;
        }
        public override void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, form.ClientRectangle);
        }
        public override void handleKeyEvent(Keys key)
        {
            if (key == Keys.Space) {
                var scene = new GameScene();
                scene.song = new Song("songs/song_1.txt");
                Scene.currentScene = scene;
            }
        }
    }
}
