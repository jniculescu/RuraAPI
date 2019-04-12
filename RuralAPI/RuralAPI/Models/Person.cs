using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuralAPI.Models
{
    public partial class Person
    {
        public Person()
        {
            Summary = new HashSet<Summary>();
        }

        public long PersonId { get; set; }
        [StringLength(50)]
        public string Sex { get; set; }
        public short? Age { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Summary> Summary { get; set; }
    }
}