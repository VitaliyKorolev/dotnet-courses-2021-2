using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public partial class DeleteForm : Form
    {
        
        public DeleteForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
