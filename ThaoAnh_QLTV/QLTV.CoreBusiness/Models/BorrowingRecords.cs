using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.CoreBusiness.Models
{
    public class BorrowingRecords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CustomerId { get; set; }
        public int? BookId { get; set; }
        public DateTime BorrowedDate { get; set; }      
        public DateTime ReturnedDate { get; set; }
public bool IsCheckOut { get; set; } 
       public Customer Customer { get; set; }
        public BOOK BOOK   { get; set; }
    }
}
