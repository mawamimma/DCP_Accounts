namespace DCP_Accounts_Api.Models
{
    public class Expend
    {
        public int ExpenditurID { get; set; }     // client provides this
        public string ExpSubCode { get; set; }
        public DateTime ExpDate { get; set; }
        public string UID { get; set; }
        public DateTime? EntryDate { get; set; }  // controller sets if null
    }
}
