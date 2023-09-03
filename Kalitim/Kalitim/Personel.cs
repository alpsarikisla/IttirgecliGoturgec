using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalitim
{
    //Çoklu Kalıtım Mümkün Değildir
    public class Personel:Insan
    {
        public string PersonelNo { get; set; }
        public string Departman { get; set; }
    }
}
