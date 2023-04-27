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
    /// Interaction logic for SignUpPerson.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void CreateAccount(object sender, RoutedEventArgs e)
        {
            string dbsCon = @"Data Source=LABSCIFIPC16\LOCALHOST;Initial Catalog=FinalProj;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(dbsCon);

            try
            {
                sqlCon.Open();
                while (email1.Text!=email2.Text)
                {
                    MessageBox.Show("Make sure your Email in both places matches.");
                }
                while (pass.Password != pass2.Password)
                {
                    MessageBox.Show("Make sure your Password in both places matches.");
                }

                string q = "Insert into Teachers values(@val1,@val2,@val3)";
                SqlCommand cmd = new SqlCommand(q, sqlCon);
                cmd.Parameters.AddWithValue("@val1", name.Text);
                cmd.Parameters.AddWithValue("@val2", email1.Text);
                cmd.Parameters.AddWithValue("@val3", pass.Password);        //string query = $"select [Username], [Password] from Teachers where [email]={email.Text} and [Password]={pass.Password}";
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("Welcome!");
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

        private void GoToLogIn(object sender, RoutedEventArgs e)
        {
            LogIn lg = new LogIn();
            lg.Show();
            Close();
            
        }
    }
}
