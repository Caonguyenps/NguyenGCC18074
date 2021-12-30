namespace webtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("ID")]
        public int admin_id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string admin_name { get; set; }

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
        public int account_id { get; set; }

        public virtual Account Account { get; set; }
    }
}
