namespace SmartRm.Models.databases.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_orderDetail
    {
        [Key]
        [Column(Order = 0)]
        public Guid order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid dishes_id { get; set; }

        public int amout { get; set; }

        public virtual tbl_dishes tbl_dishes { get; set; }

        public virtual tbl_order tbl_order { get; set; }
    }
}
