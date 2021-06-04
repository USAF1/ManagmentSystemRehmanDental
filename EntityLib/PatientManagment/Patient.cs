using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EntityLibrary.TestManagment;
using EntityLibrary.XRayManagment;

namespace EntityLibrary.PatientManagment
{
    public class Patient
    {
        public Patient()
        {
            Tests = new List<Test>();
            XRays = new List<Xray>();

        }

        public int Id { get; set; }
        [Required]
        [Column(TypeName="varchar(50)")]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Gender { get; set; }
        public long? Contact { get; set; }

        public virtual List<Test> Tests { get; set; }

        public virtual List<Xray> XRays { get; set; }
    }
}
