using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex_0405 {
    public partial class MainForm : Form {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            displayLabel.Text = "Clicked !!";
            displayLabel.BorderStyle = BorderStyle.Fixed3D;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            displayLabel.Text = "Activated!!";
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            displayLabel.Text = "Deactivated!!";
        }
    }
}
