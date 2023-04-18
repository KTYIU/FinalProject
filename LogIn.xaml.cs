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
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {

            string dbsCon = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=FinalProjectDataSet; Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(dbsCon);

            try
            {                
                sqlCon.Open();
                string q = "SELECT * FROM Teachers WHERE email=@val1 AND password=PASSWORD(@val2)";
                SqlCommand cmd = new SqlCommand(q, sqlCon);
                cmd.Parameters.AddWithValue("@val1", email.Text);
                cmd.Parameters.AddWithValue("@val2", pass.Password);

                //string query = $"select [Username], [Password] from Teachers where [email]={email.Text} and [Password]={pass.Password}";
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                TeacherHome th = new TeacherHome();
                th.Show();
                Close();
            }

        }


        private void GoToSignUp(object sender, RoutedEventArgs e)
        {
            Close();
            SignUp su = new SignUp();
            su.Show();
        }
    }
}
