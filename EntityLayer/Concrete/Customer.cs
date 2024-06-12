using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Customer
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
