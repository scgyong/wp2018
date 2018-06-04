using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BricksEditor {
    public partial class MainForm : Form {
        Stage stage = new Stage(0);
        public MainForm()
        {
            InitializeComponent();
        }

        private int textFieldIntValue(TextBox tb, int def)
        {
            int value;
            if (int.TryParse(tb.Text, out value)) {
                return value;
            }
            return def;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            int x = textFieldIntValue(xField, 0);
            int y = textFieldIntValue(yField, 0);
            int w = textFieldIntValue(wField, 80);
            int h = textFieldIntValue(hField, 30);
            int t = textFieldIntValue(tField, 1);
            Brick b = new Brick(w, h);
            b.setPosition(x, y);
            b.type = t;
            stage.bricks.Add(b);

            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            stage.draw(e.Graphics);
        }
    }
}
