using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebNetCoreEntittyFramework.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required , MaxLength(150)]
        public string Title { get; set; }


        [ForeignKey("Student")] // - Navigation kung san nya kukunin yung primary key
        public int Student_Id { get; set; } // Foreign key na naka connect sa may Parent Tbale

        public virtual Student student { get; set; } //Navigation -  Property kumbaga Parent Table sa database
    }
}
