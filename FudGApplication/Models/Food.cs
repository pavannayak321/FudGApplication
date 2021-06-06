using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FudGApplication.Models
{
    [Table("Food")]
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        public string FoodTitle { get; set; }
        public string FoodDescription { get; set; }
        public decimal FoodPrice { get; set; }
        
        //Navigation Properties
        public List<Restaurent> Restaurents { get; set; }
        public List<Customer> Cutomers { get; set; }

        public List<CustomerRestaurentFoodBridge> CustomerRestaurentFoodBridges { get; set; }
     }
}
