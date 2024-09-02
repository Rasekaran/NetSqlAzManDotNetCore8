using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanItemsTable
{
    public int ItemId { get; set; }

    public int ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte ItemType { get; set; }

    public int? BizRuleId { get; set; }

    public virtual NetsqlazmanApplicationsTable Application { get; set; } = null!;

    public virtual NetsqlazmanBizRulesTable? BizRule { get; set; }

    public virtual ICollection<NetsqlazmanAuthorizationsTable> NetsqlazmanAuthorizationsTables { get; set; } = new List<NetsqlazmanAuthorizationsTable>();

    public virtual ICollection<NetsqlazmanItemAttributesTable> NetsqlazmanItemAttributesTables { get; set; } = new List<NetsqlazmanItemAttributesTable>();
}
