using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Order_ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}