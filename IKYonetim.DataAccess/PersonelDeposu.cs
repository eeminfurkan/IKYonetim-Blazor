using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IKYonetim.VeriErisim projesi icindeki PersonelDeposu.cs dosyasi

using IKYonetim.Varliklar; // Personel sınıfını tanıyabilmek için bu satır gerekli!

namespace IKYonetim.VeriErisim
{
    /// <summary>
    /// Personel verileri için veri erişim operasyonlarını yöneten sınıf (Repository).
    /// </summary>
    public class PersonelDeposu
    {
        // Veritabanı yerine kullanacağımız, hafızada tutulan statik personel listesi.
        // "static" olması sayesinde bu liste, uygulama çalıştığı sürece tek bir tane olur ve verileri kaybetmeyiz.
        private static List<Personel> _personeller;

        // Bu sınıf ilk kez oluşturulduğunda çalışan metot (Constructor).
        public PersonelDeposu()
        {
            // Eğer liste daha önce hiç oluşturulmadıysa (null ise) veya boşsa, içine başlangıç verileri ekleyelim.
            if (_personeller == null || !_personeller.Any())
            {
                _personeller = new List<Personel>
                {
                    new Personel { Id = 1, Ad = "Ahmet", Soyad = "Yılmaz", Departman = "Yazılım", Pozisyon = "Kıdemli Geliştirici", IseGirisTarihi = new DateTime(2022, 5, 10) },
                    new Personel { Id = 2, Ad = "Ayşe", Soyad = "Kaya", Departman = "İnsan Kaynakları", Pozisyon = "İşe Alım Uzmanı", IseGirisTarihi = new DateTime(2023, 1, 15) },
                    new Personel { Id = 3, Ad = "Mehmet", Soyad = "Demir", Departman = "Yazılım", Pozisyon = "Junior Geliştirici", IseGirisTarihi = new DateTime(2024, 6, 1) }
                };
            }
        }

        /// <summary>
        /// Hafızadaki tüm personel listesini döndürür.
        /// </summary>
        /// <returns>Personellerin olduğu bir liste.</returns>
        public List<Personel> TumunuGetir()
        {
            return _personeller;
        }

        /// <summary>
        /// Listeye yeni bir personel ekler.
        /// </summary>
        /// <param name="yeniPersonel">Eklenecek personel nesnesi.</param>
        public void Ekle(Personel yeniPersonel)
        {
            // Veritabanı olmadığı için yeni Id'yi biz belirliyoruz.
            // Listedeki en büyük Id'yi bulup 1 fazlasını yeni Id olarak atıyoruz.
            var sonId = _personeller.Max(p => p.Id);
            yeniPersonel.Id = sonId + 1;

            _personeller.Add(yeniPersonel);
        }

        /// <summary>
        /// Verilen Id'ye sahip personeli listeden siler.
        /// </summary>
        /// <param name="id">Silinecek personelin Id'si.</param>
        public void Sil(int id)
        {
            // Id'ye göre silinecek personeli buluyoruz.
            var silinecekPersonel = _personeller.FirstOrDefault(p => p.Id == id);

            // Eğer bu Id'ye sahip bir personel bulunduysa...
            if (silinecekPersonel != null)
            {
                // Listeden kaldırıyoruz.
                _personeller.Remove(silinecekPersonel);
            }
        }

        /// <summary>
        /// Verilen Id'ye sahip personelin bilgilerini döndürür.
        /// </summary>
        /// <param name="id">Bilgileri istenen personelin Id'si.</param>
        /// <returns>Bulunan Personel nesnesi veya bulunamazsa null.</returns>
        public Personel IdYeGoreGetir(int id)
        {
            return _personeller.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Mevcut bir personelin bilgilerini günceller.
        /// </summary>
        /// <param name="guncellenecekPersonel">Güncel bilgileri içeren personel nesnesi.</param>
        public void Guncelle(Personel guncellenecekPersonel)
        {
            // Güncellenecek personeli listede buluyoruz.
            var mevcutPersonel = _personeller.FirstOrDefault(p => p.Id == guncellenecekPersonel.Id);

            // Eğer personel bulunduysa, bilgilerini yeni bilgilerle değiştiriyoruz.
            if (mevcutPersonel != null)
            {
                mevcutPersonel.Ad = guncellenecekPersonel.Ad;
                mevcutPersonel.Soyad = guncellenecekPersonel.Soyad;
                mevcutPersonel.Departman = guncellenecekPersonel.Departman;
                mevcutPersonel.Pozisyon = guncellenecekPersonel.Pozisyon;
                mevcutPersonel.IseGirisTarihi = guncellenecekPersonel.IseGirisTarihi;
            }
        }
    }
}