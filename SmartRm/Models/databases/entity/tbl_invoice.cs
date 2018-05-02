namespace SmartRm.Models.databases.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_invoice()
        {
            tbl_invoiceDetail = new HashSet<tbl_invoiceDetail>();
        }

        public Guid id { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        public Guid table_id { get; set; }

        public Guid user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string time_in { get; set; }

        [Required]
        [StringLength(50)]
        public string time_out { get; set; }

        [Required]
        [StringLength(50)]
        public string date { get; set; }

        public virtual tbl_table tbl_table { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_invoiceDetail> tbl_invoiceDetail { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}
