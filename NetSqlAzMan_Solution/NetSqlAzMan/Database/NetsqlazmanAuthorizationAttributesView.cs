using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanAuthorizationAttributesView
{
    public int AuthorizationId { get; set; }

    public int ItemId { get; set; }

    public string? Owner { get; set; }

    public string? Name { get; set; }

    public byte[] ObjectSid { get; set; } = null!;

    public string? SidWhereDefined { get; set; }

    public string? AuthorizationType { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public int AuthorizationAttributeId { get; set; }

    public string AttributeKey { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;
}
