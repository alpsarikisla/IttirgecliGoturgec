using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ogrenci ogr = new Ogrenci();
            ogr.Isim = "Murtaza";
            ogr.Soyisim = "Kaya";
            ogr.OkulNo = "6546654";
            ogr.Okul = "Anadolu Üniversitesi";
            ogr.Bolum = "İşletme";

            Personel p = new Personel();
            p.Isim = "Şuayip";
            p.Soyisim = "Bulut";
            p.PersonelNo = "5465465465";
            p.Departman = "Satın alma";
        }
    }
}
