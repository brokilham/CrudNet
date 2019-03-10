using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbFirstLearningWeb.Models.Entity
{
    public class SiswaModel
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
        public int? WalimuridID { get; set; }

        public virtual WalimuridModel Walimurid { get; set; }
    }
}