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

    public partial class tbl_dishes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_dishes()
        {
            tbl_menu = new HashSet<tbl_menu>();
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

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public string description { get; set; }

        [StringLength(400)]
        public string image { get; set; }

        public virtual tbl_dishesType tbl_dishesType { get; set; }


        [JsonIgnore]
        [XmlIgnore]
        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_menu> tbl_menu { get; set; }
    }
}
