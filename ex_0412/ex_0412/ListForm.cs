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
            listBox.Items.Add(text);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index < 0) {
                return;
            }

            listBox.Items.RemoveAt(index);
        }
    }
}
