﻿using System;
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
    public partial class UpdateAssignment : Window
    {
        public UpdateAssignment()
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
                string q = "Update Assignments SET _name=@val1, dueDate=@val2, subject=@val3) " +
                    "where id=@val"; 
                // ^!!! add class (or remove it from DB)
                SqlCommand cmd = new SqlCommand(q, sqlCon);
                cmd.Parameters.AddWithValue("@val", idBox.Text);
                cmd.Parameters.AddWithValue("@val1", name.Text);
                cmd.Parameters.AddWithValue("@val2", dueDater.SelectedDate);
                cmd.Parameters.AddWithValue("@val3", cboxSubj.SelectedItem);

                cmd.Prepare();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Assignment updated successfully.");

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

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            FinalProjectApp.FinalProjDataSet finalProjDataSet = ((FinalProjectApp.FinalProjDataSet)(this.FindResource("finalProjDataSet")));
            // Load data into the table Classes. You can modify this code as needed.
            FinalProjectApp.FinalProjDataSetTableAdapters.ClassesTableAdapter finalProjDataSetClassesTableAdapter = new FinalProjectApp.FinalProjDataSetTableAdapters.ClassesTableAdapter();
            finalProjDataSetClassesTableAdapter.Fill(finalProjDataSet.Classes);
            System.Windows.Data.CollectionViewSource classesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("classesViewSource")));
            classesViewSource.View.MoveCurrentToFirst();
        }
    }
}
