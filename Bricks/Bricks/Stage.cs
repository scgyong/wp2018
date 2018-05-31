using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Stage {
        const int BRICK_W = 80;
        const int BRICK_H = 20;
        const int BRICK_X_INT = 90;
        const int BRICK_Y_INT = 30;
        const int BRICK_X_OFFSET = 20;
        const int BRICK_Y_OFFSET = 50;

        private List<Brick> bricks = new List<Brick>();
        private int stageNumber;

        public Stage(int stageNumber)
        {
            this.stageNumber = stageNumber;

            if (stageNumber == 1) {
                for (int y = 0; y < 5; y++) {
                    for (int x = 0; x < 8; x++) {
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
