using DbFirstLearningBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstLearningBusiness.Class
{
    public class SiswaWalimuridBusiness
    {
        public csSiswaWalimurid GetById(int id)
        {
            csSiswaWalimurid siswa = null;
            using (var context = new DbSekolahEntities())
            {
                var x = context.SiswaWalimurids.Where(m => m.ID == id).FirstOrDefault();
                //siswa = mappingSiswaTocsSiswa(context.Siswas.Where(m => m.ID == id).FirstOrDefault());
            }

            return siswa;
        }

        public int Add(csSiswaWalimurid data)
        {
            int result = 0;
            using (var context = new DbSekolahEntities())
            {
                context.SiswaWalimurids.Add(mappingCstoEntity(data));
                context.SaveChanges();
            }
            return result;
        }

        // mapping model entity to cross model
        //private csSiswa mappingSiswaTocsSiswa(Siswa data)
        //{
        //    return new csSiswa()
        //    {
        //        ID = data.ID,
        //        Nama = data.Nama,
        //        Alamat = data.Alamat,
        //        JenisKelamin = data.JenisKelamin,
        //        IDSiswaWalimurid = data.IDSiswaWalimurid
        //    };
        //}

        // mapping cross model to model entity 
        private SiswaWalimurid mappingCstoEntity(csSiswaWalimurid data)
        {
            return new SiswaWalimurid()
            {
                ID = data.ID,
                IDSiswa = data.IDSiswa,
                IDWalimurid = data.IDWalimurid,             
            };
        }
    }
}
