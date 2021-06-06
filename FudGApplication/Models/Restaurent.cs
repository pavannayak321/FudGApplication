using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FudGApplication.Models
{
    [Table("Restaurent")]
    public class Restaurent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurentId { get; set; }
        public string RestaurentName { get; set; }
        public string RestaurentAddress { get; set; }

        //Navigation Property
        public ICollection<RestaurentMenu> RestaurentMenus { get; set; }
        public ICollection<Orders> Orders { get; set; }

    }
}
