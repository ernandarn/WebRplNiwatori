namespace RplNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detail_Pemesanan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int No_Nota { get; set; }

        public int Kode_Barang { get; set; }

        [Column(TypeName = "money")]
        public decimal Harga { get; set; }

        public int Qty { get; set; }

        public virtual Barang Barang { get; set; }

        public virtual Nota_Pemesanan Nota_Pemesanan { get; set; }
    }
}
