namespace RplNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Keranjang_Belanja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Keranjang_Belanja()
        {
            Formulir_Order = new HashSet<Formulir_Order>();
        }

        [Key]
        public int Id_Cart { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [DisplayName("Kode Barang")]
        public int Kode_Barang { get; set; }

        public int Qty { get; set; }

        public DateTime Tanggal { get; set; }

        public virtual Barang Barang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulir_Order> Formulir_Order { get; set; }
    }
}
