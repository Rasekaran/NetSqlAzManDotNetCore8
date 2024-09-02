using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanAuthorizationAttributesTable
{
    public int AuthorizationAttributeId { get; set; }

    public int AuthorizationId { get; set; }

    public string AttributeKey { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual NetsqlazmanAuthorizationsTable Authorization { get; set; } = null!;
}
