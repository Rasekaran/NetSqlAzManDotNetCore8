using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanApplicationAttributesTable
{
    public int ApplicationAttributeId { get; set; }

    public int ApplicationId { get; set; }

    public string AttributeKey { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual NetsqlazmanApplicationsTable Application { get; set; } = null!;
}
