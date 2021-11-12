using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public partial class EditFormRevard : Form
    {

        public Revard revard;
       
        public EditFormRevard()
        {
            InitializeComponent();
           
        }
        public EditFormRevard(Revard revard):this()
        {
            this.revard = revard;

            tbTitle.Text = revard.Title;
            tbDescription.Text = revard.Description;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var result = ValidateChildren();
            if (!result)
                return;

            this.DialogResult = DialogResult.OK;
            if (revard == null)            //&&&&&&&&???????????
            {
                revard = new Revard(tbTitle.Text, tbDescription.Text);
            }
            if (revard != null)
            {
                this.revard.Title = tbTitle.Text;
                this.revard.Description = tbDescription.Text;
            }
            Close();
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(tbTitle.Text)|| tbTitle.Text.Length > 50)
            {
                errorProvider1.SetError(tbTitle, "Wrong title");
                e.Cancel=true;
            }
            else
            {
                errorProvider1.SetError(tbTitle, null);
            }
        }

        private void tbDescription_Validating(object sender, CancelEventArgs e)
        {
            if ( tbDescription.Text.Length > 250)
            {
                errorProvider1.SetError(tbDescription, "Wrong description");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbDescription, null);
            }
        }
    }
}
