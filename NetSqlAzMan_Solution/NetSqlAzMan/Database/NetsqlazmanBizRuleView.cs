using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanBizRuleView
{
    public int ItemId { get; set; }

    public int ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte ItemType { get; set; }

    public string BizRuleSource { get; set; } = null!;

    public byte BizRuleLanguage { get; set; }

    public byte[] CompiledAssembly { get; set; } = null!;
}
