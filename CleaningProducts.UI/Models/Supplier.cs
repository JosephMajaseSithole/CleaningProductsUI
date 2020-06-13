using System.ComponentModel.DataAnnotations;

namespace CleaningProducts.UI.Models
{
	public class Supplier
	{
		public int Id { get; set; }
		public string Code { get; set; }

		[Display(Name = "Company Name")]
		public string Name { get; set; }

		[Display(Name = "Telephone Number")]
		public string Telephone { get; set; }
	}
}