using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApi.Data.Context;
using LocationApi.Data.Repository.Interface;
using LocationApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocationApi.Data.Repository.Implementation
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;
        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            return await SaveAsync();
        }

        public async Task<ICollection<Country>> GetAllAsync()
        {
            var countries = await _context.Countries.OrderBy(x => x.CountryName).ToListAsync();
            return countries;
        }

        public async Task<ICollection<Country>> GetAllTopAsync()
        {
            var countries = await _context.Countries.Where(s => s.Priority >= 5).OrderBy(x => x.CountryName).ToListAsync();
            return countries;
        }

        public async Task<Country> GetCountryByIdAsync(int countryId)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.CountryId == countryId);
            return country;
        }

        public async Task<Country> GetStatesByIdAsync(int countryId)
        {
            var result = await _context.Countries.Include(c => c.States).Where(c => c.CountryId == countryId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<State> GetCitiesByIdAsync(int stateId)
        {
            var result = await _context.States.Include(c => c.Cities).Include(c => c.Country).Where(c => c.StateId == stateId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<City> GetAreasByIdAsync(int cityId)
        {
            var result = await _context.Cities
                                           .Include(c => c.Areas)
                                           .Include(c => c.State)
                                           .Include(c => c.Country)
                                           .Where(c => c.CityId == cityId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<City> GetEstatesByIdAsync(int cityId)
        {
            var result = await _context.Cities
                                            .Include(c => c.Estates)
                                            .Include(c => c.State)
                                            .Include(c => c.Country)
                                            .Where(c => c.CityId == cityId)
                                            .Include(s => s.Areas).FirstOrDefaultAsync();
            return result;
        }

        public async Task<City> GetStreeNameByIdAsync(int cityId)
        {
            var result = await _context.Cities
                                            .Include(c => c.Streets)
                                            .Include(c => c.State)
                                            .Include(c => c.Country)
                                            .Where(c => c.CityId == cityId)
                                            .Include(s => s.Estates)
                                            .Include(s => s.Areas).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Location> GetLocationByStreetAsync(string streetName, string streetNumber)
        {
            var result = await _context.Locations
                                                .Include(c => c.Country)
                                                .Include(c => c.State)
                                                .Include(c => c.City)
                                                .Include(c => c.Area)
                                                .Include(c => c.Estate)
                                                .Include(c => c.Street)
                                                .Where(c => c.Street.StreetName
                                                .Equals(streetName) && c.StreetNumber.Equals(streetNumber)).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Location> GetLocationByIdAsync(int locationId)
        {
            var result = await _context.Locations
                                                .Include(c => c.Country)
                                                .Include(c => c.State)
                                                .Include(c => c.City)
                                                .Include(c => c.Area)
                                                .Include(c => c.Estate)
                                                .Include(c => c.Street).Where(c => c.LocationId == locationId).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Location>> GetAllPendingLocationAsync(int? cityId, int? areaId, int? estateId, int? streetId)
        {
            var result = await _context.Locations
                                                .Include(c => c.Country)
                                                .Include(c => c.State)
                                                .Include(c => c.City)
                                                .Include(c => c.Area)
                                                .Include(c => c.Estate)
                                                .Include(c => c.Street)
                                                .Where(c => c.Status.ToLower() == "pending")
                                                .ToListAsync();


            if (cityId != null || areaId != null || estateId != null || streetId != null)
            {
                result = result.Where(c => (c.CityId == cityId ||
                                             c.AreaId == areaId ||
                                             c.EstateId == estateId ||
                                             c.StreetId == streetId))
                                             .ToList();
            }
            return result;
        }


        public async Task<bool> CreateAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(Location location)
        {
            _context.Locations.Update(location);
            return await SaveAsync();
        }

        public async Task<bool> CountryExistsAsync(int countryId)
        {
            bool result = await _context.Countries.AnyAsync(x => x.CountryId == countryId);
            return result;
        }

        public async Task<bool> StateExistsAsync(int stateId)
        {
            bool result = await _context.States.AnyAsync(x => x.StateId == stateId);
            return result;
        }

        public async Task<bool> CityExistsAsync(int cityId)
        {
            bool result = await _context.Cities.AnyAsync(x => x.CityId == cityId);
            return result;
        }

        public async Task<bool> CountryStateExistsAsync(int countryId, int stateId)
        {
            bool result = await _context.States.AnyAsync(x => x.StateId == stateId && x.CountryId == countryId);
            return result;
        }

        public async Task<bool> StateCityExistsAsync(int stateId, int cityId)
        {
            bool result = await _context.Cities.AnyAsync(x => x.CityId == cityId && x.StateId == stateId);
            return result;
        }

        public async Task<int> CreateAreaAsync(int cityId, string AreaName)
        {
            var findArea = await _context.Areas
                                            .Where(x => x.CityId == cityId && x.AreaName.ToLower() == AreaName.ToLower())
                                            .FirstOrDefaultAsync();

            if (findArea != null)
            {
                return findArea.AreaId;
            }

            var newArea = new Area
            {
                AreaName = AreaName,
                CityId = cityId
            };
            await _context.Areas.AddAsync(newArea);
            await _context.SaveChangesAsync();

            return newArea.AreaId;
        }


        public async Task<int> CreateEstateAsync(int cityId, string EstateName)
        {
            var findEstate = await _context.Estates
                                            .Where(x => x.CityId == cityId && x.EstateName.ToLower() == EstateName.ToLower())
                                            .FirstOrDefaultAsync();

            if (findEstate != null)
            {
                return findEstate.EstateId;
            }

            var newEstate = new Estate
            {
                EstateName = EstateName,
                CityId = cityId
            };
            await _context.Estates.AddAsync(newEstate);
            await _context.SaveChangesAsync();

            return newEstate.EstateId;
        }

        public async Task<int> CreateStreetAsync(int cityId, string StreetName)
        {
            var findStreet = await _context.Streets
                                            .Where(x => x.CityId == cityId && x.StreetName.ToLower() == StreetName.ToLower())
                                            .FirstOrDefaultAsync();

            if (findStreet != null)
            {
                return findStreet.StreetId;
            }

            var newStreet = new Street
            {
                StreetName = StreetName,
                CityId = cityId
            };
            await _context.Streets.AddAsync(newStreet);
            await _context.SaveChangesAsync();
            return newStreet.StreetId;
        }


        public async Task<Location> FindLocationAsync(int countryId,
                                                        int stateId,
                                                        int cityId,
                                                        int? areaId,
                                                        int? estateId,
                                                        int? streetId,
                                                        string StreetNumber)
        {
            return await _context.Locations
                                            .Where(x => x.CityId == cityId &&
                                                   x.AreaId == areaId &&
                                                   x.EstateId == estateId &&
                                                   x.StreetId == streetId &&
                                                   x.StreetNumber == StreetNumber)
                                            .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        //public bool Save()
        //{
        //    return _context.SaveChanges() >= 0;
        //}

    }
}

