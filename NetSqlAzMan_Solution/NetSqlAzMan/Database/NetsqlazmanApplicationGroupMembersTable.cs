using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanApplicationGroupMembersTable
{
    public int ApplicationGroupMemberId { get; set; }

    public int ApplicationGroupId { get; set; }

    public byte[] ObjectSid { get; set; } = null!;

    public byte WhereDefined { get; set; }

    public bool IsMember { get; set; }

    public virtual NetsqlazmanApplicationGroupsTable ApplicationGroup { get; set; } = null!;
}
