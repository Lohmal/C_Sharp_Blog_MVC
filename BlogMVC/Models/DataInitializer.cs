using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogMVC.Models
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategori = new List<Kategori>()
            {
                new Kategori() {KategoriAd="C#"},
                new Kategori() {KategoriAd="MVC"},
                new Kategori() {KategoriAd="C++"},
            };
            foreach (var item in kategori)
            {
                context.Kategoris.Add(item);
            }
            context.SaveChanges();

            var makale = new List<Makale>() 
            {
                new Makale() {Baslik="C# Dilindeki Veri Tipleri",Aciklama="Öncelikle veri tipi nedir ve ne gibi bir görevi vardır sorularının cevabını arayalım. C# dili için her sınıf bir veri tipidir. Klasik programlama dillerinde karakterler, tamsayılar, kesirli sayılar ve boolean gibi ilkel veri tipleri dile gömülüdür ve her bir veri tipi bir anahtar sözcükle ifade edilmektedir. Fakat C# gibi nesne yönelimli programlama dillerinde her sınıf soyut bir veri yapısını göstermektedir. Bundan dolayı C# ilkel veri tiplerinden arındırılmış haldedir.",Resim="Resim1.jpg",YayinTarihi=Convert.ToDateTime("2021-08-14"),Goruntulenme=0,Onay=true,KategoriId=1,KullaniciAd="volkankivanc"},
                new Makale() {Baslik="MVC Nedir?",Aciklama="MVC, Yazılım Mühendisliği’nde önemli bir yere sahip architectural patterns (yazılım mimari desenleri)’ın bir parçasıdır. Model, View ve Controller kelimelerinin baş harflerinden oluşan MVC (Model-View-Controller), 1979 yılında Tygve Reeskaug tarafından oluşturulmuş ve yazılım gelişmede bir çok projede kullanılmıştır. Son dönemlerde Microsoft’un MVC desenini Asp.Net teknolojisi ile birleştirmesi ile popülaritesi daha da artmıştır.",Resim="Resim2.jpg",YayinTarihi=Convert.ToDateTime("2021-08-16"),Goruntulenme=0,Onay=true,KategoriId=2,KullaniciAd="volkankivanc"},
                new Makale() {Baslik="C++ Nedir?",Aciklama="C++, 1979 yılında Bjarne Stroustrup tarafından Bell Labs’da geliştirilen nesne yönelimli ve yüksek seviyeli, genel maksatlı programlama dilidir. C++’ın ilk ismi “C with classes” dir ve C programlama dilinin bir eklentisi olarak işlev görmektedir.",Resim="Resim3.jpg",YayinTarihi=Convert.ToDateTime("2021-08-20"),Goruntulenme=0,Onay=true,KategoriId=3,KullaniciAd="irmakkivanc"}
            };
            foreach (var item in makale)
            {
                context.Makales.Add(item);
            }
            context.SaveChanges();


        }
    }
}