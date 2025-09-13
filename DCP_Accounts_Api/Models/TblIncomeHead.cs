using System;
using System.Collections.Generic;

namespace DCP_Accounts_Api.Models;

public partial class TblIncomeHead
{
    public string? IncCode { get; set; }

    public string? IncDetail { get; set; }

    public string? Uid { get; set; }

    public DateTime? EntryDate { get; set; }
}
