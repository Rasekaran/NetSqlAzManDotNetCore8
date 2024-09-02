using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanApplicationGroupsTable
{
    public int ApplicationGroupId { get; set; }

    public int ApplicationId { get; set; }

    public byte[] ObjectSid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? LdapQuery { get; set; }

    public byte GroupType { get; set; }

    public virtual NetsqlazmanApplicationsTable Application { get; set; } = null!;

    public virtual ICollection<NetsqlazmanApplicationGroupMembersTable> NetsqlazmanApplicationGroupMembersTables { get; set; } = new List<NetsqlazmanApplicationGroupMembersTable>();
}
