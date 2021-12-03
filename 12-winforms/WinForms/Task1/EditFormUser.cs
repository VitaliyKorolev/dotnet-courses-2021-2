using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public partial class EditFormUser : Form
    {
        private IUserBL userBL;
        public User user;
        public EditFormUser(IUserBL userBL, IList<Reward> rewards)
        {
            InitializeComponent();

            this.userBL = userBL;

            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.DataSource = rewards;
            listBox1.DisplayMember = "Title";
            listBox1.ValueMember = "ID";

        }
        public EditFormUser(IUserBL userBL, IList<Reward> rewards, User user) :this(userBL, rewards)
        {
            this.user = user;
            tbName.Text = user.Name;
            tbLastName.Text = user.LastName;
            dateTimePicker1.Value = user.BirthDate;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var result = ValidateChildren();
            if (!result)
                return;

            this.DialogResult = DialogResult.OK;
            if (user == null)
            {
                user = new User(DateTime.Parse(dateTimePicker1.Text), tbName.Text, tbLastName.Text);
               
                var r =listBox1.SelectedItems;
                foreach(Reward el in r)
                {

                    if (!user.Rewards.Contains(el))
                        user.Rewards.Add(el);

                }
                
            }
            else 
            {
                var r = listBox1.SelectedItems;
                List<Reward> newRewards = new List<Reward>();
                foreach (Reward el in r)
                {
                    newRewards.Add(el);
                }
                userBL.EditUser(user, tbName.Text, tbLastName.Text, dateTimePicker1.Value, newRewards);

            }
            Close();
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(tbName.Text) || tbName.Text.Length > 50)
            {
                errorProvider1.SetError(tbName, "Wrong name");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbName, null);
            }
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(tbLastName.Text) || tbLastName.Text.Length > 50)
            {
                errorProvider1.SetError(tbLastName, "Wrong last name");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbLastName, null);
            }
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime BirthDate = DateTime.Parse(dateTimePicker1.Text);
            int age = today.Year - BirthDate.Year;
            if (today.Month < BirthDate.Month || (today.Month == BirthDate.Month && today.Day < BirthDate.Day)) age--;

            if (BirthDate > DateTime.Now.Date || age > 150)
            {
                errorProvider1.SetError(dateTimePicker1, "Wrong date of birth");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dateTimePicker1, null);
            }
        }
    }
}
