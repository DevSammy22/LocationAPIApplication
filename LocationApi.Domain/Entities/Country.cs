using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Domain.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Iso { get; set; }
        public string Iso3 { get; set; }
        public int Priority { get; set; }
        public ICollection<State> States { get; set; }
    }
}
