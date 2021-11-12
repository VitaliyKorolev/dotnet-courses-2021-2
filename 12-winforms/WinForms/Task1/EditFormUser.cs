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
        
        public User user;
        public EditFormUser( BindingList<Revard> revards)
        {
            InitializeComponent();
            

            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.DataSource = revards;
            listBox1.DisplayMember = "Title";
            listBox1.ValueMember = "ID";

        }
        public EditFormUser( BindingList<Revard> revards, User user) :this( revards)
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
                foreach(Revard el in r)
                {
                    if(!user.Rev.Contains(el)) 
                        user.Rev.Add(el);

                }
            }
            if (user != null)
            {
                this.user.Name = tbName.Text;
                this.user.LastName = tbLastName.Text;
                this.user.BirthDate = dateTimePicker1.Value;
                var r = listBox1.SelectedItems;
                this.user.Rev.Clear();
                foreach (Revard el in r)
                {
                    user.Rev.Add(el);
                }
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
