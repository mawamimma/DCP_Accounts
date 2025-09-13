using System;
using System.Collections.Generic;

namespace DCP_Accounts_Api.Models;

public partial class TblExpendHead
{
    public string? ExpCode { get; set; }

    public string? ExpDetail { get; set; }

    public string? Uid { get; set; }

    public DateTime? EntryDate { get; set; }
}
