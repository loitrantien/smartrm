namespace SmartRmApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_deviceRegistration
    {
        public Guid id { get; set; }

        [Required]
        public string gcm_regId { get; set; }

        [Required]
        [StringLength(50)]
        public string device_name { get; set; }

        [Required]
        [StringLength(50)]
        public string device_id { get; set; }
    }
}
