using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanStoreAttributesView
{
    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int StoreAttributeId { get; set; }

    public string AttributeKey { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;
}
