using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLibrary.UsersManagment
{
    public class Role
    {

        public int Id { get; set; }
        [Required]
        [Column(TypeName="varchar(50)")]
        public string Name { get; set; }
    }
}
