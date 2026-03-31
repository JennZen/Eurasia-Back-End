using Eurasia.Domains.Enums.Eurasia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eurasia.Domains.Models.Country
{
	public class CountryShortInfoDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string FlagUrl { get; set; }
		public int Population { get; set; }
		public string Capital { get; set; }
		public int GeographicalSize { get; set; }

	}
}