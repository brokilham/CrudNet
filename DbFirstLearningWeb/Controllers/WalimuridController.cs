using DbFirstLearningBusiness.Models;
using DbFirstLearningWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbFirstLearningWeb.Controllers
{
    public class WalimuridController : BaseController
    {
        // GET: Walimurid
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Add(int idSiswa)
        {
            return View(new WalimuridAddViewModel()
            {
                IDSiswa = idSiswa
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(WalimuridAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                var idWalimurid = this.walimuridBusiness.Add(new csWalimurid()
                {
                    Nama = data.Nama,
                    Pekerjaan = data.Pekerjaan,
                    JenisKelamin = data.JenisKelamin,
                    Hubungan = data.Hubungan
                });


                if (idWalimurid!=0)
                {
                    this.siswaWalimuridBusiness.Add(new csSiswaWalimurid()
                    {
                        IDSiswa = data.IDSiswa,
                        IDWalimurid = idWalimurid
                    });

                }
            }

            return RedirectToAction("index", "siswa");
        }
    }
}