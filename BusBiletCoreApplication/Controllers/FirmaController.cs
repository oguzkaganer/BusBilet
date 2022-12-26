using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BusBiletCoreApplication.Controllers
{
    public class FirmaController : Controller
    {
        IFirmaService _firmaService;

        public FirmaController(IFirmaService firmaService)
        {
            _firmaService = firmaService;
        }

        //FirmaManager fm=new FirmaManager(new EfFirmaRepository());
        public IActionResult Index()
        {
            var firmalar = _firmaService.firmaListele();
            return View(firmalar);
        }
    }
}
