using System.Collections.Generic;
using BlogApi.Models;

namespace BlogApi.Data.Interfaces
{
  public interface ICountryRepository
  {
    ICollection<Country> GetCountries();
    Country GetCountry(int countryId);
    Country GetCountryOfAUser(int userId);
    ICollection<User> GetUsersFromACountry(int countryId);
    bool CountryExists(int countryId);
  }
}