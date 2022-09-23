using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Domain.Entities
{
    public class Estate
    {
        [Key]
        public int EstateId { get; set; }
        public string EstateName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
