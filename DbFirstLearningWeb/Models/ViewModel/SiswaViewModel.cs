using DbFirstLearningWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbFirstLearningWeb.Models.ViewModel
{
   
    public class SiswaIndexViewModel
    {
       public IEnumerable<SiswaModel> Siswas { get; set;}
    }

    public class SiswaAddViewModel
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "Nama")]
        public string Nama { get; set; }

        [Required]
        [Display(Name = "Alamat")]
        public string Alamat { get; set; }

        [Required]
        [Display(Name ="Jenis Kelamin")]
        public string JenisKelamin { get; set; }
        //public Nullable<int> WalimuridID { get; set; }
        //public virtual Walimurid Walimurid { get; set; }

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

    
}
