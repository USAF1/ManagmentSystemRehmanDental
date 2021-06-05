using ManagmentSystemRehmanDental.Models;
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
using System.Windows.Shapes;
using EntityLibrary.PatientManagment;

namespace ManagmentSystemRehmanDental.Views
{
    /// <summary>
    /// Interaction logic for LabWindow.xaml
    /// </summary>
    public partial class LabWindow : Window
    {
        public LabWindow()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            List_Test.Items.Clear();
            if (!(string.IsNullOrWhiteSpace(Txt_Search.Text)) && Txt_Search.Text != "")
            {
                Patient patient = PatientHandler.GetPatient(Convert.ToInt32(Txt_Search.Text));

                if (patient !=null && patient.Name != null)
                {
                    Txt_Name.Text = patient.Name;
                    Txt_Age.Text = Convert.ToString(patient.Age);
                    Txt_Gender.Text = patient.Gender;
                    Txt_Contact.Text = Convert.ToString(patient.Contact);

                    if (patient.Tests.Count > 0)
                    {
                        foreach (var test in patient.Tests)
                        {

                            List_Test.Items.Add(test.Name);
                        }
                    }
                    else
                    {
                        List_Test.Items.Add("No Record Found");
                    }
                }
                else
                {
                    MessageBox.Show("No Patient Found");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Patient Id");
            }
        }

        private void Btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login window = new Login();
            window.Show();
            this.Close();
        }
    }
}
