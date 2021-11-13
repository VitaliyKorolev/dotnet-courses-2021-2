using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var userDAO = new UserListDAO();
            var rewardDAO = new RewardListDAO();
            var userLogic = new UserManager(userDAO);
            var rewardLogic = new RewardManager(rewardDAO, userDAO);
            Application.Run(new MainForm(userLogic, rewardLogic));
        }
    }
}
