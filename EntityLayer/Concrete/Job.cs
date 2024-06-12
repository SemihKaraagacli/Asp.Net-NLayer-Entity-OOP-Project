using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Job
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int JobId { get; set; }
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
