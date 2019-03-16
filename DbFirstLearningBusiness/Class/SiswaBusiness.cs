using DbFirstLearningBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstLearningBusiness.Class
{
   public class SiswaBusiness
    {

        public IEnumerable<csSiswa> GetAll()
        {
            List<csSiswa> siswas = new List<csSiswa>();
            using (var context = new DbSekolahEntities())
            {
                foreach (var item in context.Siswas.ToList())
                {
                    siswas.Add(mappingSiswaTocsSiswa(item));
                }
            }
            return siswas;
        }

        public csSiswa GetById(int id)
        {
            csSiswa siswa = null;
            using (var context = new DbSekolahEntities())
            {
                var x = context.Siswas.Where(m => m.ID == id).FirstOrDefault();
                siswa = mappingSiswaTocsSiswa(context.Siswas.Where(m => m.ID == id).FirstOrDefault());
            }
            return siswa;
        }

        public int Add(csSiswa data)
        {
            int result = 0;
            if (data !=null)
            {
                using (var context = new DbSekolahEntities())
                {
                    var model = mappingSiswaTocsSiswa(data);
                    context.Siswas.Add(model);
                    context.SaveChanges();
                    result = model.ID;
                }
            }         
            return result;
        }

        public int Delete(int id)
        {
            int result = 0;
            using (var context = new DbSekolahEntities())
            {
                var data = context.Siswas.Find(id);
                context.Siswas.Remove(data);
                result = context.SaveChanges();
            }            
            return result;
        }

        public int Edit(csSiswa data)
        {
            int result = 0;
            using (var context = new DbSekolahEntities())
            {
                var model = context.Siswas.Find(data.ID);
                model.Nama = data.Nama;
                model.Alamat = data.Alamat;
                model.JenisKelamin = data.JenisKelamin;
                context.Entry(model).State = EntityState.Modified;
                result =  context.SaveChanges();
            }

            return result;
        }

        // mapping model entity to cross model
        private csSiswa mappingSiswaTocsSiswa(Siswa data)
        {
            List<csSiswaWalimurid> listCsSiswaWalimurid = new List<csSiswaWalimurid>();
            csSiswaWalimurid csSiswaWalimurid = null;
            if (data.SiswaWalimurids != null)
            {
                foreach (var item in data.SiswaWalimurids)
                {
                    csSiswaWalimurid = new csSiswaWalimurid()
                    {

                        ID = item.ID,
                        IDSiswa = item.IDSiswa,
                        IDWalimurid = item.IDWalimurid,
                        Walimurid = new csWalimurid()
                        {
                            ID = (item.Walimurid != null)?item.Walimurid.ID:0,
                            Nama = (item.Walimurid != null) ? item.Walimurid.Nama : null,
                            Pekerjaan = (item.Walimurid != null) ? item.Walimurid.Pekerjaan : null,
                            JenisKelamin = (item.Walimurid != null) ? item.Walimurid.JenisKelamin : null,
                            Hubungan  = (item.Walimurid != null) ? item.Walimurid.Hubungan : null
                        }
                    };

                    listCsSiswaWalimurid.Add(csSiswaWalimurid);
                }

            }



            return new csSiswa()
            {
                ID = data.ID,
                Nama = data.Nama,
                Alamat = data.Alamat,
                JenisKelamin = data.JenisKelamin,
                SiswaWalimurids = listCsSiswaWalimurid

            };
        }

        // mapping cross model to model entity 
        private Siswa mappingSiswaTocsSiswa(csSiswa data)
        {
            return new Siswa()
            {
                ID = data.ID,
                Nama = data.Nama,
                Alamat = data.Alamat,
                JenisKelamin = data.JenisKelamin
            };
        }

    }
}
