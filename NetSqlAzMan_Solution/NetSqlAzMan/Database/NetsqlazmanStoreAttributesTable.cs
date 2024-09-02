using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanStoreAttributesTable
{
    public int StoreAttributeId { get; set; }

    public int StoreId { get; set; }

    public string AttributeKey { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual NetsqlazmanStoresTable Store { get; set; } = null!;
}
