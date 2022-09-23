using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApi.Domain.Entities;

namespace LocationApi.Data.Dtos.Response
{
    public class StateWithCitiesDto
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public ICollection<CityDto> Cities { get; set; }
    }
}
