using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuralAPI.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionChoice = new HashSet<QuestionChoice>();
        }

        public long QuestionId { get; set; }
        [Column("Title.FI")]
        [StringLength(50)]
        public string Title_FI { get; set; }
        [Column("Title.EN")]
        [StringLength(50)]
        public string Title_EN { get; set; }

        [InverseProperty("Question")]
        public virtual ICollection<QuestionChoice> QuestionChoice { get; set; }
    }
}