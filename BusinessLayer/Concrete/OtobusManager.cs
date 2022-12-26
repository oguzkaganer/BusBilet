using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OtobusManager : IOtobusService
    {
        IOtobusDal _otobusDal;

        public OtobusManager(IOtobusDal otobusDal)
        {
            _otobusDal = otobusDal;
        }

        public void otobusEkle(Otobus otobus)
        {

            _otobusDal.insert(otobus);
        }

        public Otobus otobusGetirById(int id)
        {
            return _otobusDal.get(x => x.otobusId == id);
        }

        public void otobusGuncelle(Otobus otobus)
        {
            _otobusDal.update(otobus);
        }

        public List<Otobus> otobusListele()
        {
            return _otobusDal.list();
        }

        public void otobusSil(Otobus otobus)
        {
            _otobusDal.delete(otobus);
        }
    }
}
