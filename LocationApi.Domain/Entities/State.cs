using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Domain.Entities
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
