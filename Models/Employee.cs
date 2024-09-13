﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PLACEMENT_2.Models
{
    public class Employee
    {
        [Key]
       public int Id { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "Varchar(20)")]
        public string ContactNumber { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string Address { get; set; }


    }
}