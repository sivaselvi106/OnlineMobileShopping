using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileShopping.Entity
{
    public class Account
    {
        
        [Required]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$")]
        [MinLength(4),MaxLength(20)]
        public string UserName { get; set; }
        
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        [RegularExpression("^[\\w-_\\.+]*[\\w-_\\.]\\@([\\w]+\\.)+[\\w]+[\\w]$", ErrorMessage = "Not Valid EmailId")]
      // [RegularExpression(" ^[a - zA - Z0 - 9_\\.-] +@([a - zA - Z0 - 9 -] +\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Not Valid EmailId")]
        public string MailId { get; set; }
       
        [Required]
        [MinLength(8),MaxLength(10)]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdatedDate { get; set; }
        public DateTime LastLoginTime { get; set; }
      
        [Range(1, 100, ErrorMessage = "Age Should be min 1 and max 100")]
        public int Age { get; set; }
   
        [Required]
        public string Gender { get; set; }
      
        [Required]
        [RegularExpression(@"^([789]\d{9})$", ErrorMessage = "Invalid Mobile Number.")]
        public long MobileNo { get; set; }
        public string City { get; set; }

    }
}
