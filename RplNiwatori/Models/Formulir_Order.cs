namespace RplNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Formulir_Order
    {
        [Key]
        public int Id_Formulir { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Nama Pelanggan")]
        public string Nama_Pelanggan { get; set; }

        public int? Id_Metode { get; set; }

        public int Id_Cart { get; set; }

        [Required]
        [StringLength(50)]
        public string Alamat { get; set; }

        public int Id_Kec { get; set; }

        [Required]
        [StringLength(12)]
        [DisplayName("No. Hp")]
        public string No_Hp { get; set; }

        public virtual Keranjang_Belanja Keranjang_Belanja { get; set; }

        public virtual Master_Kecamatan Master_Kecamatan { get; set; }

        public virtual Metode_Bayar Metode_Bayar { get; set; }
    }
}
