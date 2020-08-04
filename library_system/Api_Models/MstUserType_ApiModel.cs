using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library_system.Api_Models
{
    public class MstUserType_ApiModel
    {
        public Int32 Id { get; set; }
        [Required]
        public String UserType { get; set; }
    }
}