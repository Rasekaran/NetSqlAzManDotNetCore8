using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanDatabaseUser
{
    public byte[]? DbuserSid { get; set; }

    public string DbuserName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? OtherFields { get; set; }
}
