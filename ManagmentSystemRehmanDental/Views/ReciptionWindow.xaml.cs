using EntityLibrary.PatientManagment;
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
using ManagmentSystemRehmanDental.Helpers;
using System.Text.RegularExpressions;

namespace ManagmentSystemRehmanDental.Views
{
    /// <summary>
    /// Interaction logic for ReciptionWindow.xaml
    /// </summary>
    public partial class ReciptionWindow : Window
    {
        public ReciptionWindow()
        {
            InitializeComponent();
        }

        private void Gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (Txt_Name.Text == "" || Txt_Age.Text == "" || Gender.Text == "Gender")
            {
                MessageBox.Show("Please Fill All The Fileds");
            }
            else
            {
                PatientModel model = new PatientModel();

                model.Name = Txt_Name.Text;
                if (Convert.ToInt32(Txt_Age.Text) >= 5 && Convert.ToInt32(Txt_Age.Text) <= 100)
                {
                    model.Age = Convert.ToInt32(Txt_Age.Text);
                }
                else
                {
                    MessageBox.Show("The Age Must be grater than 5 and less than 100");
                }
                model.Gender = Gender.Text;
                if ( !string.IsNullOrEmpty(Txt_Contact.Text) && Txt_Contact.Text != null)
                {
                    model.Contact = Convert.ToInt64(Txt_Contact.Text);
                }

                try
                {
                    PatientHandler.AddPatient(PatientHelper.ToEntity(model));
                    Txt_Name.Text = "";
                    Txt_Age.Text = "";
                    Gender.Text = "Gender";
                    Txt_Contact.Text = "";
                    MessageBox.Show("Patient Added");
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }

                try
                {
                    PatientModel patient = PatientHandler.GetRecentPatient().ToModel();
                    MessageBox.Show($"Id: {patient.Id}");
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login window = new Login();
            window.Show();
            this.Close();
        }
    }
}
