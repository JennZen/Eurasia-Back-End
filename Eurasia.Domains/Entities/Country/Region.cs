<<<<<<< HEAD:Eurasia.Domains/Entities/Region/Region.cs
<<<<<<< Updated upstream:Eurasia.Domains/Entities/Region/Region.cs
﻿using Eurasia.Domains.Entities.Country;
using Eurasia.Domains.Entities.Refs;
=======
﻿using Eurasia.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> Stashed changes:Eurasia.Domains/Entities/Country/Region.cs
=======
﻿using Eurasia.Domains.Entities.Refs;
>>>>>>> f87f814eece61b2637a7cc7c3e4e54ce41b8706b:Eurasia.Domains/Entities/Country/Region.cs

namespace Eurasia.Domains.Entities.Country
{
    public class Region
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<CountryData> Countries { get; set; } = new List<CountryData>();
    }
}
