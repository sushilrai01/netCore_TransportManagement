using System;
using System.Collections.Generic;

namespace netCoreTransportMgmt.Entity;

public partial class TransportDetail
{
    public int TransportId { get; set; }

    public int? TypeId { get; set; }

    public int? DriverId { get; set; }

    public int? RouteId { get; set; }

    public DateTime Date { get; set; }

    public int Passengers { get; set; }

    public virtual DriverDetail? Driver { get; set; }

    public virtual RouteDetail? Route { get; set; }

    public virtual TypeDetail? Type { get; set; }
}
