namespace SinhVien.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SINHVIEN")]
    public partial class SINHVIEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã")]
        public int MA { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Họ và tên")]
        public string HOTEN { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Quê quán")]
        public string QUEQUAN { get; set; }
           [Display(Name = "Dân tộc")]
        public int? DANTOC { get; set; }
          [Display(Name ="Lớp")]
        public int? LOP { get; set; }

          [Display(Name = "Dân tộc")]
          public virtual DANTOC DANTOC1 { get; set; }

          [Display(Name = "Lớp")]
          public virtual LOP LOP1 { get; set; }
    }
}
