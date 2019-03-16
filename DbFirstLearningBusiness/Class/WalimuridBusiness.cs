using DbFirstLearningBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstLearningBusiness.Class
{
    public class WalimuridBusiness
    {
        public int Add(csWalimurid data)
        {
            int result = 0;
            if (data != null)
            {
                using (var context = new DbSekolahEntities())
                {
                    var model = mappingWalimuridTocsWalimurd(data);
                    context.Walimurids.Add(model);
                    context.SaveChanges();
                    result = model.ID;
                }
            }
            return result;
        }


        private Walimurid mappingWalimuridTocsWalimurd(csWalimurid data)
        {
            return new Walimurid()
            {
                ID = data.ID,
                Nama = data.Nama,
                Pekerjaan = data.Pekerjaan,
                JenisKelamin = data.JenisKelamin,
                Hubungan = data.Hubungan
            };
        }
    }
}
