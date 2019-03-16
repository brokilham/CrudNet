using DbFirstLearningWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DbFirstLearningBusiness.Models;

namespace DbFirstLearningWeb.Controllers
{
    public class SiswaController : BaseController
    {
        // GET: Siswa
        [HttpGet]
        public ActionResult Index()
        {
            List<SiswaViewModel> listSiswa = new List<SiswaViewModel>();
            foreach (var item in this.siswaBusiness.GetAll())
            {
                listSiswa.Add(new SiswaViewModel()
                {
                    ID = item.ID,
                    Nama = item.Nama,
                    Alamat = item.Alamat,
                    JenisKelamin = item.JenisKelamin,
                });
            }

            return View(new SiswaIndexViewModel()
            {
                Siswas = listSiswa
            });
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
                
                var idSiswa = this.siswaBusiness.Add(new csSiswa()
                {
                    Nama = model.Nama,
                    Alamat = model.Alamat,
                    JenisKelamin = model.JenisKelamin
                });
           
            }

            return RedirectToAction("index", "siswa");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id != 0)
            {
                var data = this.siswaBusiness.GetById(id);
                return View(new SiswaEditViewModel()
                {
                    ID = data.ID,
                    Nama = data.Nama,
                    Alamat = data.Alamat,
                    JenisKelamin = data.JenisKelamin
                });
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
                this.siswaBusiness.Edit(new csSiswa()
                {
                    ID = model.ID,
                    Nama = model.Nama,
                    Alamat = model.Alamat,
                    JenisKelamin = model.JenisKelamin
                });
            }
            return RedirectToAction("index", "siswa");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                this.siswaBusiness.Delete(id);
            }
            return RedirectToAction("index", "siswa");
        }


        [HttpGet]
        public ActionResult Detail(int id)
        {

            if (id != 0)
            {
                var data = this.siswaBusiness.GetById(id);
              
                List<SiswaWalimuridViewModel> walimurid = new List<SiswaWalimuridViewModel>();
                if (data.SiswaWalimurids != null)
                {
                    foreach (var item in data.SiswaWalimurids)
                    {
                        walimurid.Add(mappingscSiswaWalimuridToSiswaWalimurid(item));
                    }
                }
              
                return View(new SiswaDetailViewModel()
                {
                   siswaViewModel = new SiswaViewModel()
                   {
                       ID = data.ID,
                       Nama = data.Nama,
                       Alamat = data.Alamat,
                       JenisKelamin = data.JenisKelamin,
                   },
                   SiswaWalimurids = walimurid
                });
            }
            else
            {
                return RedirectToAction("index", "siswa");
            }
        }


        private SiswaWalimuridViewModel mappingscSiswaWalimuridToSiswaWalimurid(csSiswaWalimurid data)
        {
            return new SiswaWalimuridViewModel()
            {
                ID = data.ID,
                IDSiswa = data.IDSiswa,
                IDWalimurid = data.IDWalimurid,
                Walimurid  = new WalimuridViewModel()
                {
                    ID  =data.Walimurid.ID,
                    Nama = data.Walimurid.Nama,
                    Pekerjaan = data.Walimurid.Pekerjaan,
                    JenisKelamin = data.Walimurid.JenisKelamin,
                    Hubungan  = data.Walimurid.Hubungan
                }
            };
        }
    }
}