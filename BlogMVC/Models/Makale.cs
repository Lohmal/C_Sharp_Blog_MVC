using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Makale
    {
        public int Id { get; set; }
        public string KullaniciAd { get; set; }
        public string Baslik { get; set; }
        public string Resim { get; set; }
        public string Aciklama { get; set; }
        public DateTime YayinTarihi { get; set; }
        public int Goruntulenme { get; set; }
        public bool Onay { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public virtual ICollection<Yorum> Yorum { get; set; }

    }
}