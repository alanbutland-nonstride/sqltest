using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Data.Common;
using System.Data.SqlClient;

namespace SQL_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         }

        private void cmbAdviserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int choice = cmbAdviserList.SelectedIndex;
            Adviser adv = Globals.cmbAdviserList[choice];
            txtID.Text = adv.id.ToString();
            txtName.Text = adv.name;
            txtPID.Text = adv.pid.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBFunctions dbConn = new DBFunctions();
            int choice = cmbAdviserList.SelectedIndex;
            Adviser adv = Globals.cmbAdviserList[choice];
            adv.name = txtName.Text;
            int.TryParse(txtPID.Text, out adv.pid);
            dbConn.EditTestTableRecord(adv);
        }
    }
}
