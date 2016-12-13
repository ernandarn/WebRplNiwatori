using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RplNiwatori.Models;

namespace RplNiwatori.DAL
{
    public class Metode_BayarDAL : IDisposable 
    {
        private ModelNiwatori db = new ModelNiwatori();

        public IQueryable<Metode_Bayar> GetData()
        {
            var results = from c in db.Metode_Bayar
                          select c;
            return results;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}