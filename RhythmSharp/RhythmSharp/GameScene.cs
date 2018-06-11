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

        public override void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, form.ClientRectangle);
        }
        public override void handleKeyEvent(Keys key)
        {
            if (key == Keys.Escape) {
                Scene.currentScene = new TitleScene();
            }
        }
    }
}
