using System;
using System.Collections.Generic;

namespace DCP_Accounts_Api.Models;

public partial class TblUser
{
    public string? Uid { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? EmpId { get; set; }

    public string? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }
}
