using EntityLibrary.PatientManagment;
using EntityLibrary.TestManagment;
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
    /// Interaction logic for DocTestsWindow.xaml
    /// </summary>
    public partial class DocTestsWindow : Window
    {

        public ObservableCollection<BoolStringClass> myItemList { get; set; }

        public List<Test> Tests = TestHandler.GetTests();

        public Patient patient = PatientHandler.GetPatient(GetUserInfo.Id);

        public DocTestsWindow()
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
            foreach (var Test in Tests)
            {
                myItemList.Add(new BoolStringClass { itemText = Test.Name, itemValue = Test.Id });
            }
            this.DataContext = this;
        }

        private void chkItem_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkSelecttedItem = (CheckBox)sender;
            Test find = Tests.Find(x => x.Name == chkSelecttedItem.Content.ToString());
            patient.Tests.Add(find);
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            PatientHandler.UpdatePatientTest(patient);
            Patient py = PatientHandler.GetPatient(patient.Id);
            MessageBox.Show($"{py.Name} is Updated");
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
