using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
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

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Firma firma)
        {
            _firmaService.firmaEkle(firma);
            return RedirectToAction("Index");
        }

		public IActionResult Sil(int id)
		{
			Firma silinecekFirma = _firmaService.firmaGetirById(id);
			_firmaService.firmaSil(silinecekFirma);
			return RedirectToAction("Index");
		}

		public IActionResult Aktif(int id)
        {
            Firma silinecekFirma = _firmaService.firmaGetirById(id);
            silinecekFirma.silindi = false;
            _firmaService.firmaGuncelle(silinecekFirma);
            return RedirectToAction("Index");
        }
		public IActionResult Pasif(int id)
		{
			Firma silinecekFirma = _firmaService.firmaGetirById(id);
			silinecekFirma.silindi = true;
			_firmaService.firmaGuncelle(silinecekFirma);
			return RedirectToAction("Index");
		}

        public IActionResult Goruntule(int id)
        {
            Firma frm = _firmaService.firmaGetirById(id);
            return View("Goruntule", frm);
        }

		public IActionResult Guncelle(Firma firma)
		{
			Firma frm = _firmaService.firmaGetirById(firma.firmaId);
            frm.firmaAd = firma.firmaAd;
            frm.iletisim = firma.iletisim;
            frm.logoUrl = firma.logoUrl;
            return RedirectToAction("Index");
		}


	}
}
