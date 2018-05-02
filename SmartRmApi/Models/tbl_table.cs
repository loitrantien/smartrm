namespace SmartRmApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;

    public partial class tbl_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_table()
        {
            tbl_invoice = new HashSet<tbl_invoice>();
            tbl_order = new HashSet<tbl_order>();
        }

        public Guid id { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public Guid type_id { get; set; }

        public Guid floor_id { get; set; }

        public virtual tbl_floor tbl_floor { get; set; }


        [JsonIgnore]
        [XmlIgnore]
        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_invoice> tbl_invoice { get; set; }


        [JsonIgnore]
        [XmlIgnore]
        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_order> tbl_order { get; set; }

        public virtual tbl_tableType tbl_tableType { get; set; }
    }
}
