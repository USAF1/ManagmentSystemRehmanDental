using EntityLibrary.PatientManagment;
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

namespace ManagmentSystemRehmanDental.Views
{
    /// <summary>
    /// Interaction logic for RadiologyWindow.xaml
    /// </summary>
    public partial class RadiologyWindow : Window
    {
        public RadiologyWindow()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            List_XRay.Items.Clear();
            if (!string.IsNullOrWhiteSpace(Txt_Search.Text) && Txt_Search.Text != "")
            {
                Patient patient = PatientHandler.GetPatient(Convert.ToInt32(Txt_Search.Text));

                if (patient != null && patient.Name != null)
                {
                    Txt_Name.Text = patient.Name;
                    Txt_Age.Text = Convert.ToString(patient.Age);
                    Txt_Gender.Text = patient.Gender;
                    Txt_Contact.Text = Convert.ToString(patient.Contact);

                    if (patient.XRays.Count > 0)
                    {
                        foreach (var xrya in patient.XRays)
                        {

                            List_XRay.Items.Add(xrya.Name);
                        }
                    }
                    else
                    {
                        List_XRay.Items.Add("No Record Found");
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
