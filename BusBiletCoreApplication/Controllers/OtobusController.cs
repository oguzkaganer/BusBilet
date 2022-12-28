using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BusBiletCoreApplication.Controllers
{
    public class OtobusController : Controller
    {
        IOtobusService _otobusService;
        IFirmaService _firmaService;

        public OtobusController(IOtobusService otobusService, IFirmaService firmaService)
        {
            _otobusService = otobusService;
            _firmaService = firmaService;
        }

        public IActionResult Index()
        {
            var otobusler = _otobusService.otobusListele();
            return View(otobusler);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            var firmalar = _firmaService.firmaListele();
            List<SelectListItem> degerler = (from i in firmalar
											 select new SelectListItem
                                             {
                                                 Text = i.firmaAd,
                                                 Value = i.firmaId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

		[HttpPost]
		public IActionResult Ekle(Otobus otobs)
		{
			var firmalar = _firmaService.firmaListele();
			Firma frm = firmalar.Where(m => m.firmaId == otobs.firma.firmaId).FirstOrDefault();
			otobs.firmaId = frm.firmaId;
            _otobusService.otobusEkle(otobs);
            return RedirectToAction("Index");
		} 


        public IActionResult Sil(int id)
        {
            Otobus silinecekOtobus = _otobusService.otobusGetirById(id);
            _otobusService.otobusSil(silinecekOtobus);
            return RedirectToAction("Index");
        }

    }
}
