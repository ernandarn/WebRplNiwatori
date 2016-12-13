namespace RplNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Master_Kecamatan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Master_Kecamatan()
        {
            Formulir_Order = new HashSet<Formulir_Order>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Kec { get; set; }

        [Required]
        [StringLength(30)]
        public string Nama_Kec { get; set; }

        [Required]
        [StringLength(20)]
        public string Nama_Kab { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formulir_Order> Formulir_Order { get; set; }
    }
}
