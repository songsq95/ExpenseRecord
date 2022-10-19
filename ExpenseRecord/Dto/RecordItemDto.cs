using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseRecord.Dto
{
    public class RecordItemDto
    {
        [Column("task_id")]
        public string? Id { get; set; }

        [Column("task_desc")]
        [MaxLength(50)]
        public string? Description { get; set; }

        [Column("task_type")]
        [MaxLength(25)]
        public string? Type { get; set; }

        [Column("task_amount")]
        public int? Amount { get; set; }

        [Column("create_date")]
        public DateOnly? Date { get; set; }


    }
}