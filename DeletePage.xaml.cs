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
    public partial class DeletePage : Window
    {
        public DeletePage()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            TeacherHome th = new TeacherHome();
            th.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dbsCon = @"Data Source=LABSCIFIPC16\LOCALHOST;Initial Catalog=FinalProj;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(dbsCon);

            try
            {
                sqlCon.Open();
                string q = "DELETE from Assignments where id=@val"; 
                // ^!!! add class (or remove it from DB)
                SqlCommand cmd = new SqlCommand(q, sqlCon);
                cmd.Parameters.AddWithValue("@val", idBox.Text);

                //cmd.Prepare();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Assignment deleted.");
                TeacherHome th = new TeacherHome();
                th.Show();
                Close();
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
    }
}
