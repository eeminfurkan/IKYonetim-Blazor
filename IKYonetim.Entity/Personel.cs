using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IKYonetim.Varliklar projesi icindeki Personel.cs dosyasi

namespace IKYonetim.Varliklar
{
    public class Personel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen personel adını giriniz.")] // Bu satırı ekliyoruz
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen personel soyadını giriniz.")] // Bu satırı ekliyoruz
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Lütfen departman bilgisini giriniz.")] // Bu satırı ekliyoruz
        public string Departman { get; set; }

        public string Pozisyon { get; set; } // Pozisyon zorunlu olmasın
        public DateTime IseGirisTarihi { get; set; }
    }
}