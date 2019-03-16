using DbFirstLearningBusiness.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbFirstLearningWeb.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this._siswaBusiness = new SiswaBusiness();
            this._siswaWalimuridBusiness = new SiswaWalimuridBusiness();
            this._walimuridBusiness = new WalimuridBusiness();
        }


        private SiswaBusiness _siswaBusiness { get; set; }
        public SiswaBusiness siswaBusiness
        {
            get
            {
                return this._siswaBusiness ?? new SiswaBusiness();
            }
            set
            {
                this._siswaBusiness = value;
            }
        }


        private SiswaWalimuridBusiness _siswaWalimuridBusiness { get; set; }
        public SiswaWalimuridBusiness siswaWalimuridBusiness
        {
            get
            {
                return this._siswaWalimuridBusiness ?? new SiswaWalimuridBusiness();
            }
            set
            {
                this._siswaWalimuridBusiness = value;
            }
        }

        private WalimuridBusiness _walimuridBusiness { get; set; }
        public WalimuridBusiness walimuridBusiness
        {
            get
            {
                return this._walimuridBusiness ?? new WalimuridBusiness();
            }
            set
            {
                this._walimuridBusiness = value;
            }
        }
    }
}