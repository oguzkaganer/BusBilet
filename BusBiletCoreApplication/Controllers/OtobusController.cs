using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BusBiletCoreApplication.Controllers
{
    public class OtobusController : Controller
    {
        IOtobusService _otobusService;

        public OtobusController(IOtobusService otobusService)
        {
            _otobusService = otobusService;
        }

        public IActionResult Index()
        {
            var otobusler = _otobusService.otobusListele();
            return View(otobusler);
        }
    }
}
