using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmSharp {
    class TitleScene: Scene {
        List<Song> songs;
        public override void init()
        {
            base.init();
            timerEnabled = false;
            loadSongs();
        }

        private void loadSongs()
        {
            string[] files = Directory.GetFiles("songs");
            System.Diagnostics.Debug.Print("" + files.Length);
            foreach (var e in files) {
                System.Diagnostics.Debug.Print(e);

            }
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, form.ClientRectangle);
        }
        public override void handleKeyDown(Keys key)
        {
            if (key == Keys.Space) {
                var scene = new GameScene();
                scene.song = new Song("songs/song_1.txt");
                Scene.currentScene = scene;
            }
        }
    }
}
