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
        List<Song> songs = new List<Song>();
        int selectedSongIndex;
        Font titleFont;
        public override void init()
        {
            base.init();
            timerEnabled = false;
            loadSongs();
            selectedSongIndex = 0;
            titleFont = new Font(
                SystemFonts.DefaultFont.FontFamily,
                50,
                FontStyle.Bold);
        }

        private void loadSongs()
        {
            string[] files = Directory.GetFiles("songs", "*.txt");
            foreach (string file in files) {
                Song song = new Song(file);
                songs.Add(song);
            }
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, form.ClientRectangle);
            if (songs.Count == 0) {
                return;
            }
            Song song = songs[selectedSongIndex];
            g.DrawString(song.title, titleFont, Brushes.White, 100, 100);
        }
        public override void handleKeyDown(Keys key)
        {
            if (songs.Count == 0) {
                return;
            }

            if (key == Keys.Space) {
                Song song = songs[selectedSongIndex];
                var scene = new GameScene();
                scene.song = song;
                Scene.currentScene = scene;
            }

            if (key == Keys.Left) {
                selectedSongIndex--;
                if (selectedSongIndex < 0) {
                    selectedSongIndex = songs.Count - 1;
                }
                form.Invalidate();
            } else if (key == Keys.Right) {
                selectedSongIndex++;
                if (selectedSongIndex >= songs.Count) {
                    selectedSongIndex = 0;
                }
                form.Invalidate();
            }
        }
    }
}
