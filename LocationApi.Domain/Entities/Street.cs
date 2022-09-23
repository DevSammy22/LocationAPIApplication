using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Domain.Entities
{
    public class Street
    {
        [Key]
        public int StreetId { get; set; }
        public string StreetName { get; set; }
        public bool Isverified { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
