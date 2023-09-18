using System;
using System.Collections.Generic;

namespace netCoreTransportMgmt.Entity;

public partial class TypeDetail
{
    public int TypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TransportDetail> TransportDetails { get; set; } = new List<TransportDetail>();
}
