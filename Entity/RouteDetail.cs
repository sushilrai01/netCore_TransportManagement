using System;
using System.Collections.Generic;

namespace netCoreTransportMgmt.Entity;

public partial class RouteDetail
{
    public int RouteId { get; set; }

    public string Origin { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public int Cost { get; set; }

    public virtual ICollection<DriverDetail> DriverDetails { get; set; } = new List<DriverDetail>();

    public virtual ICollection<TransportDetail> TransportDetails { get; set; } = new List<TransportDetail>();
}
