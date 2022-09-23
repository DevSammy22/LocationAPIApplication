using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApi.Domain.Entities;

namespace LocationApi.Data.Dtos.Request
{
    public class LocationRequestDto
    {
        [Required]
        public int? CountryId { get; set; }
        [Required]
        public int? StateId { get; set; }
        [Required]
        public int? CityId { get; set; }
        public string EstateName { get; set; }
        public string AreaName { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "The street number can not be more than 10 digits")]
        public string StreetNumber { get; set; }
    }
}
