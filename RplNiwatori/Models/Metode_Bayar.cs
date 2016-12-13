namespace RplNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Metode_Bayar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Metode_Bayar()
        {
            Formulir_Order = new HashSet<Formulir_Order>();
        }

        [Key]
        public int IdMetode { get; set; }

        [Required]
        [StringLength(8)]
        public string Nama_Metode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulir_Order> Formulir_Order { get; set; }
    }
}
