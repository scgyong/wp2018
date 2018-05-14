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

        Bitmap playerImage;

        private void timer_Tick(object sender, EventArgs e)
        {
            bg1Offset -= 8;
            if (bg1Offset < -800) {
                bg1Offset += 1400;
            }
            bg2Offset -= 14;
            if (bg2Offset < -261) {
                bg2Offset += 261;
            }
            bg3Offset -= 20;
            if (bg3Offset < -261) {
                bg3Offset += 261;
            }
            playerFrameIndex = (playerFrameIndex + 1) % 40;
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
            playerImage = Runner.Properties.Resources.game_player;
        }

        int playerFrameIndex = 0;
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, 800, 600);
            e.Graphics.DrawImage(bg1, bg1Offset, 0, 800, 600);

            for (int x = bg2Offset; x < 800; x += 261) {
                e.Graphics.DrawImage(bg2, x, 0, 261, 600);
            }
            for (int x = bg3Offset; x < 800; x += 261) {
                e.Graphics.DrawImage(bg3, x, 0, 261, 600);
            }

            Rectangle dest = new Rectangle(0, 0, 156, 222);
            e.Graphics.DrawImage(playerImage, dest,
                (playerFrameIndex / 10) * 156, 0, 156, 222,
                GraphicsUnit.Pixel);
        }

    }
}
