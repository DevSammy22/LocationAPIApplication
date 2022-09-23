using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApi.Domain.Entities;

namespace LocationApi.Data.Dtos.Response
{
    public class LocationDto
    {
        public int LocationId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Estate { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public int? StreetId { get; set; }
        public string StreetNumber { get; set; }
        public string Status { get; set; }
    }
}
