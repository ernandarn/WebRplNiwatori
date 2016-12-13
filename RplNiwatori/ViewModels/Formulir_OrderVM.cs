using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RplNiwatori.ViewModels
{
    public class Formulir_OrderVM
    {
        [Key]
        public int Id_Formulir { get; set; }

        public int Id_Cart { get; set; }


        [DisplayName("Nama Pelanggan")]
        public string Nama_Pelanggan { get; set; }

        [Required]
        public string Alamat { get; set; }

        public int Id_Kec { get; set; }

        [Required]
        [DisplayName("No. Hp")]
        public string No_Hp { get; set; }

        [Required]
        [StringLength(30)]
        public string Nama_Kec { get; set; }

        [Required]
        [StringLength(20)]
        public string Nama_Kab { get; set; }


        [Key]
        public int IdMetode { get; set; }


        [StringLength(8)]
        public string Nama_Metode { get; set; }
    }
}