using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RplNiwatori.Models;
using RplNiwatori.ViewModels;

namespace RplNiwatori.DAL
{
    public class Nota_PemesananDAL : IDisposable
    {
        private ModelNiwatori db = new ModelNiwatori();

        public IQueryable<Keranjang_Belanja> GetAllData(string id)
        {
            var results = from s in db.Keranjang_Belanja
                          where s.Username == id
                          select s;

            return results;
        }

        public IQueryable<Nota_PemesananVM> OrderVMGetAll(int id)
        {
            var result = from a in db.Detail_Pemesanan.Include("Nota_Pemesanan")
                         where a.No_Nota == id
                         select new Nota_PemesananVM
                         {
                             No_Nota = a.Nota_Pemesanan.No_Nota,
                             UserName = a.Nota_Pemesanan.Username,
                             Tanggal_Nota = a.Nota_Pemesanan.Tanggal_Nota,
                             Tanggal_Kirim = a.Nota_Pemesanan.Tanggal_Kirim,
                             Kode_Barang = a.Barang.Kode_Barang,
                             Nama_Barang = a.Barang.Nama_Barang,
                             Harga = a.Barang.Harga,
                             Qty = a.Qty,
                         };
            return result;
        }

        public void TambahNota(Nota_Pemesanan obj)
        {
            try
            {
                db.Nota_Pemesanan.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void TambahDetail(Detail_Pemesanan obj)
        {
            try
            {
                db.Detail_Pemesanan.Add(obj);
                db.SaveChanges();
            }
            catch (InvalidCastException e)
            {
                throw new Exception("Eror", e);
            }
        }

        public void hapusCart(Keranjang_Belanja obj)
        {
            try
            {
                db.Keranjang_Belanja.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}