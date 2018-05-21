using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Runner {
    class Player : AnimObject {
        private const int INIT_X = 30;
        private const int INIT_Y = 250;
        private const int JUMP_POWER = 700;
        private const int GRAVITY = 1600;

        bool isJumping = false;
        float jumpSpeed = 0;

        public Player() :
            base(Runner.Properties.Resources.game_player,
                4, 4.0f)
        {
            setPosition(INIT_X, INIT_Y);
        }

        public override void updateFrame(int msec)
        {
            base.updateFrame(msec);
            rect.Y += jumpSpeed * msec / 1000;
            jumpSpeed += GRAVITY * msec / 1000;
            if (rect.Y >= INIT_Y) {
                rect.Y = INIT_Y;
                isJumping = false;
            }
        }

        public override void handleKeyDownEvent(Keys keyCode) {
            if (keyCode == Keys.Space) {
                if (!isJumping) {
                    startJumping();
                }
            }
        }

        private void startJumping()
        {
            isJumping = true;
            jumpSpeed = -JUMP_POWER;
        }
    }
}
