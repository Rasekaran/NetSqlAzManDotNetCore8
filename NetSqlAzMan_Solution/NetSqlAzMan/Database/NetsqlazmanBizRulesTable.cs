using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanBizRulesTable
{
    public int BizRuleId { get; set; }

    public string BizRuleSource { get; set; } = null!;

    public byte BizRuleLanguage { get; set; }

    public byte[] CompiledAssembly { get; set; } = null!;

    public virtual ICollection<NetsqlazmanItemsTable> NetsqlazmanItemsTables { get; set; } = new List<NetsqlazmanItemsTable>();
}
