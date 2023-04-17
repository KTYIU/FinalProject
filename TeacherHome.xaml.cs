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

namespace FinalProjectApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdminTeacherHome : Window
    {
        public AdminTeacherHome()
        {
            InitializeComponent();
        }

        private void BToLogIn(object sender, RoutedEventArgs e)
        {
            Close();
            LogIn lg = new LogIn();
            lg.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            FinalProjectApp.FinalProjectDataSet finalProjectDataSet = ((FinalProjectApp.FinalProjectDataSet)(this.FindResource("finalProjectDataSet")));
            // Load data into the table Assignments. You can modify this code as needed.
            FinalProjectApp.FinalProjectDataSetTableAdapters.AssignmentsTableAdapter finalProjectDataSetAssignmentsTableAdapter = new FinalProjectApp.FinalProjectDataSetTableAdapters.AssignmentsTableAdapter();
            finalProjectDataSetAssignmentsTableAdapter.Fill(finalProjectDataSet.Assignments);
            System.Windows.Data.CollectionViewSource assignmentsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("assignmentsViewSource")));
            assignmentsViewSource.View.MoveCurrentToFirst();
        }
    }
}
