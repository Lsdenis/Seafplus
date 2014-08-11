using System.Collections.Generic;

namespace Seafplus.Models
{
	public class ListViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int OrderNumber { get; set; }
		public List<string> Cards { get; set; }
	}
}