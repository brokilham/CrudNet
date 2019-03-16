using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbFirstLearningWeb.Models
{
    public class SiswaWalimuridViewModel
    {

        public int ID { get; set; }
        public Nullable<int> IDSiswa { get; set; }
        public Nullable<int> IDWalimurid { get; set; }

        public virtual SiswaViewModel Siswa { get; set; }
        public virtual WalimuridViewModel Walimurid { get; set; }
    }
}