using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebNetCoreEntittyFramework.Entities
{
   public class Student
    {
        //Data Annotation

        [Key] //primary key
        public int Id { get; set; }


        [Required] // mandatory required
        [MaxLength(150)]
        public string  Name { get; set; }
        

        [Required, MaxLength(1000)] // required with 
        public string Address { get; set; }
        

        [Column(TypeName ="date")]
        public DateTime? Birthday { get; set; }

        public string TestColumnOnly { get; set; }

        // one to many relationship
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
