using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudGApplication.Models
{
    public class RestaurentMenu
    {
        public int RestaurentId { get; set; }
        public Restaurent Restaurent { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }


        //Navigation Properties

    }
}
