using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IKYonetim.Servisler projesi icindeki PersonelServisi.cs dosyasi

using IKYonetim.Varliklar;
using IKYonetim.VeriErisim; // PersonelDeposu'nu kullanabilmek için bu satır önemli!
namespace IKYonetim.Servisler
{
    /// <summary>
    /// Personel ile ilgili iş mantığını ve operasyonları yürüten servis sınıfı.
    /// </summary>
    public class PersonelServisi
    {
        // Veri erişim katmanımızdaki PersonelDeposu'nu kullanacağız.
        private readonly PersonelDeposu _personelDeposu;

        // Constructor metodu: PersonelServisi oluşturulduğunda bir PersonelDeposu'na ihtiyaç duyar.
        public PersonelServisi()
        {
            // Şimdilik PersonelDeposu'nu kendimiz oluşturuyoruz.
            // İleride Dependency Injection ile bu işlemi Blazor'a devredeceğiz.
            _personelDeposu = new PersonelDeposu();
        }

        /// <summary>
        /// Tüm personellerin listesini getirir.
        /// </summary>
        /// <returns>Personel listesi.</returns>
        public List<Personel> TumPersonelleriGetir()
        {
            // İş mantığı burada yer alabilir. Örneğin, sadece aktif personelleri getir gibi.
            // Şimdilik doğrudan depodan gelen veriyi döndürüyoruz.
            var personeller = _personelDeposu.TumunuGetir();
            return personeller;
        }

        /// <summary>
        /// Yeni bir personel oluşturur.
        /// </summary>
        /// <param name="yeniPersonel">Oluşturulacak personel bilgileri.</param>
        public void PersonelEkle(Personel yeniPersonel)
        {
            // Burada personelin adı boş mu, departman geçerli mi gibi kontroller yapılabilir.
            // Şimdilik direkt ekleme işlemini yapıyoruz.
            _personelDeposu.Ekle(yeniPersonel);
        }

        /// <summary>
        /// Bir personeli Id'sine göre siler.
        /// </summary>
        /// <param name="id">Silinecek personelin Id'si.</param>
        public void PersonelSil(int id)
        {
            // Burada silme işlemi için ek kontroller yapılabilir.
            // Örneğin, "Yönetici pozisyonundaki personel silinemez" gibi.
            _personelDeposu.Sil(id);
        }

        /// <summary>
        /// Id'ye göre tek bir personelin bilgilerini getirir.
        /// </summary>
        /// <param name="id">Getirilecek personelin Id'si.</param>
        /// <returns>Personel nesnesi.</returns>
        public Personel PersonelGetirById(int id)
        {
            return _personelDeposu.IdYeGoreGetir(id);
        }

        /// <summary>
        /// Bir personelin bilgilerini günceller.
        /// </summary>
        /// <param name="personel">Güncellenmiş personel bilgileri.</param>
        public void PersonelGuncelle(Personel personel)
        {
            _personelDeposu.Guncelle(personel);
        }
    }
}