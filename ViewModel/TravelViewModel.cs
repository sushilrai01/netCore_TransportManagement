using System.ComponentModel.DataAnnotations;

namespace netCoreTransportMgmt.ViewModel
{
    public class TravelViewModel
    {
    }

    public class DropDownModel
    {
        public int ID { get; set; }
        public string? Text { get; set; }
    }


    public class RouteModel
    {
        public int RouteId { get; set; }
        public string? Origin { get; set; }
        public string Destination { get; set; }

        [Display(Name = "Travel Cost")]
        public int Cost { get; set; }

    }

    //public class DriverModel
    //{   
    //    [Display(Name ="Driver ID")]
    //    public int DriverId { get; set; }

    //    [Display(Name="Driver Name")]
    //    public string Name { get; set; }

    //    [Display (Name = "Contact No.")]
    //    public string ContactNo { get; set; }
    //    public int RouteId { get; set; }

    //    [Display(Name ="Available On")]
    //    public DateTime DateAvailable { get; set; }

    //}

    public class TypeModel
    {
        public int TypeId { get; set; }

        [Display(Name = "Vehicle Type")]
        public string Name { get; set; }
    }


    public class TransportRouteModel
    {
        public int TransportId { get; set; }

        [Display(Name = "Departure Date")]
        public Nullable<DateTime> Date { get; set; }

        [Display(Name = "Total Passenger")]
        public int Passengers { get; set; }

        public int TypeID { get; set; }
        public int DriverID { get; set; }
        public int RouteID { get; set; }
        [Display(Name = "Vehicle Type")]
        public string VehicleName { get; set; }


        [Display(Name = "Driver")]
        public string DriverName { get; set; }

        public string Origin { get; set; }
        public string? Destination { get; set; }

        [Display(Name = "Travel Cost")]
        public int Cost { get; set; }

        public List<DropDownModel> TypeList { get; set; }
        public List<DropDownModel> DriverList { get; set; }
        public List<DropDownModel> RouteList { get; set; }

    }

    public class DriverInfoModel
    {
        [Display(Name = "Driver ID")]
        public int DriverId { get; set; }

        [Display(Name = "Driver Name")]
        public string Name { get; set; }

        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        public int RouteId { get; set; }

        [Display(Name = "Available On")]
        public Nullable<DateTime> DateAvailable { get; set; }
        public List<DropDownModel> RouteDropList { get; set; }
    }

    public class TransportModel
    {
        public int TransportId { get; set; }

        [Display(Name = "Departure Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Total Passenger")]
        public int Passengers { get; set; }
        public int DriverID { get; set; }

        public int TypeID { get; set; }

        public int RouteID { get; set; }

    }

    public class TxModel
    {
        public TransportModel MODEL { get; set; }
        public List<DropDownModel> TypeList { get; set; }
        public List<DropDownModel> DriverList { get; set; }
        public List<DropDownModel> RouteList { get; set; }

    }
}