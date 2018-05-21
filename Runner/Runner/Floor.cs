using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner {
    class Floor {
        const int BOX_Y = 440;
        const int CROC_Y = 400;
        //const int COIN_DX = 
        const int COIN_Y = 400;
        const int speed = 220;
        public const int TAG_NOTHING = 0;
        public const int TAG_BOX = 1;
        public const int TAG_COIN = 2;
        public const int TAG_CROCODILE = 3;
        List<GameObject> objects = new List<GameObject>();
        public void update(int msec)
        {
            while (objects.Count > 0) {
                GameObject first = objects[0];
                var bounds = first.bounds;
                if (bounds.Right < 0) {
                    objects.RemoveAt(0);
                } else {
                    break;
                }
            }
            float x = 0;
            if (objects.Count > 0) {
                var obj = objects[objects.Count - 1];
                var bounds = obj.bounds;
                x = bounds.Right - obj.sizeDiff;
            }

            if (x < 800) {
                appendObject(x);
            }
            int dx = -speed * msec / 1000;
            foreach (var obj in objects) {
                obj.move(dx, 0);
                obj.updateFrame(msec);
            }
        }

        private void appendObject(float x)
        {
            GameObject obj;
            int y;
            if (new Random().Next(3) == 0) {
                obj = new AnimObject(Runner.Properties.Resources.game_crocodile, 2, 2.0f);
                obj.tag = TAG_CROCODILE;
                y = CROC_Y;
            } else {
                obj = new GameObject(Runner.Properties.Resources.game_box);
                obj.tag = TAG_BOX;
                obj.sizeDiff = 20;
                y = BOX_Y;
                GameObject coin = new AnimObject(Runner.Properties.Resources.game_item_coin, 4, 8f);
                coin.tag = TAG_COIN;
                float dx =
                    (obj.bounds.Width - obj.sizeDiff) / 2
                    - coin.bounds.Width / 2;
                coin.setPosition(x + dx, COIN_Y);
                objects.Add(coin);
            }
            obj.setPosition(x, y);
            objects.Add(obj);
        }

        public int checkCollision(Player player)
        {
            //GameObject removedCoin = null;
            foreach (GameObject obj in objects) {
                if (obj.tag == TAG_COIN) {
                    if (obj.collides(player)) {
                        //removedCoin = obj;
                        objects.Remove(obj);
                        return TAG_COIN;
                    }
                } else if (obj.tag == TAG_CROCODILE) {
                    if (obj.collides(player)) {
                        return TAG_CROCODILE;
                    }
                }
            }
            return TAG_NOTHING;
            //if (removedCoin != null) {
            //    //playSOUnd();
            //}
        }

        public void draw(Graphics g)
        {
            foreach (var obj in objects) {
                obj.draw(g);
            }
        }
    }
}
