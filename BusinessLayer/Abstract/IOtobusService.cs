using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOtobusService
    {
        void otobusEkle(Otobus otobus);
        void otobusSil(Otobus otobus);
        void otobusGuncelle(Otobus otobus);
        List<Otobus> otobusListele();
        Otobus otobusGetirById(int id);
    }
}
