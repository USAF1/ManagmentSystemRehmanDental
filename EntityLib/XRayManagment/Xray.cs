using EntityLibrary.PatientManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLibrary.XRayManagment
{
    public class Xray
    {
        public Xray()
        {
            Patients = new List<Patient>();
        }

        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public int Price { get; set; }

        public List<Patient> Patients { get; } = new List<Patient>();

    }
}
