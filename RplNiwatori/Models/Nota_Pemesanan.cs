namespace RplNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nota_Pemesanan
    {
        [Key]
        public int No_Nota { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public DateTime Tanggal_Nota { get; set; }

        public DateTime Tanggal_Kirim { get; set; }

        public virtual Detail_Pemesanan Detail_Pemesanan { get; set; }
    }
}
