using EntityLibrary.PatientManagment;
using ManagmentSystemRehmanDental.Extras;
using ManagmentSystemRehmanDental.Helpers;
using ManagmentSystemRehmanDental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagmentSystemRehmanDental.Views
{
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
            AddItemsToTestList();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(Txt_Search.Text)) && Convert.ToInt32(Txt_Search.Text) > 0)
            {
                GetUserInfo.Id = Convert.ToInt32(Txt_Search.Text);

                PatientModel model = PatientHandler.GetPatient(Convert.ToInt32(Txt_Search.Text)).ToModel();
                if (model != null)
                {
                    Txt_Name.Text = model.Name;
                    Txt_Age.Text = Convert.ToString(model.Age);
                    Txt_Gender.Text = model.Gender;
                    if (model.Contact > 0)
                    {
                        Txt_Contact.Text = Convert.ToString(model.Contact);
                    }
                    AddItemsToTestList();
                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
            }
            else
            {
                MessageBox.Show("Please Enter a Patient Id");
            }
        }

        public void AddItemsToTestList()
        {
            List_Test.Items.Clear();

            Patient patient = new Patient();
            if (GetUserInfo.Id > 0)
            {
                patient = PatientHandler.GetPatient(GetUserInfo.Id);
            }
            if (patient != null)
            {
                if (patient.Tests.Count > 0)
                {
                    foreach (var test in patient.Tests)
                    {

                        List_Test.Items.Add(test.Name);
                    }

                }
                else
                {
                    List_Test.Items.Add("No Tests Assign");
                }
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
