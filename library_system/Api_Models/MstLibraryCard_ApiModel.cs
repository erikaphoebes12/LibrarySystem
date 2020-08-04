using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library_system.Api_Models
{
    public class MstLibraryCard_ApiModel
    {
        public Int32 Id { get; set; }
        [Required]
        public Int32 LibraryCardNumber { get; set; }

        public Int32? ManualLibraryCardNumber { get; set; }
        [Required]
        public Int32 BorrowerId { get; set; }
        [Required]
        public Boolean IsPrinted { get; set; }

        public Int32? LibraryInChargeUserId { get; set; }
        [Required]
        public String FootNote { get; set; }
        [Required]
        public Int32 CreatedByUserId { get; set; }
        [Required]
        public String CreatedDate { get; set; }

        public Int32? UpdatedByUserId { get; set; }
        public String UpdatedDate { get; set; }
    }
}