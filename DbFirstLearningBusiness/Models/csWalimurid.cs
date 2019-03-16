using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstLearningBusiness.Models
{
    public class csWalimurid
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Pekerjaan { get; set; }
        public string JenisKelamin { get; set; }
        public string Hubungan { get; set; }
        public virtual ICollection<csSiswaWalimurid> SiswaWalimurids { get; set; }
    }
}
