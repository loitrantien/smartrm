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

    public partial class tbl_orderDetail
    {
        [Key]
        [Column(Order = 0)]
        public Guid order_id { get; set; }

        public int amout { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }


        [JsonIgnore]
        [XmlIgnore]
        [ScriptIgnore]
        public virtual tbl_order tbl_order { get; set; }
    }
}
