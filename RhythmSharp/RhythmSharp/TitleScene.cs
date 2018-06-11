using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
