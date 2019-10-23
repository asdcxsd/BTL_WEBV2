namespace BTL_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_xulydon
    {
        [StringLength(20)]
        public string id { get; set; }

        [Required]
        [StringLength(12)]
        public string id_don { get; set; }

        [StringLength(30)]
        public string tinhtrang { get; set; }

        public DateTime? thoigian { get; set; }

        public virtual tbl_dondathang tbl_dondathang { get; set; }
    }
}
