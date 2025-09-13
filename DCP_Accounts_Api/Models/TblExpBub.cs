using System;
using System.Collections.Generic;

namespace DCP_Accounts_Api.Models;

public partial class TblExpBub
{
    public string? ExpSubCode { get; set; }

    public string? ExpDetail { get; set; }

    public string? ExpCode { get; set; }

    public string? Uid { get; set; }

    public DateTime? EntryDate { get; set; }
}
