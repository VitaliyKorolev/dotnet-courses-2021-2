using DAL;
using DAL.DB;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entities;
using System.Configuration;

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

            //var r = new SqlConnectionStringBuilder();
            //r.DataSource = "USER-ой\\SQLEXPRESS";
            //r.InitialCatalog = "MyDatabase";
            //r.IntegratedSecurity = true;
            //var c = r.ToString();

            
            bool mode = Boolean.Parse(ConfigurationManager.AppSettings["usingDatabase"]);
            if (mode)
            {
                var rewardDAODB = new RewardDBDAO();
                var userDAODB = new UserDBDAO();
                var userLogic = new UserManager(userDAODB);
                var rewardLogic = new RewardManager(rewardDAODB);

                Application.Run(new MainForm(userLogic, rewardLogic));
            }
            else
            {
                var userDAOList = new UserListDAO();
                var rewardDAOList = new RewardListDAO(userDAOList);
                var userLogic = new UserManager(userDAOList);
                var rewardLogic = new RewardManager(rewardDAOList);

                Application.Run(new MainForm(userLogic, rewardLogic));
            }
        }
    }
}
