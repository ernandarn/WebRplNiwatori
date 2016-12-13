using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RplNiwatori.Models;

namespace RplNiwatori.DAL
{
    public class MasterKecamatanDAL : IDisposable
    {
        private ModelNiwatori db = new ModelNiwatori();

        public IQueryable<Master_Kecamatan> GetDataKec()
        {
            var results = from c in db.Master_Kecamatan
                          select c;
            return results;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}