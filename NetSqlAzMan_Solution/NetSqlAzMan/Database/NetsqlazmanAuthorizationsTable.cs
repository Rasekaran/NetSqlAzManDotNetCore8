using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanAuthorizationsTable
{
    public int AuthorizationId { get; set; }

    public int ItemId { get; set; }

    public byte[] OwnerSid { get; set; } = null!;

    public byte OwnerSidWhereDefined { get; set; }

    public byte[] ObjectSid { get; set; } = null!;

    public byte ObjectSidWhereDefined { get; set; }

    public byte AuthorizationType { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public virtual NetsqlazmanItemsTable Item { get; set; } = null!;

    public virtual ICollection<NetsqlazmanAuthorizationAttributesTable> NetsqlazmanAuthorizationAttributesTables { get; set; } = new List<NetsqlazmanAuthorizationAttributesTable>();
}
