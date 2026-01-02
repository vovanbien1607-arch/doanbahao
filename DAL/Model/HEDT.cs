namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HEDT")]
    public partial class HEDT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HEDT()
        {
            DSLOP = new HashSet<DSLOP>();
        }

        [Key]
        [StringLength(5)]
        public string MAHE { get; set; }

        [StringLength(50)]
        public string TENHE { get; set; }

        public int? HPCB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSLOP> DSLOP { get; set; }
    }
}
