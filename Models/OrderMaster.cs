using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiggerBasket.Models
{
    public class OrderMaster
    {
        [key]
        public int OrderMasterId { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Range(0, int.MaxValue)]
        public int total { get; set; }
        public int CardNumber { get; set; }
        [Range(0, int.MaxValue)]
        public int AmountPaid { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        
        public virtual Customer Customer { get; set; }
        //public virtual OrderDetail OrderDetail { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }


        

    }
}
