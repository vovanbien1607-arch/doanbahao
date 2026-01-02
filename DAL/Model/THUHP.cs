namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUHP")]
    public partial class THUHP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MASV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MAHP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYQD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYTHU { get; set; }

        public int? SOTIEN { get; set; }

        public virtual DSSV DSSV { get; set; }

        public virtual HOCPHI HOCPHI { get; set; }
    }
}
