namespace SQLiDemoUserAgent.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlogPost
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Message { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
    }
}
