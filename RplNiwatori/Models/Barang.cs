namespace RplNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Barang")]
    public partial class Barang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Barang()
        {
            Detail_Pemesanan = new HashSet<Detail_Pemesanan>();
            Keranjang_Belanja = new HashSet<Keranjang_Belanja>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Kode Barang")]
        public int Kode_Barang { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Nama Barang")]
        public string Nama_Barang { get; set; }

        [Required]
        [StringLength(10)]
        public string Gambar { get; set; }

        [Required]
        [StringLength(6)]
        public string Satuan { get; set; }

        [Column(TypeName = "money")]
        public decimal Harga { get; set; }

        public int Stok { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detail_Pemesanan> Detail_Pemesanan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Keranjang_Belanja> Keranjang_Belanja { get; set; }
    }
}
