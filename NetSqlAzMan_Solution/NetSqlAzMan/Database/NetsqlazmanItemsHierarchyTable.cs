using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanItemsHierarchyTable
{
    public int ItemId { get; set; }

    public int MemberOfItemId { get; set; }
}
