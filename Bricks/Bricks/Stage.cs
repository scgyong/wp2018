using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Stage {
        const int BRICK_W = 30;
        const int BRICK_H = 30;
        const int BRICK_X_INT = 40;
        const int BRICK_Y_INT = 40;
        const int BRICK_X_COUNT = 16;
        const int BRICK_Y_COUNT = 6;
        const int BRICK_X_OFFSET = 30;
        const int BRICK_Y_OFFSET = 80;
        //const int WINDOW_WIDTH = GameForm.WIDTH;
        //const int WINDOW_HEIGHT = GameForm.HEIGHT;

        private List<Brick> bricks = new List<Brick>();
        private int stageNumber;

        public Stage(int stageNumber)
        {
            this.stageNumber = stageNumber;

            if (stageNumber == 1) {
                for (int y = 0; y < BRICK_Y_COUNT; y++) {
                    for (int x = 0; x < BRICK_X_COUNT; x++) {
                        Brick brick = new Brick(BRICK_W, BRICK_H);
                        brick.setPosition(
                            BRICK_X_OFFSET + x * BRICK_X_INT,
                            BRICK_Y_OFFSET + y * BRICK_Y_INT
                            );
                        bricks.Add(brick);
                    }
                }
            }
        }

        public void draw(Graphics g)
        {
            foreach (Brick brick in bricks) {
                brick.draw(g);
            }
        }

        internal void checkCollision(Ball ball)
        {
            foreach (Brick brick in bricks) {
                if (ball.didBounce(brick)) {
                    bricks.Remove(brick);
                    break;
                }
            }
        }
    }
}
