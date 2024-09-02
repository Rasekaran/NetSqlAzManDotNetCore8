using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanStoreGroupMembersTable
{
    public int StoreGroupMemberId { get; set; }

    public int StoreGroupId { get; set; }

    public byte[] ObjectSid { get; set; } = null!;

    public byte WhereDefined { get; set; }

    public bool IsMember { get; set; }

    public virtual NetsqlazmanStoreGroupsTable StoreGroup { get; set; } = null!;
}
