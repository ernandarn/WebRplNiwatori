using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RplNiwatori.Models;
using RplNiwatori.ViewModels;
using RplNiwatori.DAL;

namespace RplNiwatori.Controllers
{
    public class Nota_PemesananController : Controller
    {
        // GET: Nota_Pemesanan
        public ActionResult Index(int id)
        {
            using (Nota_PemesananDAL service = new Nota_PemesananDAL())
            {
                return View(service.OrderVMGetAll(id).ToList());
            }
        }

        public ActionResult Invoice(int idorder)
        {
            using (Nota_PemesananDAL service = new Nota_PemesananDAL())
            {
                return View(service.OrderVMGetAll(idorder).ToList());
            }
        }

        public ActionResult OrderNew()
        {
            var orders = new Nota_Pemesanan
            {

                Username = Session["username"].ToString(),
                Tanggal_Nota = DateTime.Now,
                Tanggal_Kirim = DateTime.Now.AddDays(1)


            };
            using (Nota_PemesananDAL service = new Nota_PemesananDAL())
            {
                service.TambahNota(orders);
                foreach (var ord in service.GetAllData(Session["username"].ToString()).ToList())
                {
                    var detailord = new Detail_Pemesanan
                    {
                        No_Nota = orders.No_Nota,
                        Kode_Barang = ord.Kode_Barang,
                        Qty = ord.Qty,
                        Harga = ord.Barang.Harga,
                    };
                    service.TambahDetail(detailord);
                    service.hapusCart(ord);
                }
            }
            return RedirectToAction("Index", new { id = orders.No_Nota });
        }
    }
}