using NLog.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace FinalProjectApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TeacherHome : Window
    {
        public TeacherHome()
        {
            InitializeComponent();
            Fill_Grid();
        }

        private void BToLogIn(object sender, RoutedEventArgs e)
        {
            Close();
            LogIn lg = new LogIn();
            lg.Show();
        }

        private void ToUpdatePage(object sender, RoutedEventArgs e)
        {
            UpdateAssignment u = new UpdateAssignment();
            u.Show();
        }

        private void ToAssign(object sender, RoutedEventArgs e)
        {
            AssignPage ap = new AssignPage();
            ap.Show();
        }

        private void ToDelete(object sender, RoutedEventArgs e)
        {
            DeletePage ap = new DeletePage();
            ap.Show();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            FinalProjectApp.FinalProjDataSet finalProjDataSet = ((FinalProjectApp.FinalProjDataSet)(this.FindResource("finalProjDataSet")));
            // Load data into the table Assignments. You can modify this code as needed.
            FinalProjectApp.FinalProjDataSetTableAdapters.AssignmentsTableAdapter finalProjDataSetAssignmentsTableAdapter = new FinalProjectApp.FinalProjDataSetTableAdapters.AssignmentsTableAdapter();
            finalProjDataSetAssignmentsTableAdapter.Fill(finalProjDataSet.Assignments);
            System.Windows.Data.CollectionViewSource assignmentsViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("assignmentsViewSource1")));
            assignmentsViewSource1.View.MoveCurrentToFirst();
        }
        private void Fill_Grid()
        {
            string dbsCon = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = FinalProjectDataSet; Integrated Security = True";
            SqlConnection sqlCon = new SqlConnection(dbsCon);

            try
            {

                string CmdString = "SELECT * FROM Assignments";

                SqlCommand cmd = new SqlCommand(CmdString, sqlCon);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Assignments");

                sda.Fill(dt);

                //Grid1.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
