using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Data.Dtos.Response
{
    public class CityWithStreetDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public int? EstateId { get; set; }
        public string EstateName { get; set; }
        public ICollection<StreetDto> Streets { get; set; }
    }
}
