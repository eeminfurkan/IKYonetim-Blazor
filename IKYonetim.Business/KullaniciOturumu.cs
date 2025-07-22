using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKYonetim.Varliklar;

namespace IKYonetim.Servisler
{
    // Bu servis, her bir kullanıcının oturum bilgilerini saklar.
    public class KullaniciOturumu
    {
        public Kullanici GecerliKullanici { get; private set; }

        // Oturum durumu değiştiğinde (login/logout) diğer bileşenlere haber vermek için bir event.
        public event Action OturumDurumuDegisti;

        public bool GirisYapildiMi => GecerliKullanici != null;

        public void GirisYap(Kullanici kullanici)
        {
            GecerliKullanici = kullanici;
            OturumDurumuDegisti?.Invoke(); // Event'i tetikle
        }

        public void CikisYap()
        {
            GecerliKullanici = null;
            OturumDurumuDegisti?.Invoke(); // Event'i tetikle
        }
    }
}