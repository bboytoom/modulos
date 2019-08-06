namespace Administrator.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Groups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Groups()
        {
            Tbl_Users = new HashSet<Tbl_Users>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_group { get; set; }

        [StringLength(200)]
        public string Description_group { get; set; }

        public bool Active_group { get; set; }

        public int? UpdateU_group { get; set; }

        public DateTime? UpdateD_group { get; set; }

        public int? CreateU_group { get; set; }

        public DateTime? CreateD_group { get; set; }

        public int? DeleteU_group { get; set; }

        public DateTime? DeleteD_group { get; set; }

        public bool? Delete_stautus_group { get; set; }

        public int MainU_group { get; set; }

        public virtual Tbl_Permissions Tbl_Permissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Users> Tbl_Users { get; set; }
    }
}