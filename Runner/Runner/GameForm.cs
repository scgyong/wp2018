using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Runner {
    public partial class GameForm : Form {
        public GameForm()
        {
            InitializeComponent();
        }

        Bitmap bgImage;
        Bitmap bg1, bg2, bg3;
        int bg1Offset = 0, bg2Offset = 0, bg3Offset = 0;
        int bg1Speed = 70;
        int bg2Speed = 150;
        int bg3Speed = 300;

        //Bitmap playerImage;
        //AnimObject player;
        Player playerObj;
        //GameObject box;
        //AnimObject crocodile;
        //AnimObject coin;

        Floor floor = new Floor();

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            playerObj.handleKeyDownEvent(e.KeyCode);
        }

        DateTime previousTime;

        private void timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var elapsed = now - previousTime;
            previousTime = now;
            var msec = (int)elapsed.TotalMilliseconds;

            bg1Offset -= bg1Speed * msec / 1000;
            if (bg1Offset < -800) {
                bg1Offset += 1400;
            }
            bg2Offset -= bg2Speed * msec / 1000;
            if (bg2Offset < -261) {
                bg2Offset += 261;
            }
            bg3Offset -= bg3Speed * msec / 1000;
            if (bg3Offset < -261) {
                bg3Offset += 261;
            }

            floor.update(msec);
            //player.updateFrame(msec);
            playerObj.updateFrame(msec);
            //coin.updateFrame(msec);
            //crocodile.updateFrame(msec);

            //player.index++;
            //playerFrameIndex = (playerFrameIndex + 1) % 40;
            //if (++playerFrameIndex >= 4) {
            //    playerFrameIndex = 0;
            //}
            Invalidate();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(800, 600);
            bgImage = Runner.Properties.Resources.game_background00;
            bg1 = Runner.Properties.Resources.game_background01;
            bg2 = Runner.Properties.Resources.game_background02;
            bg3 = Runner.Properties.Resources.game_background03;
            //player = new AnimObject(Runner.Properties.Resources.game_player, 4, 4.0f);
            //player.setPosition(30, 100);
            playerObj = new Player();

            //coin = new AnimObject(Runner.Properties.Resources.game_item_coin, 4, 8f);
            //coin.setPosition(500, 400);
            //crocodile = new AnimObject(Runner.Properties.Resources.game_crocodile, 2, 2.0f);
            //crocodile.setPosition(300, 200);

            previousTime = DateTime.Now;
        }

        //int playerFrameIndex = 0;
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, 800, 600);
            e.Graphics.DrawImage(bg1, bg1Offset, 0, 800, 600);

            for (int x = bg2Offset; x < 800; x += 261) {
                e.Graphics.DrawImage(bg2, x, 0, 261, 600);
            }

            //player.draw(e.Graphics);
            //box.draw(e.Graphics);
            //crocodile.draw(e.Graphics);
            floor.draw(e.Graphics);
            playerObj.draw(e.Graphics);
            //coin.draw(e.Graphics);

            for (int x = bg3Offset; x < 800; x += 261) {
                e.Graphics.DrawImage(bg3, x, 0, 261, 600);
            }
        }

    }
}
