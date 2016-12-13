using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RplNiwatori.Models;
using RplNiwatori.DAL;

namespace RplNiwatori.Controllers
{
    public class BarangController : Controller
    {
        // GET: Barang
        public ActionResult Index()
        {
            using (BarangDAL brg = new BarangDAL())
            {
                var result = brg.GetData().ToList();
                return View(result);
            }
        }

        public ActionResult Details(int id)
        {
            using (BarangDAL brg = new BarangDAL())
            {
                var result = brg.GetDataId(id);
                return View(result);
            }
        }

        public ActionResult Edit(int id)
        {
            using (BarangDAL service = new BarangDAL())
            {
                var shop = service.GetDataId(id);
                return View(shop);
            }
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(Barang brg)
        {
            using (BarangDAL service = new BarangDAL())
            {
                try
                {
                    service.Edit(brg);
                    TempData["Pesan"] = Helpers.Pesan.getPesan("Success!", "success", "Data " + brg.Stok + " successfully changed");
                }
                catch (Exception ex)
                {

                    TempData["Pesan"] = Helpers.Pesan.getPesan("Error!", "danger", ex.Message);
                }

            }
            return RedirectToAction("Index");
        }


    }
}