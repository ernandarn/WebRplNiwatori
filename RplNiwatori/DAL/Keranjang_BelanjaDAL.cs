using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RplNiwatori.Models;

namespace RplNiwatori.DAL
{
    public class Keranjang_BelanjaDAL : IDisposable
    {
        private ModelNiwatori db = new ModelNiwatori();

        public IQueryable<Keranjang_Belanja> GetAllData(string username)
        {
            var results = from s in db.Keranjang_Belanja.Include("Barang")
                          where s.Username == username
                          orderby s.Id_Cart ascending
                          select s;
            return results;
        }

        //cek apakah barang dengan user yang sama ada di keranjang
        public Keranjang_Belanja GetItemByUser(string username, int kode)
        {
            var result = (from s in db.Keranjang_Belanja
                          where s.Username == username && s.Kode_Barang == kode
                          select s).FirstOrDefault();

            return result;
        }

        public void UbahCart(string tempUsername, string username)
        {
            var results = from s in db.Keranjang_Belanja
                          where s.Username == tempUsername
                          select s;

            foreach (var sc in results)
            {
                sc.Username = username;
            }
            db.SaveChanges();
        }

        public Barang GetDataId(int id)
        {
            var result = (from b in db.Barang
                          where b.Kode_Barang == id
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


        public void TambahCart(Keranjang_Belanja sc)
        {
            //cek apakah cart dengan pengguna dan barang sama sudah ada
            var result = GetItemByUser(sc.Username, sc.Kode_Barang);
            var stok = GetDataId(sc.Kode_Barang);
            stok.Stok -= 1;
            if (result != null)
            {
                //update
                result.Qty += 1;
            }
            else
            {
                //tambah baru
                db.Keranjang_Belanja.Add(sc);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
                //throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public Keranjang_Belanja GetItemByID(int id)
        {
            var result = (from s in db.Keranjang_Belanja
                          where s.Id_Cart == id
                          select s).SingleOrDefault();
            return result;
        }

        public void TambahNota(Nota_Pemesanan order)
        {
            //cek apakah cart dengan pengguna dan barang sama sudah ada
            var result = GetItemByID(order.No_Nota);
            if (result != null)
            {
                //update
                result.Qty += 1;
            }
            else
            {
                //tambah baru
                db.Nota_Pemesanan.Add(order);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void Hapus(int id)
        {
            var shop = GetItemByID(id);
            if (shop != null)
            {
                db.Keranjang_Belanja.Remove(shop);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Barang Tidak Ditemukan !");
            }
        }


        public void Edit(Keranjang_Belanja shop)
        {
            var result = GetItemByID(shop.Id_Cart);
            if (result != null)
            {
                result.Qty = shop.Qty;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Barang Tidak Ditemukan !");
            }
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}