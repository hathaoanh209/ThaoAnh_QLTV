using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.CoreBusiness.Models
{
    public  class Customer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Password { get; set; }
       
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
