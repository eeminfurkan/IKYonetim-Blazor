using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IKYonetim.Varliklar;

namespace IKYonetim.Servisler
{
    public class AuthServisi
    {
        private readonly KullaniciOturumu _kullaniciOturumu;

        // Bu servisin, kullanıcının oturum durumunu değiştirebilmesi için KullaniciOturumu'na ihtiyacı var.
        public AuthServisi(KullaniciOturumu kullaniciOturumu)
        {
            _kullaniciOturumu = kullaniciOturumu;
        }

        public bool GirisYap(string kullaniciAdi, string sifre)
        {
            // Gerçek projede bu kontrol veritabanından yapılır.
            // Biz şimdilik kullanıcı adı ve şifreyi kodun içinde sabitliyoruz.
            if (kullaniciAdi.ToLower() == "admin" && sifre == "12345")
            {
                var kullanici = new Kullanici { KullaniciAdi = kullaniciAdi };
                _kullaniciOturumu.GirisYap(kullanici); // Oturum durumunu "giriş yapıldı" olarak ayarla
                return true;
            }

            return false;
        }

        public void CikisYap()
        {
            _kullaniciOturumu.CikisYap(); // Oturum durumunu "çıkış yapıldı" olarak ayarla
        }
    }
}
