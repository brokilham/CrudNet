using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstLearningBusiness.Models
{
    public class csSiswaWalimurid
    {
        public int ID { get; set; }
        public Nullable<int> IDSiswa { get; set; }
        public Nullable<int> IDWalimurid { get; set; }

        public virtual csSiswa Siswa { get; set; }
        public virtual csWalimurid Walimurid { get; set; }
    }
}
