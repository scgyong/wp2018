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
        const int speed = 220;
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
                var bounds = objects[objects.Count - 1].bounds;
                x = bounds.Right;
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
                y = CROC_Y;
            } else {
                obj = new GameObject(Runner.Properties.Resources.game_box);
                y = BOX_Y;
            }
            obj.setPosition(x, y);
            objects.Add(obj);
        }

        public void draw(Graphics g)
        {
            foreach (var obj in objects) {
                obj.draw(g);
            }
        }
    }
}
