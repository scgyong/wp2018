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
        double time;
        int score;
        Font scoreFont;
        Font judgeFont;
        Song.Judge recentJudge;
        double judgeDisapearTime;
        public override void init()
        {
            base.init();
            timerEnabled = true;
            time = 0;
            score = 0;
            song.init();
            scoreFont = new Font(
                SystemFonts.CaptionFont.FontFamily,
                40, 
                FontStyle.Bold | FontStyle.Italic);
            judgeFont = new Font(
                SystemFonts.DefaultFont.FontFamily,
                50,
                FontStyle.Bold);
            recentJudge = Song.Judge.NOTHING;
            judgeDisapearTime = 0;
        }
        public override void update(double seconds)
        {
            base.update(seconds);
            time += seconds;

            if (time > song.duration) {
                goBackToTitleScene();
            }

            bool missed = song.checkMissedNotes(time);
            if (missed) {
                setJudge(Song.Judge.MISSED);
            }

            if (judgeDisapearTime > 0 && time > judgeDisapearTime) {
                setJudge(Song.Judge.NOTHING);
            }
        }

        private void setJudge(Song.Judge judge)
        {
            recentJudge = judge;
            judgeDisapearTime = time + 1.0;
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
            g.DrawString("Score: " + score,
                scoreFont,
                Brushes.Wheat, 500, 200);
            if (recentJudge != Song.Judge.NOTHING) {
                g.DrawString(recentJudge.ToString(),
                    judgeFont,
                    Brushes.Black,
                    100, 200);
            }
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
            int line = 0;
            for (int i = 0; i < 6; i++) {
                if (key == keys[i]) {
                    presseds[i] = true;
                    line = i + 1;
                }
            }
            if (line > 0) {
                var judge = song.handleInput(line, time);
                switch (judge) {
                case Song.Judge.PERFECT:
                    addScore(200);
                    break;
                case Song.Judge.GOOD:
                    addScore(100);
                    break;
                case Song.Judge.BAD:
                    addScore(50);
                    break;
                case Song.Judge.NOTHING:
                    addScore(-1);
                    return;
                }
                setJudge(judge);
            }
        }

        private void addScore(int score)
        {
            this.score += score;
            if (this.score < 0) {
                this.score = 0;
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
