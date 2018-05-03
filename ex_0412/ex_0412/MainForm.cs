using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex_0412 {
    public partial class MainForm : Form {
        public MainForm()
        {
            InitializeComponent();
        }

        private void fruitRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            displayLabel.Text = "Selected: " + r.Text;
        }

        private void boldCheck_CheckedChanged(object sender, EventArgs e)
        {
            FontStyle style = boldCheck.Checked ? FontStyle.Bold : 0;
            style |= ulineCheck.Checked ? FontStyle.Underline : 0;
            Font font = new Font(displayLabel.Font, style);
            displayLabel.Font = font;
        }

        private void ulineCheck_CheckedChanged(object sender, EventArgs e)
        {
            FontStyle style = boldCheck.Checked ? FontStyle.Bold : 0;
            style |= ulineCheck.Checked ? FontStyle.Underline : 0;
            Font font = new Font(displayLabel.Font, style);
            displayLabel.Font = font;
        }
    }
}
