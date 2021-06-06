using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudGApplication.Models
{
    public class Orders
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public int RestaurentId { get; set; }
        public Restaurent Restaurent{ get; set; }


        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
