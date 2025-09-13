using System;
using System.Collections.Generic;

namespace DCP_Accounts.Model;

public partial class TblIncSub
{
    public string? IncSubCode { get; set; }

    public string? IncDetail { get; set; }

    public string? IncCode { get; set; }

    public string? Uid { get; set; }

    public DateTime? EntryDate { get; set; }
}
