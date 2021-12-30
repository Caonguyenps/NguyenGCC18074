namespace webtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            CourseDetails = new HashSet<CourseDetail>();
            Topics = new HashSet<Topic>();
        }

        [Key]
        [StringLength(10)]
        [DisplayName("ID")]
        public string course_id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string course_name { get; set; }


        [DisplayName("Toeic")]
        public int course_toeic { get; set; }

        [DisplayName("AccountID")]
        public int account_id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Desriptions")]
        public string desription { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("CatID")]
        public string cat_id { get; set; }


        [DisplayName("TrainerID")]
        public int trainer_id { get; set; }

        public virtual Category Category { get; set; }

        public virtual Trainer Trainer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
