using System.Collections.Generic;
using System.Threading.Tasks;
using LocationApi.Domain.Entities;

namespace LocationApi.Data.Repository.Interface
{
    public interface ILocationRepository
    {
        Task<bool> AddAsync(Country country);
        Task<bool> CityExistsAsync(int cityId);
        Task<bool> CountryExistsAsync(int countryId);
        Task<bool> CountryStateExistsAsync(int countryId, int stateId);
        Task<int> CreateAreaAsync(int cityId, string AreaName);
        Task<bool> CreateAsync(Location location);
        Task<int> CreateEstateAsync(int cityId, string EstateName);
        Task<int> CreateStreetAsync(int cityId, string StreetName);
        Task<Location> FindLocationAsync(int countryId, int stateId, int cityId, int? areaId, int? estateId, int? streetId, string StreetNumber);
        Task<ICollection<Country>> GetAllAsync();
        Task<List<Location>> GetAllPendingLocationAsync(int? cityId, int? areaId, int? estateId, int? streetId);
        Task<ICollection<Country>> GetAllTopAsync();
        Task<City> GetAreasByIdAsync(int cityId);
        Task<State> GetCitiesByIdAsync(int stateId);
        Task<Country> GetCountryByIdAsync(int countryId);
        Task<City> GetEstatesByIdAsync(int cityId);
        Task<Location> GetLocationByIdAsync(int locationId);
        Task<Location> GetLocationByStreetAsync(string streetName, string streetNumber);
        Task<Country> GetStatesByIdAsync(int countryId);
        Task<City> GetStreeNameByIdAsync(int cityId);
        Task<bool> SaveAsync();
        Task<bool> StateCityExistsAsync(int stateId, int cityId);
        Task<bool> StateExistsAsync(int stateId);
        Task<bool> UpdateAsync(Location location);
    }
}