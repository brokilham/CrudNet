using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstLearningBusiness.Models
{
   public class csSiswa
    {
  
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
        public virtual ICollection<csSiswaWalimurid> SiswaWalimurids { get; set; }
    }
}
