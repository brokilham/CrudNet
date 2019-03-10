using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbFirstLearningWeb.Models.Entity
{
    public class WalimuridModel
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Pekerjaan { get; set; }
        public string JenisKelamin { get; set; }
        public string Hubungan { get; set; }
        public virtual ICollection<SiswaModel> Siswas { get; set; }
    }
}