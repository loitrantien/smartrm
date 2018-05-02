namespace SmartRm.Models.databases.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_dishes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_dishes()
        {
            tbl_invoiceDetail = new HashSet<tbl_invoiceDetail>();
            tbl_orderDetail = new HashSet<tbl_orderDetail>();
        }

        public Guid id { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public Guid type_id { get; set; }

        [Required]
        [StringLength(100)]
        public string unit { get; set; }

        [Required]
        [StringLength(10)]
        public string price { get; set; }

        public string description { get; set; }

        [StringLength(100)]
        public string image { get; set; }

        public virtual tbl_dishesType tbl_dishesType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_invoiceDetail> tbl_invoiceDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_orderDetail> tbl_orderDetail { get; set; }
    }
}
