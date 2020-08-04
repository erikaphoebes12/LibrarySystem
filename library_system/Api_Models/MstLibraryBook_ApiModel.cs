using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library_system.Api_Models
{
    public class MstLibraryBook_ApiModel
    {
        public Int32 Id { get; set; }
        [Required]
        public Int32 BookNumber { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Author { get; set; }
        [Required]
        public String EditionNumber { get; set; }
        [Required]
        public String PlaceOfPublication { get; set; }
        [Required]
        public String CopyRightDate { get; set; }
        [Required]
        public String ISBN { get; set; }
        [Required]
        public Int32 CreatedByUserId { get; set; }
        [Required]
        public String CreatedBy { get; set; }
        [Required]
        public String CreatedDate { get; set; }

        public Int32? UpdatedByUserId { get; set; }
        public String UpdatedBy { get; set; }
        public String UpdatedDate { get; set; }
    }
}