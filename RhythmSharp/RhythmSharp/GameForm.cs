using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmSharp {
    public partial class GameForm : Form {
        public GameForm()
        {
            InitializeComponent();
            ClientSize = new Size(
                Coord.WINDOW_WIDTH,
                Coord.WINDOW_HEIGHT);

            Scene.form = this;
            Scene.currentScene = new TitleScene();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Scene.currentScene.handleKeyDown(e.KeyCode);
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            Scene.currentScene.handleKeyUp(e.KeyCode);
        }
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            Scene.currentScene.draw(e.Graphics);
        }

        public bool timerEnabled {
            get {
                return timer.Enabled;
            }
            set {
                timer.Enabled = value;
                prevTime = DateTime.Now;
            }
        }

        DateTime prevTime;
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            var elapsed = now - prevTime;
            var seconds = elapsed.TotalSeconds;
            prevTime = now;
            Scene.currentScene.update(seconds);

            Invalidate();
        }

    }
}
