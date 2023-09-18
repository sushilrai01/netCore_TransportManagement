using System;
using System.Collections.Generic;

namespace netCoreTransportMgmt.Entity;

public partial class DriverDetail
{
    public int DriverId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactNo { get; set; }

    public DateTime DateAvailable { get; set; }

    public int? RouteId { get; set; }

    public virtual RouteDetail? Route { get; set; }

    public virtual ICollection<TransportDetail> TransportDetails { get; set; } = new List<TransportDetail>();
}
