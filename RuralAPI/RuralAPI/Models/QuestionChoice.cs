using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuralAPI.Models
{
    public partial class QuestionChoice
    {
        public QuestionChoice()
        {
            Summary = new HashSet<Summary>();
        }

        [Key]
        public long QuestionChoiseId { get; set; }
        [StringLength(50)]
        public string LeftTitle { get; set; }
        [StringLength(50)]
        public string RightTitle { get; set; }
        public long? QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        [InverseProperty("QuestionChoice")]
        public virtual Question Question { get; set; }
        [InverseProperty("QuestionChoise")]
        public virtual ICollection<Summary> Summary { get; set; }
    }
}