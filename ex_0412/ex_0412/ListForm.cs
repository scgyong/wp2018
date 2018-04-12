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
    public partial class ListForm : Form {
        public ListForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string text = inputTextBox.Text;
            if (text == "") {
                return;
            }
            listBox.Items.Add(text);
            inputTextBox.Text = "";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index < 0) {
                return;
            }

            listBox.Items.RemoveAt(index);
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            bool enablesButton = inputTextBox.Text != "";
            addButton.Enabled = enablesButton;
        }

        private void listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            bool enablesButton = listBox.SelectedIndex >= 0;
            removeButton.Enabled = enablesButton;
        }
    }
}
