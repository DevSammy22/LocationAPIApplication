using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Domain.Entities
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
