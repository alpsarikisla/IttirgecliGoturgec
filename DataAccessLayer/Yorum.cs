using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorum
    {
        public int ID { get; set; }
        public int MakaleID { get; set; }
        public string Makale { get; set; }
        public int UyeID { get; set; }
        public string Uye { get; set; }
        public string Icerik { get; set; }
        public int YoneticiID { get; set; }
        public string Yonetici { get; set; }
        public DateTime YorumTarihi { get; set; }
        public bool Onayli { get; set; }
    }
}
