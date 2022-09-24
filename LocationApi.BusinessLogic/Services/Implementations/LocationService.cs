using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LocationApi.BusinessLogic.Services.Interfaces;
using LocationApi.Data.Dtos.Request;
using LocationApi.Data.Dtos.Response;
using LocationApi.Data.Repository.Interface;
using LocationApi.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace LocationApi.BusinessLogic.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;

        public LocationService(IMapper mapper, ILocationRepository locationRepository)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        public async Task<Response<List<CountryDto>>> GetCountriesAsync()
        {
            var countries = await _locationRepository.GetAllAsync();

            var result = _mapper.Map<List<CountryDto>>(countries);
            return new Response<List<CountryDto>>()
            {
                Data = result,
                Successful = true,
                Code = StatusCodes.Status200OK.ToString()
            };
        }

        public async Task<Response<List<CountryDto>>> GetTopCountriesAsync()
        {
            var countries = await _locationRepository.GetAllTopAsync();

            var result = _mapper.Map<List<CountryDto>>(countries);
            return new Response<List<CountryDto>>()
            {
                Data = result,
                Successful = true,
                Code = StatusCodes.Status200OK.ToString()
            };
        }

        public async Task<Response<CountryDto>> GetCountryByCountryIdAsync(int countryId)
        {
            var country = await _locationRepository.GetCountryByIdAsync(countryId);
            if (country != null)
            {
                var result = _mapper.Map<CountryDto>(country);
                return new Response<CountryDto>()
                {
                    Data = result,
                    Successful = true,
                    Code = StatusCodes.Status200OK.ToString()
                };
            }
            return new Response<CountryDto>()
            {
                Code = StatusCodes.Status404NotFound.ToString(),
                Data = null,
                Successful = false,
                Message = $"Country with {countryId} Not Found"
            };
        }

        public async Task<Response<CountryWithStateDto>> GetStatesByCountryIdAsync(int countryId)
        {
            var country = await _locationRepository.GetStatesByIdAsync(countryId);
            if (country != null)
            {
                return new Response<CountryWithStateDto>()
                {
                    Successful = true,
                    Code = StatusCodes.Status200OK.ToString(),
                    Data = new CountryWithStateDto()
                    {
                        CountryId = country.CountryId,
                        CountryName = country.CountryName,
                        States = country.States.Select(x =>
                        new StateDto
                        {
                            StateId = x.StateId,
                            StateName = x.StateName
                        }).ToList(),
                    }
                };
            }
            return new Response<CountryWithStateDto>()
            {
                Code = StatusCodes.Status404NotFound.ToString(),
                Data = null,
                Successful = false,
                Message = $"Country with {countryId} Not Found"
            };

        }

        //public async Task<Response<StateWithCitiesDto>> GetCitiesByStateIdAsync(int stateId)
        //{
        //    var state = await _locationRepository.GetCitiesByIdAsync(stateId);
        //    if (state != null)
        //    {
        //        return new Response<StateWithCitiesDto>()
        //        {
        //            Successful = true,
        //            Code = StatusCodes.Status200OK.ToString(),
        //            Data = new StateWithCitiesDto()
        //            {
        //                CountryId = state.CountryId,
        //                Country = state.Country.CountryName,
        //                StateId = state.StateId,
        //                StateName = state.StateName,
        //                Cities = state.Cities.Select(x =>
        //                new CityDto
        //                {
        //                    CityId = x.CityId,
        //                    CityName = x.CityName
        //                }).ToList(),
        //            }
        //        };
        //    }
        //    return new Response<StateWithCitiesDto>()
        //    {
        //        Code = StatusCodes.Status404NotFound.ToString(),
        //        Data = null,
        //        Successful = false,
        //        Message = $"Country with {stateId} Not Found"
        //    };
        //}

        //public async Task<Response<CityWithAreasDto>> GetAreasByCityIdAsync(int cityId)
        //{
        //    var city = await _locationRepository.GetAreasByIdAsync(cityId);
        //    if (city != null)
        //    {
        //        return new Response<CityWithAreasDto>()
        //        {
        //            Successful = true,
        //            Code = StatusCodes.Status200OK.ToString(),
        //            Data = new CityWithAreasDto()
        //            {
        //                CountryId = city.CountryId,
        //                Country = city.Country.Name,
        //                StateId = city.StateId,
        //                State = city.State.Name,
        //                CityId = city.Id,
        //                City = city.Name,
        //                Areas = city.Areas.Select(x =>
        //                new AreaDto
        //                {
        //                    AreaId = x.Id,
        //                    Area = x.Name
        //                }).ToList(),
        //            }
        //        };
        //    }
        //    return new Response<CityWithAreasDto>()
        //    {
        //        Code = StatusCodes.Status404NotFound.ToString(),
        //        Data = null,
        //        Successful = false,
        //        Message = $"Country with {cityId} Not Found"
        //    };
        //}

        //public async Task<Response<CityWithEstatesDto>> GetEstatesByCityIdAsync(int cityId)
        //{
        //    var city = await _locationRepository.GetEstatesByIdAsync(cityId);
        //    if (city != null)
        //    {
        //        return new Response<CityWithEstatesDto>()
        //        {
        //            Successful = true,
        //            Code = StatusCodes.Status200OK.ToString(),
        //            Data = new CityWithEstatesDto()
        //            {
        //                CountryId = city.CountryId,
        //                Country = city.Country.Name,
        //                StateId = city.StateId,
        //                State = city.State.Name,
        //                CityId = city.Id,
        //                City = city.Name,
        //                AreaId = city.Areas != null ? city.Areas.FirstOrDefault().Id : null,
        //                Area = city.Areas != null ? city.Areas.FirstOrDefault().Name : "No Area",
        //                Estates = city.Estates.Select(x =>
        //                new EstateDto
        //                {
        //                    EstateId = x.Id,
        //                    Estate = x.Name
        //                }).ToList(),
        //            }
        //        };
        //    }
        //    return new Response<CityWithEstatesDto>()
        //    {
        //        Code = StatusCodes.Status404NotFound.ToString(),
        //        Data = null,
        //        Successful = false,
        //        Message = $"Country with {cityId} Not Found"
        //    };
        //}

        //public async Task<Response<CityWithStreetDto>> GetStreetByCityIdAsync(int cityId)
        //{
        //    var city = await _locationRepository.GetStreeNameByIdAsync(cityId);
        //    if (city != null)
        //    {
        //        return new Response<CityWithStreetDto>()
        //        {
        //            Successful = true,
        //            Code = StatusCodes.Status200OK.ToString(),
        //            Data = new CityWithStreetDto()
        //            {
        //                CountryId = city.CountryId,
        //                Country = city.Country.Name,
        //                StateId = city.StateId,
        //                State = city.State.Name,
        //                CityId = city.Id,
        //                City = city.Name,
        //                AreaId = city.Areas != null ? city.Areas.FirstOrDefault().Id : null,
        //                Area = city.Areas != null ? city.Areas.FirstOrDefault().Name : "No Area",
        //                EstateId = city.Estates != null ? city.Estates.FirstOrDefault().Id : null,
        //                Estate = city.Estates != null ? city.Estates.FirstOrDefault().Name : "No Esate",
        //                StreetName = city.Streets.Select(x =>
        //                new StreetDto
        //                {
        //                    StreetId = x.Id,
        //                    Street = x.Name
        //                }).ToList(),
        //            }
        //        };
        //    }
        //    return new Response<CityWithStreetDto>()
        //    {
        //        Code = StatusCodes.Status404NotFound.ToString(),
        //        Data = null,
        //        Successful = false,
        //        Message = $"Country with {cityId} Not Found"
        //    };
        //}

        //public async Task<Response<LocationResponseDto>> GetLocationBySuperIdAsync(int superId)
        //{
        //    var location = await _locationRepository.GetLocationByIdAsync(superId);
        //    if (location != null)
        //    {
        //        return new Response<LocationResponseDto>()
        //        {
        //            Successful = true,
        //            Code = StatusCodes.Status200OK.ToString(),
        //            Data = new LocationResponseDto()
        //            {
        //                SuperId = location.Id,
        //                Country = location.Country.Name,
        //                State = location.State.Name,
        //                City = location.City.Name,
        //                Area = location.Area != null ? location.Area.Name : "No Area",
        //                Estate = location.Estate != null ? location.Estate.Name : "No Estate",
        //                StreetId = location.Street != null ? location.StreetId : null,
        //                Street = location.Street != null ? location.Street.Name : "No Street",
        //                StreetNumber = location.StreetNumber != null ? location.StreetNumber : "No Street Number",
        //                Status = location.Status
        //            }
        //        };
        //    }
        //    return new Response<LocationResponseDto>()
        //    {
        //        Code = StatusCodes.Status404NotFound.ToString(),
        //        Data = null,
        //        Successful = false,
        //        Message = $"Country with {superId} Not Found"
        //    };
        //}

        //public async Task<Response<LocationResponseDto>> GetLocationByStreetAsync(string streetName, string streetNumber)
        //{
        //    var location = await _locationRepository.GetLocationByStreetAsync(streetName, streetNumber);
        //    if (location != null)
        //    {
        //        return new Response<LocationResponseDto>()
        //        {
        //            Successful = true,
        //            Code = StatusCodes.Status200OK.ToString(),
        //            Data = new LocationResponseDto()
        //            {
        //                SuperId = location.Id,
        //                Country = location.Country.Name,
        //                State = location.State.Name,
        //                City = location.City.Name,
        //                Area = location.Area != null ? location.Area.Name : "No Area",
        //                Estate = location.Estate != null ? location.Estate.Name : "No Estate",
        //                StreetId = location.Street != null ? location.StreetId : null,
        //                Street = location.Street != null ? location.Street.Name : "No Street",
        //                StreetNumber = location.StreetNumber != null ? location.StreetNumber : "No Street Number",
        //            }
        //        };
        //    }

        //    return new Response<LocationResponseDto>()
        //    {
        //        Code = StatusCodes.Status404NotFound.ToString(),
        //        Data = null,
        //        Successful = false,
        //        Message = "Location with" + streetNumber + " and " + streetName + " Not Found"
        //    };
        //}


        //public async Task<Response<List<LocationResponseDto>>> GetAllPendingLocationAsync(int? cityId, int? areaId, int? estateId, int? streetId)
        //{
        //    var location = await _locationRepository.GetAllPendingLocationAsync(cityId, areaId, estateId, streetId);
        //    if (location != null)
        //    {
        //        return new Response<List<LocationResponseDto>>()
        //        {
        //            Successful = true,
        //            Code = StatusCodes.Status200OK.ToString(),
        //            Data = location.Select(s => new LocationResponseDto()
        //            {
        //                SuperId = s.Id,
        //                Country = s.Country.Name,
        //                State = s.State.Name,
        //                City = s.City.Name,
        //                Area = s.Area != null ? s.Area.Name : "No Area",
        //                Estate = s.Estate != null ? s.Estate.Name : "No estate",
        //                StreetId = s.Street != null ? s.StreetId : null,
        //                Street = s.Street != null ? s.Street.Name : "No Street",
        //                StreetNumber = s.StreetNumber != null ? s.StreetNumber : "No Street Number",
        //                Status = s.Status
        //            }).ToList()
        //        };
        //    }
        //    return new Response<List<LocationResponseDto>>()
        //    {
        //        Code = StatusCodes.Status404NotFound.ToString(),
        //        Data = null,
        //        Successful = false,
        //        Message = $"Location with {cityId}, {areaId}, {estateId}, {estateId} and {streetId} Not Found"
        //    };
        //}

        //public async Task<Response<LocationResponseDto>> CreateLocationAsync(LocationDto locationDto)
        //{
        //    if (!await _locationRepository.CountryExistsAsync(locationDto.CountryId))
        //    {
        //        throw new ArgumentException("Country not found");
        //    }
        //    if (!await _locationRepository.StateExistsAsync(locationDto.StateId))
        //    {
        //        throw new ArgumentException("State not found");
        //    }
        //    if (!await _locationRepository.CityExistsAsync(locationDto.CityId))
        //    {
        //        throw new ArgumentException("City not found");
        //    }
        //    if (!await _locationRepository.CountryStateExistsAsync(locationDto.CountryId, locationDto.StateId))
        //    {
        //        throw new ArgumentException("State doesn't exist in the country");
        //    }
        //    if (!await _locationRepository.StateCityExistsAsync(locationDto.StateId, locationDto.CityId))
        //    {
        //        throw new ArgumentException("City doesn't exist in the state");
        //    }

        //    int? AreaId = null;
        //    int? EstateId = null;
        //    int? StreetId = null;
        //    if (!String.IsNullOrEmpty(locationDto.AreaName))
        //    {
        //        AreaId = await _locationRepository.CreateAreaAsync(locationDto.CityId, locationDto.AreaName);
        //    }

        //    if (!String.IsNullOrEmpty(locationDto.EstateName))
        //    {
        //        EstateId = await _locationRepository.CreateEstateAsync(locationDto.CityId, locationDto.EstateName);
        //    }

        //    if (!String.IsNullOrEmpty(locationDto.StreetName))
        //    {
        //        StreetId = await _locationRepository.CreateStreetAsync(locationDto.CityId, locationDto.StreetName);
        //    }

        //    var findLocation = await _locationRepository.FindLocationAsync(locationDto.CountryId, locationDto.StateId, locationDto.CityId, AreaId, EstateId, StreetId, locationDto.StreetNumber);

        //    if (findLocation != null)
        //    {
        //        return new Response<LocationResponseDto>()
        //        {
        //            Code = StatusCodes.Status409Conflict.ToString(),
        //            Data = null,
        //            Successful = false,
        //            Message = $"Location already exist"
        //        };
        //    }

        //    var newLocation = new Location1
        //    {
        //        CountryId = locationDto.CountryId,
        //        StateId = locationDto.StateId,
        //        CityId = locationDto.CityId,
        //        AreaId = AreaId,
        //        EstateId = EstateId,
        //        StreetId = StreetId,
        //        Status = "Pending",
        //        StreetNumber = locationDto.StreetNumber
        //    };
        //    await _locationRepository.CreateAsync(newLocation);

        //    var location = await _locationRepository.GetLocationByIdAsync(newLocation.Id);

        //    return new Response<LocationResponseDto>()
        //    {
        //        Successful = true,
        //        Code = StatusCodes.Status200OK.ToString(),
        //        Data = new LocationResponseDto()
        //        {
        //            SuperId = location.Id,
        //            Country = location.Country.Name,
        //            State = location.State.Name,
        //            City = location.City.Name,
        //            Area = location.Area != null ? location.Area.Name : "No Area",
        //            Estate = location.Estate != null ? location.Estate.Name : "No Estate",
        //            StreetId = location.Street != null ? location.StreetId : null,
        //            Street = location.Street != null ? location.Street.Name : "No Street",
        //            StreetNumber = location.StreetNumber != null ? location.StreetNumber : "No Street Number",
        //            Status = location.Status
        //        }
        //    };
        //}


        //public async Task<Response<LocationResponseDto>> ApproveALocationAsync(int superId, ApproveLocationRequestDto model)
        //{
        //    Location1 location = null;

        //    location = await _locationRepository.GetLocationByIdAsync(superId);
        //    if (location != null)
        //    {
        //        if (model.Approve)
        //        {
        //            location.Status = "Approved";
        //        }
        //        if (!model.Approve)
        //        {
        //            location.Status = "Pending";
        //        }
        //        _locationRepository.UpdateAsync(location);

        //        location = await _locationRepository.GetLocationByIdAsync(superId);

        //        return new Response<LocationResponseDto>()
        //        {
        //            Successful = true,
        //            Code = StatusCodes.Status200OK.ToString(),
        //            Data = new LocationResponseDto()
        //            {
        //                SuperId = location.Id,
        //                Country = location.Country.Name,
        //                State = location.State.Name,
        //                City = location.City.Name,
        //                Area = location.Area != null ? location.Area.Name : "No Area",
        //                Estate = location.Estate != null ? location.Estate.Name : "No Estate",
        //                StreetId = location.Street != null ? location.StreetId : null,
        //                Street = location.Street != null ? location.Street.Name : "No Street",
        //                StreetNumber = location.StreetNumber != null ? location.StreetNumber : "No Street Number",
        //                Status = location.Status
        //            }
        //        };
        //    }
        //    return new Response<LocationResponseDto>()
        //    {
        //        Code = StatusCodes.Status404NotFound.ToString(),
        //        Data = null,
        //        Successful = false,
        //        Message = $"Location with {superId} Not Found"
        //    };
        //}


    }
}
