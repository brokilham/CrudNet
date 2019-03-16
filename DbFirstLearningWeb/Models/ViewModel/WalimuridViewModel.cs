using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbFirstLearningWeb.Models
{
    public class WalimuridViewModel
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Pekerjaan { get; set; }
        public string JenisKelamin { get; set; }
        public string Hubungan { get; set; }
        public virtual ICollection<SiswaWalimuridViewModel> SiswaWalimurids { get; set; }
    }


    public class WalimuridAddViewModel
    {

        [Required]
        [Display(Name = "IDSiswa")]
        public int IDSiswa { get; set; }

        [Required]
        [Display(Name = "Nama")]
        public string Nama { get; set; }

        [Required]
        [Display(Name = "Pekerjaan")]
        public string Pekerjaan { get; set; }

        [Required]
        [Display(Name = "Jenis Kelamin")]
        public string JenisKelamin { get; set; }

        [Required]
        [Display(Name = "Hubungan")]
        public string Hubungan { get; set; }
    }
}