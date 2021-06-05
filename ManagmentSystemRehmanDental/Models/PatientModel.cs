using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentSystemRehmanDental.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public long Contact { get; set; }

        public List<TestModel> Tests { get; set; }

        public virtual List<XRayModel> XRays { get; set; }
    }
}
