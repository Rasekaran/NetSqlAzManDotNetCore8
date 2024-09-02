using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanApplicationAttributesView
{
    public int ApplicationId { get; set; }

    public int StoreId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ApplicationAttributeId { get; set; }

    public string AttributeKey { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;
}
