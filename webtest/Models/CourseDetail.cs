namespace webtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseDetail")]
    public partial class CourseDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("ID")]
        public int course_detail_id { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("CourseID")]
        public string course_id { get; set; }

        [DisplayName("TraineeID")]
        public int trainee_id { get; set; }

        public virtual Course Course { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}
