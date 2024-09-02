using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanApplicationsView
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string StoreDescription { get; set; } = null!;

    public int ApplicationId { get; set; }

    public string ApplicationName { get; set; } = null!;

    public string ApplicationDescription { get; set; } = null!;
}
