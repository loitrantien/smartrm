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

    public partial class tbl_menu
    {
        [Key]
        [Column(Order = 0)]
        public Guid type_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid dishes_id { get; set; }

        public bool is_active { get; set; }

        public virtual tbl_dishes tbl_dishes { get; set; }


        [JsonIgnore]
        [XmlIgnore]
        [ScriptIgnore]
        public virtual tbl_menuType tbl_menuType { get; set; }
    }
}
