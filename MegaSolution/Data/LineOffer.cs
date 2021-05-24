using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Data
{
    public class LineOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("OfferId")]
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public Guid? CartId { get; set; }
        
    }
}
