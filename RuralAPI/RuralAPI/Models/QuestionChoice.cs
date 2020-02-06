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
        public string LeftTitle_FI { get; set; }
        [StringLength(50)]
        public string RightTitle_FI { get; set; }
        public long? QuestionId { get; set; }
        [StringLength(50)]
        public string LeftTitle_EN { get; set; }
        [StringLength(50)]
        public string RightTitle_EN { get; set; }

        [ForeignKey("QuestionId")]
        [InverseProperty("QuestionChoice")]
        public virtual Question Question { get; set; }
        [InverseProperty("QuestionChoise")]
        public virtual ICollection<Summary> Summary { get; set; }
    }
}