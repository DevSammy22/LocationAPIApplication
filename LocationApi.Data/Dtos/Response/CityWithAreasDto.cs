using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApi.Domain.Entities;

namespace LocationApi.Data.Dtos.Response
{
    public class CityWithAreasDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public ICollection<AreaDto> Areas { get; set; }
    }
}
