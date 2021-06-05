using EntityLibrary.PatientManagment;
using EntityLibrary.XRayManagment;
using ManagmentSystemRehmanDental.Extras;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DocXRayWindow.xaml
    /// </summary>
    public partial class DocXRayWindow : Window
    {

        public ObservableCollection<BoolStringClass> myItemList { get; set; }

        public List<Xray> XRays = XrayHandler.GetXRays();

        public Patient patient = PatientHandler.GetPatient(GetUserInfo.Id);

        public DocXRayWindow()
        {
            InitializeComponent();
            GetMyItemList();
        }



        public class BoolStringClass
        {
            public string itemText { get; set; }
            public int itemValue { get; set; }
        }

        public void GetMyItemList()
        {
            myItemList = new ObservableCollection<BoolStringClass>();
            foreach (var Test in XRays)
            {
                myItemList.Add(new BoolStringClass { itemText = Test.Name, itemValue = Test.Id });
            }
            this.DataContext = this;
        }

        private void chkItem_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkSelecttedItem = (CheckBox)sender;
            Xray find = XRays.Find(x => x.Name == chkSelecttedItem.Content.ToString());
            patient.XRays.Add(find);
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            PatientHandler.UpdatePatientXRay(patient);
            Patient py = PatientHandler.GetPatient(patient.Id);
            MessageBox.Show($"{py.Name} is Updated");
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
