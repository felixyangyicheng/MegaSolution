﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
    [Table("Contracts")]
    public class Contract
    {
        public int ContractId { get; set; }
        [Required]
        public DateTime ContractBegins { get; set; }
        [Required]
        public int ContractDuration { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 2)]
        public string ContractReference { get; set; }
        [Required]
        public string ContractPdfFile { get; set; }
        [Required]
        public int ContractTypeId { get; set; }
        public virtual ContractType ContractType { get; set; }
    }
}
