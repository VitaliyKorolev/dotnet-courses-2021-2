using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Interfaces;

namespace Task1
{
    public partial class MainForm : Form
    {
        private IUserBL userBL;
        private IRewardBL rewardBL;

        public MainForm(IUserBL userBL, IRewardBL rewardBL )
        {
            InitializeComponent();

            this.userBL = userBL;
            this.rewardBL = rewardBL;

            RefreshGrid();

            dgvUsers.Columns[5].Visible = false;
            dgvRevards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevards.ReadOnly = true;
            dgvUsers.ReadOnly = true;
            this.MinimumSize = new Size(800, 400);
     
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                Reward item = (Reward)dgvRevards.SelectedRows[0].DataBoundItem;     
                EditFormRevard editFormRevard = new EditFormRevard( item);
                editFormRevard.ShowDialog();

                RefreshGrid();
            }
            else if(tabControl1.SelectedTab == tabPage1)
            {
                User item = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                EditFormUser editFormUser = new EditFormUser(userBL, rewardBL.GetAllRewards(), item);
                editFormUser.ShowDialog();

                RefreshGrid();
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
                    Reward r = (Reward)dgvRevards.SelectedRows[0].DataBoundItem;
                    rewardBL.DeleteReward(r);

                    RefreshGrid();
                }
            }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                DeleteForm deleteForm = new DeleteForm();
                deleteForm.ShowDialog();

                if (deleteForm.DialogResult == DialogResult.OK)
                {
                    User u = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                    userBL.DeleteUser(u);

                    RefreshGrid();
                }
            }
            


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                EditFormRevard editFormRevard = new EditFormRevard();
                editFormRevard.ShowDialog();
                if (editFormRevard.DialogResult == DialogResult.OK)
                {
                    rewardBL.AddReward(editFormRevard.revard);

                    RefreshGrid();
                }

            }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                EditFormUser editFormUser = new EditFormUser(userBL, rewardBL.GetAllRewards());
                editFormUser.ShowDialog();

                if (editFormUser.DialogResult == DialogResult.OK)
                {
                    userBL.AddUser(editFormUser.user);
                    RefreshGrid();
                }


            }

        }
        private void RefreshGrid()
        {
            dgvRevards.DataSource = rewardBL.GetAllRewards();
            dgvUsers.DataSource = userBL.GetAllUsers();
        }

        private void dgvUsers_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IList<User> sortedListInstance;
            string col = dgvUsers.Columns[e.ColumnIndex].DataPropertyName;
            IList<User> users = userBL.GetAllUsers();
            if (col == "ID")
            {
                sortedListInstance = new List<User>(users.OrderBy(x => x.ID).ToList());
                users = sortedListInstance;
            }
            if (col == "Name")
            {
                sortedListInstance = new List<User>(users.OrderBy(x => x.Name).ToList());
                users = sortedListInstance;
            }
            if (col == "LastName")
            {
                sortedListInstance = new List<User>(users.OrderBy(x => x.LastName).ToList());
                users = sortedListInstance;
            }
            if (col == "BirthDate")
            {
                sortedListInstance = new List<User>(users.OrderBy(x => x.BirthDate).ToList());
                users = sortedListInstance;
            }
            if (col == "Age")
            {
                sortedListInstance = new List<User>(users.OrderBy(x => x.Age).ToList());
                users = sortedListInstance;
            }
            if (col == "Revards")
            {
                sortedListInstance = new List<User>(users.OrderBy(x => x.RewardsAsString).ToList());
                users = sortedListInstance;
            }
            dgvUsers.DataSource = users;

        }

        private void dgvRevards_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IList<Reward> sortedListInstance;
            string col = dgvRevards.Columns[e.ColumnIndex].DataPropertyName;
            IList<Reward> rewards = rewardBL.GetAllRewards();
            if (col == "ID")
            {
                sortedListInstance = new List<Reward>(rewards.OrderBy(x => x.ID).ToList());
                rewards = sortedListInstance;
            }
            if (col == "Title")
            {
                sortedListInstance = new List<Reward>(rewards.OrderBy(x => x.Title).ToList());
                rewards = sortedListInstance;
            }
            if (col == "Description")
            {
                sortedListInstance = new List<Reward>(rewards.OrderBy(x => x.Description).ToList());
                rewards = sortedListInstance;
            }
            dgvRevards.DataSource = rewards;
        }


        private void dgvUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.SelectedRows.Count != 0)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
        }

        private void dgvRevards_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRevards.SelectedRows.Count != 0)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
        }

        private void dgvUsers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if ( dgvUsers.Rows.Count == 0)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void dgvRevards_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvRevards.Rows.Count == 0)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }
    }
}
