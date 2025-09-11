using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCP_Accounts_Api.Models
{
    [Table("tblExpend")]
    public class Expend
    {
        [Key]
        public int ExpenditurID { get; set; }

        [StringLength(4)]
        public string? ExpSubCode { get; set; }

        public DateTime? ExpDate { get; set; }

        [StringLength(5)]
        public string? UID { get; set; }

        public DateTime? EntryDate { get; set; }
    }
}
