using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuralAPI.Models
{
    public partial class Summary
    {
        public long SummaryId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }
        public long? PersonId { get; set; }
        public long? QuestionChoiseId { get; set; }
        public short? LeftValue { get; set; }
        public short? RightValue { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("Summary")]
        public virtual Person Person { get; set; }
        [ForeignKey("QuestionChoiseId")]
        [InverseProperty("Summary")]
        public virtual QuestionChoice QuestionChoise { get; set; }
    }
}