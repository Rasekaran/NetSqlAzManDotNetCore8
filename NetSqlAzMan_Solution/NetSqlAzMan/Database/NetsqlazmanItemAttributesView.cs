using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanItemAttributesView
{
    public int ItemId { get; set; }

    public int ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ItemType { get; set; }

    public int ItemAttributeId { get; set; }

    public string AttributeKey { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;
}
