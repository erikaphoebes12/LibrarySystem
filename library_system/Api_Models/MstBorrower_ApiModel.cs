
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library_system.Api_Models
{
    public class MstBorrower_ApiModel
    {
        public Int32 Id { get; set; }
        [Required]
        public Int32 BorrowerNumber { get; set; }
        [Required]
        public Int32 ManualBorrowerNumber { get; set; }
        [Required]
        public String FullName { get; set; }
        [Required]
        public String Department { get; set; }
        [Required]
        public String Course { get; set; }
        [Required]
        public Int32 CreatedByUserId { get; set; }
        [Required]
        public String CreatedDate { get; set; }

        public Int32? UpdatedByUserId { get; set; }
        
        public string UpdatedDate { get; set; }
        [Required]
        public Int32 BorrowerTypeId { get; set; }
        [Required]
        public Int32 LibraryCardId { get; set; }
    }
}