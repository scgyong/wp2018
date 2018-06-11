using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmSharp {
    class Scene {
        private static Scene _scene;
        public static GameForm form;
        public static Scene currentScene {
            get {
                return _scene;
            }
            set {
                if (_scene != null) {
                    _scene.close();
                }
                _scene = value;
                if (_scene != null) {
                    _scene.init();
                }
                form.Invalidate();
            }
        }

        public virtual void init() { }
        public virtual void close() { }
        public virtual void draw(Graphics g) { }
        public virtual void update(double seconds) { }
        public virtual void handleKeyDown(Keys key) { }
        public virtual void handleKeyUp(Keys key) { }

        public bool timerEnabled {
            get {
                return form.timerEnabled;
            }
            set {
                form.timerEnabled = value;
            }
        }
    }
}
