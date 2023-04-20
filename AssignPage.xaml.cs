using System;
using System.Collections.Generic;
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
    public partial class AssignPage : Window
    {
        public AssignPage()
        {
            InitializeComponent();
        }
        
        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dbsCon = @"Data Source=LABSCIFIPC16\LOCALHOST;Initial Catalog=FinalProj;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(dbsCon);

            try
            {
                sqlCon.Open();
                string q = "Insert into Assignments " +
                    " Values(@val1,@val2,@val3, @val4)";
                SqlCommand cmd = new SqlCommand(q, sqlCon);
                cmd.Parameters.AddWithValue("@val2", name.Text);
                cmd.Parameters.AddWithValue("@val4", dueDater.SelectedDate);
                cmd.Parameters.AddWithValue("@val3", idComboBox.SelectedItem);
                cmd.Parameters.AddWithValue("@val1", cboxSubj.SelectedItem);

                cmd.Prepare();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Assignment created successfully.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FinalProjectApp.FinalProjDataSet1 finalProjDataSet1 = ((FinalProjectApp.FinalProjDataSet1)(this.FindResource("finalProjDataSet1")));
            // Load data into the table Classes. You can modify this code as needed.
            FinalProjectApp.FinalProjDataSet1TableAdapters.ClassesTableAdapter finalProjDataSet1ClassesTableAdapter = new FinalProjectApp.FinalProjDataSet1TableAdapters.ClassesTableAdapter();
            finalProjDataSet1ClassesTableAdapter.Fill(finalProjDataSet1.Classes);
            System.Windows.Data.CollectionViewSource classesViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("classesViewSource1")));
            classesViewSource1.View.MoveCurrentToFirst();
        }
    }
}
