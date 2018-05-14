using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex_0503_pink_jump {
    public partial class MainForm : Form {
        public MainForm()
        {
            InitializeComponent();
        }

        private int _imageIndex;
        private int imageIndex {
            get {
                return _imageIndex;
            }
            set {
                _imageIndex = value;
                pictureBox.Image = jumpImages.Images[_imageIndex];
                updown.Value = _imageIndex;
                slider.Value = _imageIndex;
            }
        }

        private DateTime startedOn;
        private void upButton_Click(object sender, EventArgs e)
        {
            //imageIndex = (imageIndex + 1) % 8;
            animTimer.Enabled = true;
            startedOn = DateTime.Now;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            //imageIndex = (imageIndex - 1 + 8) % 8;
            animTimer.Enabled = false;
        }

        private void animTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startedOn;
            int frames = (int)(elapsed.TotalMilliseconds / 100);
            System.Diagnostics.Debug.Print("Time=" + elapsed + " frames=" + frames);
            imageIndex = frames % 8;
        }

        private void updown_ValueChanged(object sender, EventArgs e)
        {
            if (sender == this.ActiveControl) {
                animTimer.Enabled = false;
            }
            imageIndex = (int)updown.Value;
        }

        private void slider_ValueChanged(object sender, EventArgs e)
        {
            if (sender == this.ActiveControl) {
                animTimer.Enabled = false;
            }
            imageIndex = slider.Value;
        }
    }
}
