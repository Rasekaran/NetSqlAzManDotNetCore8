using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanItemAttributesTable
{
    public int ItemAttributeId { get; set; }

    public int ItemId { get; set; }

    public string AttributeKey { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual NetsqlazmanItemsTable Item { get; set; } = null!;
}
