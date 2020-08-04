using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library_system.Api_Models
{
    public class MstUser_ApiModel
    {
        public Int32 Id { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        public Int32 UserTypeId { get; set; }
        [Required]
        public String AspNetUserId { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 8)]
        public String UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
    }
}