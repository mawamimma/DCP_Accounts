using System;
using System.Collections.Generic;

namespace DCP_Accounts.Model;

public partial class TblIncome
{
    public int? ExpenditurId { get; set; }

    public string? IncDetail { get; set; }

    public DateOnly? IncDate { get; set; }

    public string? Uid { get; set; }

    public DateTime? EntryDate { get; set; }
}
