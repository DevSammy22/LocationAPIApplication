using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Domain.Entities
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public Country Country { get; set; }
        public int? CountryId { get; set; }
        public State State { get; set; }
        public int? StateId { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
        public Estate Estate { get; set; }
        public int? EstateId { get; set; }
        public Area Area { get; set; }
        public int? AreaId { get; set; }
        public Street Street { get; set; }
        public int? StreetId { get; set; }
        public string StreetNumber { get; set; }
        public string Status { get; set; }
    }
}
