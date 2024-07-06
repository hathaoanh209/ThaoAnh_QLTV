using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.CoreBusiness.Models;

    public  class BOOK
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
        public int BookId {  get; set; }
       
        public string? Name { get; set; }
       
        public string? Author { get; set; }
       
        public string? TypeOfBook { get; set; }
      
        public string? Description { get; set; }
	
        public string? ImageLink { get; set; }
       
         public bool Available { get; set; }
	
}

