using EntityLibrary.UsersManagment;
using ManagmentSystemRehmanDental.Helpers;
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

namespace ManagmentSystemRehmanDental.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {


        public Login()
        {
            InitializeComponent();
        }

        private void txt_UserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_UserName.Text) && !string.IsNullOrWhiteSpace(Txt_Password.Password))
            {

                User entity = new User() { UserName = txt_UserName.Text, Password = Txt_Password.Password };
                UserModel user = UsersHandler.GetUser(entity).ToModel();


                if (user.Role != null)
                {
                    if (user.Role.Name == "Reciption")
                    {
                        ReciptionWindow window = new ReciptionWindow();
                        window.Show();
                        this.Close();
                    }else if (user.Role.Name == "Doctor")
                    {
                        DoctorWindow window = new DoctorWindow();
                        window.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Check You User Name And Password");
                }


                //else if (user.Role.Name == "Lab")
                //{
                //    LabWindow window = new LabWindow();
                //    window.Show();
                //    this.Close();
                //}
  

            }
           
            else if(string.IsNullOrWhiteSpace(txt_UserName.Text) || string.IsNullOrWhiteSpace(Txt_Password.Password))
            {
                MessageBox.Show("Please Fill All Fileds");
            }
        }
    }
}
