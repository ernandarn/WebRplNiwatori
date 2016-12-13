using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RplNiwatori.Models;

namespace RplNiwatori.DAL
{
    public class BarangDAL : IDisposable
    {
        private ModelNiwatori db = new ModelNiwatori();

        public IQueryable<Barang> GetData()
        {
            var result = from b in db.Barang
                         orderby b.Nama_Barang
                         select b;
            return result;
        }

        public Barang GetDataId(int id)
        {
            var result = (from b in db.Barang
                          where b.Kode_Barang == id
                          orderby b.Nama_Barang
                          select b).SingleOrDefault();
            //return result;
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Barang Tidak Ditemukan !");
            }
        }

        public void Edit(Barang brg)
        {
            var result = GetDataId(brg.Kode_Barang);
            if (result != null)
            {
                result.Kode_Barang = brg.Kode_Barang;
                result.Nama_Barang = brg.Nama_Barang;
                result.Satuan = brg.Satuan;
                result.Gambar = brg.Gambar;
                result.Harga = brg.Harga;
                result.Stok = brg.Stok;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Barang Tidak Ditemukan!");
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}