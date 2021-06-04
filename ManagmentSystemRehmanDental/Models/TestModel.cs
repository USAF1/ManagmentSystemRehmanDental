using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentSystemRehmanDental.Models
{
    public class TestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public List<PatientModel> Patients { get; set; }

    }
}
