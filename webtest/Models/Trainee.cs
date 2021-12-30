namespace webtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainee")]
    public partial class Trainee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainee()
        {
            CourseDetails = new HashSet<CourseDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("ID")]
        public int trainee_id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string trainee_name { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("Day of Birth")]
        public DateTime day_of_birth { get; set; }

        [DisplayName("Phone")]
        public int phone_number { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Email")]
        public string email_address { get; set; }

        [Required]
        [DisplayName("Address")]
        public string local_address { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("CourseID")]
        public string course_id { get; set; }


        [DisplayName("Toiec")]
        public int course_toiec { get; set; }

        [DisplayName("AccDetailID")]
        public int account_detail_id { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }
    }
}
