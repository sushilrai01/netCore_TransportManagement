using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //public async Task<IActionResult> Index()
        //{
            
        //    return View();
        //}

        //GET: Transport/Create
        public IActionResult Create()
        {
            TransportRouteModel model = new TransportRouteModel();
            model.TypeList = db.TypeDetails.Select(x => new DropDownModel { ID = x.TypeId, Text = x.Name }).ToList();
            model.RouteList = db.RouteDetails.Select(x => new DropDownModel { ID = x.RouteId, Text = x.Origin + " To " + x.Destination }).ToList();
            model.DriverList = db.DriverDetails.Select(x => new DropDownModel { ID = x.DriverId, Text = x.Name }).ToList();
            return View(model); 
        }

        //POST: Transport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransportRouteModel model)
        {
            if(!ModelState.IsValid)
            {
                TransportRouteModel newmodel = new TransportRouteModel();
                newmodel.TypeList = db.TypeDetails.Select(x => new DropDownModel { ID = x.TypeId, Text = x.Name }).ToList();
                newmodel.RouteList = db.RouteDetails.Select(x => new DropDownModel { ID = x.RouteId, Text = x.Origin + " To " + x.Destination }).ToList();
                newmodel.DriverList = db.DriverDetails.Select(x => new DropDownModel { ID = x.DriverId, Text = x.Name }).ToList();
                return View(newmodel);
            }

            TransportDetail transport = new TransportDetail();
            transport.TransportId = model.TransportId;
            transport.TypeId = model.TypeID;
            transport.RouteId = model.RouteID;
            transport.DriverId = model.DriverID;
            transport.Date = (DateTime) model.Date;
            transport.Passengers = model.Passengers;

            db.TransportDetails.Add(transport);
            await db.SaveChangesAsync();    

            return RedirectToAction("Index", "Home");
        }
    }
}

//---------------Scaffolding entity framework core-----------
//Scaffold - DbContext "Server=DESKTOP-3EKTNG4;Database=StudentDb;user=sa;password=1234;
//TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Entity - force
