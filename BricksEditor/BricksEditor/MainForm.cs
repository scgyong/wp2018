using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            setSelectedBrick(null);
        }

        private Brick selectedBrick = null;

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
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (selectedBrick == null) {
                return; // early return
            }
            int x = textFieldIntValue(xField, 0);
            int y = textFieldIntValue(yField, 0);
            int w = textFieldIntValue(wField, 80);
            int h = textFieldIntValue(hField, 30);
            int t = textFieldIntValue(tField, 1);
            selectedBrick.setPosition(x, y);
            selectedBrick.type = t;

            Invalidate();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (selectedBrick == null) {
                return; // early return
            }

            stage.bricks.Remove(selectedBrick);
            setSelectedBrick(null);
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            stage.draw(e.Graphics);
            if (selectedBrick != null) {
                e.Graphics.FillRectangle(Brushes.Black, selectedBrick.bounds);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stage.bricks.Clear();
            Invalidate();
            setSelectedBrick(null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".txt";
            var ret = dlg.ShowDialog();
            if (ret != DialogResult.OK) {
                return;
            }
            StreamWriter writer = new StreamWriter(dlg.FileName);
            foreach (Brick b in stage.bricks) {
                string str = "";
                str += b.bounds.X + ",";
                str += b.bounds.Y + ",";
                str += b.bounds.Width + ",";
                str += b.bounds.Height + ",";
                str += b.type;
                writer.WriteLine(str);
            }
            writer.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            var ret = dlg.ShowDialog();
            if (ret != DialogResult.OK) {
                return;
            }
            stage = new Stage(dlg.FileName);
            Invalidate();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void setSelectedBrick(Brick b)
        {
            updateButton.Enabled = b != null;
            removeButton.Enabled = b != null;

            selectedBrick = b;
            if (b == null) {
                return;
            }
            updateBrickCoordinate();
        }

        private void updateBrickCoordinate()
        {
            var bounds = selectedBrick.bounds;
            xField.Text = bounds.X.ToString();
            yField.Text = bounds.Y.ToString();
            wField.Text = bounds.Width.ToString();
            hField.Text = bounds.Height.ToString();
            tField.Text = selectedBrick.type.ToString();
        }

        bool mouseDownOnBrick = false;
        PointF mouseOffset;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Brick b in stage.bricks) {
                if (b.bounds.Contains(e.Location)) {
                    setSelectedBrick(b);
                    mouseDownOnBrick = true;
                    mouseOffset = new PointF(
                        e.Location.X - b.bounds.Location.X,
                        e.Location.Y - b.bounds.Location.Y
                    );
                    Invalidate();
                    return;
                }
            }
            selectedBrick = null;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownOnBrick = false;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownOnBrick && selectedBrick != null) {
                selectedBrick.setPosition(
                    e.Location.X - mouseOffset.X,
                    e.Location.Y - mouseOffset.Y);
                Invalidate();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedBrick == null) {
                return;
            }
            switch (e.KeyCode) {
            case Keys.Up:
                selectedBrick.move(0, -1);
                break;
            case Keys.Down:
                selectedBrick.move(0, 1);
                break;
            case Keys.Left:
                selectedBrick.move(-1, 0);
                break;
            case Keys.Right:
                selectedBrick.move(1, 0);
                break;
            default:
                return;
            }
            updateBrickCoordinate();
        }
    }
}
