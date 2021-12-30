namespace webtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("ID")]
        public int trainer_id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string trainer_name { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Education")]
        public string education { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("External or Internal")]
        public string external_or_internal { get; set; }

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

        [DisplayName("AccountID")]
        public int accout_id { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
