using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RplNiwatori.Models;
using RplNiwatori.DAL;

namespace RplNiwatori.Controllers
{
    public class Keranjang_BelanjaController : Controller
    {
        // GET: Keranjang_Belanja
        public ActionResult Index()
        {
            using (Keranjang_BelanjaDAL ker = new Keranjang_BelanjaDAL())
            {
                string username =
                Session["username"] != null ? Session["username"].ToString() : string.Empty;
                return View(ker.GetAllData(username).ToList());
            }
        }

        public ActionResult TambahCart(int id)
        {
            //cek apakah user sudah login
            if (Session["username"] == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Session["username"] = User.Identity.Name;
                }
                else
                {
                    var tempUser = Guid.NewGuid().ToString();
                    Session["username"] = tempUser;
                }
            }

            using (Keranjang_BelanjaDAL sc = new Keranjang_BelanjaDAL())
            {
                var newSc = new Keranjang_Belanja
                {
                    Username = Session["username"].ToString(),
                    Kode_Barang = id,
                    Qty = 1,
                    Tanggal = DateTime.Now
                };
                sc.TambahCart(newSc);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            using (Keranjang_BelanjaDAL service = new Keranjang_BelanjaDAL())
            {
                var shop = service.GetItemByID(id);
                return View(shop);
            }
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(Keranjang_Belanja shop)
        {
            using (Keranjang_BelanjaDAL service = new Keranjang_BelanjaDAL())
            {
                try
                {
                    service.Edit(shop);
                    TempData["Pesan"] = Helpers.Pesan.getPesan("Success!", "success", "Data " + shop.Qty + " successfully changed");
                }
                catch (Exception ex)
                {

                    TempData["Pesan"] = Helpers.Pesan.getPesan("Error!", "danger", ex.Message);
                }

            }
            return RedirectToAction("Index");
        }

        public ActionResult Hapus(int? id)
        {
            if (id != null)
            {
                using (Keranjang_BelanjaDAL service = new Keranjang_BelanjaDAL())
                {
                    try
                    {
                        service.Hapus(id.Value);
                        TempData["Pesan"] = Helpers.Pesan.getPesan("Success!", "success", "Data sudah berhasil dihapus");

                    }

                    catch (Exception ex)
                    {
                        TempData["Pesan"] = Helpers.Pesan.getPesan("Error!", "danger", ex.Message);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult CheckOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (Keranjang_BelanjaDAL service = new Keranjang_BelanjaDAL())
                {
                    string username = Session["username"] != null ? Session["username"].ToString() : string.Empty;
                    return View(service.GetAllData(username).ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Order(Nota_Pemesanan order, int id)
        {
            using (Keranjang_BelanjaDAL scService = new Keranjang_BelanjaDAL())
            {
                string username =
                   Session["username"] != null ? Session["username"].ToString() : string.Empty;
                return View(scService.GetAllData(username).ToList());
            }
        }
    }
}