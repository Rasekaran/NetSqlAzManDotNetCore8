using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanStoreGroupMembersView
{
    public int StoreGroupMemberId { get; set; }

    public int StoreGroupId { get; set; }

    public string StoreGroup { get; set; } = null!;

    public string? Name { get; set; }

    public byte[] ObjectSid { get; set; } = null!;

    public string? WhereDefined { get; set; }

    public string? MemberType { get; set; }
}
