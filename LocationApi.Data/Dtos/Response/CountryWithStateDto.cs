using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Data.Dtos.Response
{
    public class CountryWithStateDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<StateDto> States { get; set; }
    }
}
