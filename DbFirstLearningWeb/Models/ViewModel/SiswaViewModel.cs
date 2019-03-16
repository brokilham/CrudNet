using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbFirstLearningWeb.Models
{

    public class SiswaViewModel
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
        public virtual ICollection<SiswaWalimuridViewModel> SiswaWalimurids { get; set; }
    }

    public class SiswaIndexViewModel
    {
        public IEnumerable<SiswaViewModel> Siswas { get; set; }
    }

    public class SiswaAddViewModel
    {

        [Required]
        [Display(Name = "Nama Siswa")]
        public string Nama { get; set; }

        [Required]
        [Display(Name = "Alamat Siswa")]
        public string Alamat { get; set; }

        [Required]
        [Display(Name = "Jenis Kelamin Siswa")]
        public string JenisKelamin { get; set; }
    }

    public class SiswaEditViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nama")]
        public string Nama { get; set; }

        [Required]
        [Display(Name = "Alamat")]
        public string Alamat { get; set; }

        [Required]
        [Display(Name = "Jenis Kelamin")]
        public string JenisKelamin { get; set; }

    }


    public class SiswaDetailViewModel
    {
       public SiswaViewModel siswaViewModel { get; set; }
       public List<SiswaWalimuridViewModel> SiswaWalimurids { get; set; }
    }
}
