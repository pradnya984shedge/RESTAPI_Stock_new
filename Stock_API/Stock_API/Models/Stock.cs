using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Stock_API.Entities
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public string StockName { get; set; }
        public int Quantity { get; set; }
        public string Branch { get; set; }

        [ForeignKey("ProftCenter")]
        public int Id { get; set; }

    }
}
