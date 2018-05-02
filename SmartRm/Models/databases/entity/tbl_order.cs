namespace SmartRm.Models.databases.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_order()
        {
            tbl_orderDetail = new HashSet<tbl_orderDetail>();
        }

        public Guid id { get; set; }

        public DateTime create_date { get; set; }

        public DateTime update_date { get; set; }

        public string note { get; set; }

        public Guid table_id { get; set; }

        [Required]
        [StringLength(10)]
        public string state { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_orderDetail> tbl_orderDetail { get; set; }
    }
}
