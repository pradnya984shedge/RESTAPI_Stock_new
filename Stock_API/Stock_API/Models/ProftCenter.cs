using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stock_API.Entities
{
    public class ProftCenter
    {
        [Key]
        public int Id { get; set; }
        public string ProftCenterName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public List<Stock> stocks { get; set; }
    }
}
