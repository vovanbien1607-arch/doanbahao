namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSSV")]
    public partial class DSSV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DSSV()
        {
            THUHP = new HashSet<THUHP>();
        }

        [Key]
        [StringLength(10)]
        public string MASV { get; set; }

        [StringLength(50)]
        public string HOTEN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        [Required]
        [StringLength(10)]
        public string MALO { get; set; }

        [StringLength(20)]
        public string DIENUIT { get; set; }

        public virtual DSLOP DSLOP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUHP> THUHP { get; set; }
    }
}
