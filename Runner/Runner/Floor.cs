using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner {
    class Floor {
        const int BOX_Y = 400;
        const int speed = 220;
        List<GameObject> objects = new List<GameObject>();
        public void update(int msec)
        {
            while (objects.Count > 0) {
                GameObject first = objects[0];
                var bounds = first.bounds;
                if (bounds.Right < 0) {
                    objects.RemoveAt(0);
                }
            }
            float x = 0;
            if (objects.Count > 0) {
                var bounds = objects[objects.Count - 1].bounds;
                x = bounds.Right;
            }

            if (x < 800) {
                GameObject box = new GameObject(Runner.Properties.Resources.game_box);
                box.setPosition(x, BOX_Y);
                objects.Add(box);
            }
            int dx = -speed * msec / 1000;
            foreach (var obj in objects) {
                obj.move(dx, 0);
            }
        }

        public void draw(Graphics g)
        {
            foreach (var obj in objects) {
                obj.draw(g);
            }
        }
    }
}
