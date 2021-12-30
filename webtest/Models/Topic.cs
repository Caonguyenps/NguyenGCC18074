namespace webtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("ID")]
        public int topic_id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string topic_name { get; set; }

        [Required]
        [DisplayName("Descriptions")]
        public string descriptions { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("CourseID")]
        public string course_id { get; set; }

        public virtual Course Course { get; set; }
    }
}
