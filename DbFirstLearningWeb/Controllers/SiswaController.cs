using DbFirstLearningBusiness;
using DbFirstLearningWeb.Models.ViewModel;
using DbFirstLearningWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DbFirstLearningWeb.Controllers
{
    public class SiswaController : Controller
    {
        // GET: Siswa
        public ActionResult Index()
        {          
            List<SiswaModel> listSiswa = new List<SiswaModel>();
            using (var context = new DbSekolahEntities())
            {
                foreach (var item in context.Siswas.ToList())
                {
                    listSiswa.Add(MappingSiswaToViewModel(item));
                }
            }

            SiswaIndexViewModel indexSiswa = new SiswaIndexViewModel()
            {
                Siswas = listSiswa
            };

            return View(indexSiswa);
        }
    
        [HttpGet]
        public ViewResult Add()
        {

            return View(new SiswaAddViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SiswaAddViewModel model)
        {

            if (ModelState.IsValid)
            {
                using (var context = new DbSekolahEntities())
                {
                    Siswa data = new Siswa()
                    {
                        Nama = model.Nama,
                        Alamat = model.Alamat,
                        JenisKelamin = model.JenisKelamin,
                    };
                    context.Siswas.Add(data);
                    context.SaveChanges();
                }

            }

            return RedirectToAction("index", "siswa");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id != 0)
            {
                SiswaEditViewModel model = new SiswaEditViewModel();
                using (var context = new DbSekolahEntities())
                {
                    var entity = context.Siswas.Where(m => m.ID == id).FirstOrDefault();
                    model.ID = entity.ID;
                    model.Nama = entity.Nama;
                    model.Alamat = entity.Alamat;
                    model.JenisKelamin = entity.JenisKelamin;
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("index", "siswa");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiswaEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DbSekolahEntities())
                {
                 
                    var data = context.Siswas.Find(model.ID);
                    data.Nama = model.Nama;
                    data.Alamat = model.Alamat;
                    data.JenisKelamin = model.JenisKelamin;
                    context.Entry(data).State = EntityState.Modified;
                    context.SaveChanges();
                }

            }
            return RedirectToAction("index", "siswa");
        }


        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                SiswaEditViewModel model = new SiswaEditViewModel();
                using (var context = new DbSekolahEntities())
                {
                    var data = context.Siswas.Find(id);
                    context.Siswas.Remove(data);
                    context.SaveChanges();
                }
            
            }
            return RedirectToAction("index", "siswa");
        }


        public SiswaModel MappingSiswaToViewModel(Siswa entity)
        {
            WalimuridModel Walimurid = new WalimuridModel();


            if (entity.Walimurid != null)
            {
                Walimurid.ID = entity.Walimurid.ID;
                Walimurid.Nama = entity.Walimurid.Nama;
                Walimurid.Pekerjaan = entity.Walimurid.Pekerjaan;
                Walimurid.JenisKelamin = entity.Walimurid.JenisKelamin;
                Walimurid.Hubungan = entity.Walimurid.Hubungan;
            }


            SiswaModel siswa = new SiswaModel()
            {
                ID = entity.ID,
                Nama = entity.Nama,
                Alamat = entity.Alamat,
                JenisKelamin = entity.JenisKelamin,
                WalimuridID = entity.WalimuridID,
                Walimurid = Walimurid

            };

            return siswa;

            // jika walimurid merupakan non nullable
            //return new SiswaModel()
            //{
            //    ID = entity.ID,
            //    Nama = entity.Nama,
            //    Alamat = entity.Alamat,
            //    JenisKelamin = entity.JenisKelamin,
            //    WalimuridID = entity.WalimuridID,
            //    Walimurid = new WalimuridModel()
            //    {
            //        ID = entity.Walimurid.ID,
            //        Nama = entity.Walimurid.Nama,
            //        Pekerjaan = entity.Walimurid.Pekerjaan,
            //        JenisKelamin = entity.Walimurid.JenisKelamin,
            //        Hubungan = entity.Walimurid.Hubungan,
            //    }
            //};

        }
    }
}