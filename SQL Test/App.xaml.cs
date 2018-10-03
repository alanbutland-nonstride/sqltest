using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace SQL_Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Setup();
        }

        public static void Setup()
        {
            DBFunctions sqlConn = new DBFunctions();
            sqlConn.GetTestTable();

            var MainWindow = new MainWindow();
            MainWindow.Show();

            foreach (Adviser adv in Globals.adviserList)
            {
                MainWindow.cmbAdviserList.Items.Add(adv.name);
            }
        }
    }
}
