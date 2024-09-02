using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanStoreGroupsTable
{
    public int StoreGroupId { get; set; }

    public int StoreId { get; set; }

    public byte[] ObjectSid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? LdapQuery { get; set; }

    public byte GroupType { get; set; }

    public virtual ICollection<NetsqlazmanStoreGroupMembersTable> NetsqlazmanStoreGroupMembersTables { get; set; } = new List<NetsqlazmanStoreGroupMembersTable>();

    public virtual NetsqlazmanStoresTable Store { get; set; } = null!;
}
