using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanItemsHierarchyView
{
    public int ItemId { get; set; }

    public int ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? ItemType { get; set; }

    public int MemberItemId { get; set; }

    public int MemberApplicationId { get; set; }

    public string MemberName { get; set; } = null!;

    public string MemberDescription { get; set; } = null!;

    public string? MemberType { get; set; }
}
