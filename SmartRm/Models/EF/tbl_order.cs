//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartRm.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_order()
        {
            this.tbl_orderDetail = new HashSet<tbl_orderDetail>();
        }
    
        public System.Guid id { get; set; }
        public System.DateTime create_date { get; set; }
        public System.DateTime update_date { get; set; }
        public string note { get; set; }
        public System.Guid table_id { get; set; }
        public string state { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_orderDetail> tbl_orderDetail { get; set; }
    }
}
