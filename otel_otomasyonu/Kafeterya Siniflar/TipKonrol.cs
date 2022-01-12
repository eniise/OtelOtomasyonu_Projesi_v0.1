using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otel_otomasyonu.Kafeterya_Siniflar
{
    public class TipKonrol
    {
       public Boolean urunFiyat_Konrol(string fiyat)
        {
            float number_charge = 0;
            if (float.TryParse(fiyat, out number_charge))
            {
                return true;
            }
            else return false;
        }
        public Boolean urunKod_Konrol(string urunKod)
        {
            if (urunKod.Length < 5)
                return true;
            else
                return false;
        }
        public Boolean urunTipDegeri_Konrol(object Tip)
        {
            int out_int = 0;
            if (int.TryParse(Tip.ToString(),out out_int))
                return true;
            else
                return false;
        }
    }
}
