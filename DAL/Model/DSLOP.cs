namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSLOP")]
    public partial class DSLOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DSLOP()
        {
            DSSV = new HashSet<DSSV>();
        }

        [Key]
        [StringLength(10)]
        public string MALO { get; set; }

        [StringLength(50)]
        public string TENLOP { get; set; }

        [Required]
        [StringLength(5)]
        public string MAHE { get; set; }

        public virtual HEDT HEDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSSV> DSSV { get; set; }
    }
}
