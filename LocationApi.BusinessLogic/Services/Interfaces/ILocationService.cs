using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApi.Data.Dtos.Request;
using LocationApi.Data.Dtos.Response;

namespace LocationApi.BusinessLogic.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Response<List<CountryDto>>> GetCountriesAsync();
        Task<Response<List<CountryDto>>> GetTopCountriesAsync();
        Task<Response<CountryWithStateDto>> GetStatesByCountryIdAsync(int countryId);
        //Task<Response<StateWithCitiesDto>> GetCitiesByStateIdAsync(int stateId);
        //Task<Response<CityWithAreasDto>> GetAreasByCityIdAsync(int cityId);
        //Task<Response<CityWithEstatesDto>> GetEstatesByCityIdAsync(int cityId);
        //Task<Response<CityWithStreetDto>> GetStreetByCityIdAsync(int cityId);
        //Task<Response<LocationDto>> GetLocationBySuperIdAsync(int superId);
        //Task<Response<LocationDto>> GetLocationByStreetAsync(string streetName, string streetNumber);
        //Task<Response<List<LocationDto>>> GetAllPendingLocationAsync(int? cityId, int? areaId, int? estateId, int? streetId);
        //Task<Response<LocationDto>> ApproveALocationAsync(int superId, ApproveLocationRequestDto model);
        //Task<Response<LocationDto>> CreateLocationAsync(LocationDto locationDto);
        Task<Response<CountryDto>> GetCountryByCountryIdAsync(int countryId);
    }
}
