using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanApplicationGroupMembersView
{
    public int StoreId { get; set; }

    public int ApplicationId { get; set; }

    public int ApplicationGroupMemberId { get; set; }

    public int ApplicationGroupId { get; set; }

    public string ApplicationGroup { get; set; } = null!;

    public string? Name { get; set; }

    public byte[] ObjectSid { get; set; } = null!;

    public string? WhereDefined { get; set; }

    public string? MemberType { get; set; }
}
