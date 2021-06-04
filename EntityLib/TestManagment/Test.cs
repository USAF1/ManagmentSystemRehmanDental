using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EntityLibrary.PatientManagment;

namespace EntityLibrary.TestManagment
{
    public class Test
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName="varchar(50)")]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public List<Patient> Patients { get; } = new List<Patient>();
    }
}
