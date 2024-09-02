using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanStorePermissionsTable
{
    public int StorePermissionId { get; set; }

    public int StoreId { get; set; }

    public string SqlUserOrRole { get; set; } = null!;

    public bool IsSqlRole { get; set; }

    public byte NetSqlAzManFixedServerRole { get; set; }

    public virtual NetsqlazmanStoresTable Store { get; set; } = null!;
}
