using System;
using System.Collections.Generic;

namespace NetSqlAzMan.Database;

public partial class NetsqlazmanLogTable
{
    public int LogId { get; set; }

    public DateTime LogDateTime { get; set; }

    public string WindowsIdentity { get; set; } = null!;

    public string? SqlIdentity { get; set; }

    public string MachineName { get; set; } = null!;

    public Guid InstanceGuid { get; set; }

    public Guid? TransactionGuid { get; set; }

    public int OperationCounter { get; set; }

    public string ENSType { get; set; } = null!;

    public string ENSDescription { get; set; } = null!;

    public string LogType { get; set; } = null!;
}
