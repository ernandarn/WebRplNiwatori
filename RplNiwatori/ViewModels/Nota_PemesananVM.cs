using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RplNiwatori.ViewModels
{
    public class Nota_PemesananVM
    {
        [Key]
        public int No_Nota { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public DateTime Tanggal_Nota { get; set; }

        public DateTime Tanggal_Kirim { get; set; }

        public int Kode_Barang { get; set; }

        public string Nama_Barang { get; set; }

        [Column(TypeName = "money")]
        public decimal Harga { get; set; }

        public int Qty { get; set; }
    }
}