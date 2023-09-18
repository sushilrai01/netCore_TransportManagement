using Microsoft.AspNetCore.Mvc;
using netCoreTransportMgmt.Entity;
using netCoreTransportMgmt.ViewModel;

namespace netCoreTransportMgmt.Controllers
{
   
    public class TransportController : Controller
    {
        private readonly TransportManagementContext db;
        public TransportController(TransportManagementContext db)
        {
            this.db = db;       
        }

        //GET: Transport/Index
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        //GET: Transport/Create
        public IActionResult Create()
        {
            TransportRouteModel model = new TransportRouteModel();
            model.TypeList = db.TypeDetails.Select(x => new DropDownModel { ID = x.TypeId, Text = x.Name }).ToList();
            model.RouteList = db.RouteDetails.Select(x => new DropDownModel { ID = x.RouteId, Text = x.Origin + " To " + x.Destination }).ToList();
            model.DriverList = db.DriverDetails.Select(x => new DropDownModel { ID = x.DriverId, Text = x.Name }).ToList();
            return View(model); 
        }
    }
}
