using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace EntityLibrary.UsersManagment
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Password { get; set; }
        [Required]
        public Role Role { get; set; }


    }
}
