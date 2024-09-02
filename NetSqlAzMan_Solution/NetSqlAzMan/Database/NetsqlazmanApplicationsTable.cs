using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanApplicationsTable
{
    public int ApplicationId { get; set; }

    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<NetsqlazmanApplicationAttributesTable> NetsqlazmanApplicationAttributesTables { get; set; } = new List<NetsqlazmanApplicationAttributesTable>();

    public virtual ICollection<NetsqlazmanApplicationGroupsTable> NetsqlazmanApplicationGroupsTables { get; set; } = new List<NetsqlazmanApplicationGroupsTable>();

    public virtual ICollection<NetsqlazmanApplicationPermissionsTable> NetsqlazmanApplicationPermissionsTables { get; set; } = new List<NetsqlazmanApplicationPermissionsTable>();

    public virtual ICollection<NetsqlazmanItemsTable> NetsqlazmanItemsTables { get; set; } = new List<NetsqlazmanItemsTable>();

    public virtual NetsqlazmanStoresTable Store { get; set; } = null!;
}
