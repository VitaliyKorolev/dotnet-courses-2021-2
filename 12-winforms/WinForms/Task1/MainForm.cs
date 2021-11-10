using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class MainForm : Form
    {
        protected BindingList<User> _users = new BindingList<User>
        {
            new User( DateTime.Now.Date.AddYears(-10), "Andrey", "Gysev"),
            new User( DateTime.Now.Date.AddYears(-15), "Vanya", "Pavlov"),


        };

        protected BindingList<Revard> _revards = new BindingList<Revard>
        {
            new Revard("Darvin premy", "Biology"),
            new Revard("Nobel premy", "Physics")

        };
        public MainForm()
        {
            InitializeComponent();

            _revards.AllowEdit = true;
            _users.AllowEdit = true;

            dgvUsers.DataSource = _users;
            dgvRevards.DataSource = _revards;
         
            dgvUsers.Columns[5].Visible = false;
            dgvRevards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevards.ReadOnly = true;
            dgvUsers.ReadOnly = true;
            this.MinimumSize = new Size(800, 400);
 
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;       
        }

        private void dgvUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsers.ClearSelection();
            dgvUsers.Rows[e.RowIndex].Selected = true;

            btnDelete.Enabled = true;
            btnEdit.Enabled = true;

        }

        private void dgvReavards_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvRevards.ClearSelection();
            dgvRevards.Rows[e.RowIndex].Selected = true;

            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                Revard item = (Revard)dgvRevards.SelectedRows[0].DataBoundItem;     
                int indexOfRevard = _revards.IndexOf(item);

                EditFormRevard editFormRevard = new EditFormRevard(_revards[indexOfRevard], "Edit");
                editFormRevard.ShowDialog();
                _revards[indexOfRevard] = editFormRevard.revard;
 
                _revards.ResetBindings();
            }
            else if(tabControl1.SelectedTab == tabPage1)
            {
                User item = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                int indexOfUser = _users.IndexOf(item);
                EditFormUser editFormUser = new EditFormUser("Edit", _revards, _users[indexOfUser]);
                editFormUser.ShowDialog();
                _users[indexOfUser] = editFormUser.user;
                _revards.ResetBindings();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                DeleteForm deleteForm = new DeleteForm();
                deleteForm.ShowDialog();

                if (deleteForm.DialogResult == DialogResult.OK)
                {
                    Revard r = (Revard)dgvRevards.SelectedRows[0].DataBoundItem;          
                    dgvRevards.Rows.Remove(dgvRevards.SelectedRows[0]);

                    foreach (User u in _users)
                    {
                        u.Rev.Remove(r);
                    }

                    _users.ResetBindings();
                    _revards.ResetBindings();
                }
            }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                DeleteForm deleteForm = new DeleteForm();
                deleteForm.ShowDialog();

                if (deleteForm.DialogResult == DialogResult.OK)
                {
                    dgvUsers.Rows.Remove(dgvUsers.SelectedRows[0]);
                    _users.ResetBindings();
                }
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                EditFormRevard editFormRevard = new EditFormRevard("Add");
                editFormRevard.ShowDialog();
                if (editFormRevard.DialogResult == DialogResult.OK)
                {
                    _revards.Add(editFormRevard.revard);
                    _revards.ResetBindings();
                }

            }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                EditFormUser editFormUser = new EditFormUser("Add", _revards);
                editFormUser.ShowDialog();

                if (editFormUser.DialogResult == DialogResult.OK)
                {
                    _users.Add(editFormUser.user);
                    _users.ResetBindings();
                }


            }

        }

        private void dgvUsers_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BindingList<User> sortedListInstance;
            string col = dgvUsers.Columns[e.ColumnIndex].DataPropertyName;
            if (col == "ID")
            {
                 sortedListInstance = new BindingList<User>(_users.OrderBy(x => x.ID).ToList());
                _users = sortedListInstance;
            }
            if (col == "Name")
            {
                 sortedListInstance = new BindingList<User>(_users.OrderBy(x => x.Name).ToList());
                _users = sortedListInstance;
            }
            if (col == "LastName")
            {
                 sortedListInstance = new BindingList<User>(_users.OrderBy(x => x.LastName).ToList());
                _users = sortedListInstance;
            }
            if (col == "BirthDate")
            {
                 sortedListInstance = new BindingList<User>(_users.OrderBy(x => x.BirthDate).ToList());
                _users = sortedListInstance;
            }
            if (col == "Age")
            {
                 sortedListInstance = new BindingList<User>(_users.OrderBy(x => x.Age).ToList());
                _users = sortedListInstance;
            }
            if (col == "Revards")
            {
                sortedListInstance = new BindingList<User>(_users.OrderBy(x => x.Revards).ToList());
                _users = sortedListInstance;
            }
            dgvUsers.DataSource = _users;


        }

        private void dgvRevards_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BindingList<Revard> sortedListInstance;
            string col = dgvRevards.Columns[e.ColumnIndex].DataPropertyName;
            if (col == "ID")
            {
                sortedListInstance = new BindingList<Revard>(_revards.OrderBy(x => x.ID).ToList());
                _revards = sortedListInstance;
            }
            if (col == "Title")
            {
                sortedListInstance = new BindingList<Revard>(_revards.OrderBy(x => x.Title).ToList());
                _revards = sortedListInstance;
            }
            if (col == "Description")
            {
                sortedListInstance = new BindingList<Revard>(_revards.OrderBy(x => x.Descripton).ToList());
                _revards = sortedListInstance;
            }
            dgvRevards.DataSource = _revards;
        }
    }
}
