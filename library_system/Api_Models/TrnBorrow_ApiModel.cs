using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library_system.Api_Models
{
    public class TrnBorrow_ApiModel
    {
        public Int32 Id { get; set; }
        [Required]
        public Int32 BorrowNumber { get; set; }
        [Required]
        public Int32 BookNumber { get; set; }
        [Required]
        public String BorrowDate { get; set; }
        [Required]
        public Int32 ManualBorrowNumber { get; set; }
        [Required]
        public Int32 BorrowerId { get; set; }
        [Required]
        public Int32 LibraryCardId { get; set; }
        [Required]
        public String PreparedByUser { get; set; }
        [Required]
        public Int32 CreatedByUserId { get; set; }
        [Required]
        public String CreatedDate { get; set; }

        public Int32? UpdatedByUserId { get; set; }
        public String UpdatedDate { get; set; }
    }
}