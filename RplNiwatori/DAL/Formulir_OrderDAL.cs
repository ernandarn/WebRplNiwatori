using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RplNiwatori.Models;
using RplNiwatori.ViewModels;

namespace RplNiwatori.DAL
{
    public class Formulir_OrderDAL : IDisposable
    {
        private ModelNiwatori db = new ModelNiwatori();

        public IQueryable<Formulir_Order> GetData()
        {
            var result = from b in db.Formulir_Order
                         orderby b.Id_Formulir
                         select b;
            return result;
        }

        public IQueryable<Formulir_OrderVM> GetFormWithKec()
        {
            var result = from b in db.Formulir_Order.Include("Master_Kecamatan")
                         orderby b.Id_Formulir
                         select new Formulir_OrderVM
                         {
                             Id_Formulir = b.Id_Formulir,
                             Id_Kec = b.Id_Kec,
                             Id_Cart = b.Id_Cart,
                             Nama_Pelanggan = b.Nama_Pelanggan,
                             Alamat = b.Alamat,
                             No_Hp = b.No_Hp,
                             Nama_Kec = b.Master_Kecamatan.Nama_Kec,
                             Nama_Kab = b.Master_Kecamatan.Nama_Kab,
                         };
            return result;
        }

        public Formulir_Order GetItemByID(int id)
        {
            var result = (from s in db.Formulir_Order
                          where s.Id_Formulir == id
                          select s).SingleOrDefault();
            return result;
        }

        public void Add(Formulir_Order form)
        {
            db.Formulir_Order.Add(form);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}