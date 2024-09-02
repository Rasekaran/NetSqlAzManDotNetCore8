using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class UsersDemo
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public byte[]? Password { get; set; }

    public string FullName { get; set; } = null!;

    public string? OtherFields { get; set; }
}
