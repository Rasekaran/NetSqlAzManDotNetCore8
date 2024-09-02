using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanStoresTable
{
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<NetsqlazmanApplicationsTable> NetsqlazmanApplicationsTables { get; set; } = new List<NetsqlazmanApplicationsTable>();

    public virtual ICollection<NetsqlazmanStoreAttributesTable> NetsqlazmanStoreAttributesTables { get; set; } = new List<NetsqlazmanStoreAttributesTable>();

    public virtual ICollection<NetsqlazmanStoreGroupsTable> NetsqlazmanStoreGroupsTables { get; set; } = new List<NetsqlazmanStoreGroupsTable>();

    public virtual ICollection<NetsqlazmanStorePermissionsTable> NetsqlazmanStorePermissionsTables { get; set; } = new List<NetsqlazmanStorePermissionsTable>();
}
