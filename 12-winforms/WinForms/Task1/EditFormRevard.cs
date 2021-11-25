using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
using Interfaces;

namespace Task1
{
    public partial class EditFormRevard : Form
    {
       
        public Reward revard;
        private IRewardBL rewardBL;


        public EditFormRevard()
        {
            InitializeComponent();
            
        }
        public EditFormRevard(Reward revard, IRewardBL rewardBL):this()
        {
            this.revard = revard;
            this.rewardBL = rewardBL;

            tbTitle.Text = revard.Title;
            tbDescription.Text = revard.Description;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var result = ValidateChildren();
            if (!result)
                return;

            this.DialogResult = DialogResult.OK;
            if (revard == null)            
            {
                revard = new Reward(tbTitle.Text, tbDescription.Text);
            }
            else
            {
                rewardBL.EditReward(revard, tbTitle.Text, tbDescription.Text);
                //this.revard.Title = tbTitle.Text;
                //this.revard.Description = tbDescription.Text;

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
