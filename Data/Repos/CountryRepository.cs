using System.Collections.Generic;
using System.Linq;
using BlogApi.Data.Interfaces;
using BlogApi.Models;


namespace BlogApi.Data.Repos
{
  public class CountryRepository : ICountryRepository
  {
    private readonly DataContext _context;

    public CountryRepository(DataContext context)
    {
      _context = context;
    }

    public bool CountryExists(int countryId)
    {
      return _context.Countries.Any(c => c.Id == countryId);
    }

    public ICollection<Country> GetCountries()
    {
      return _context.Countries.OrderBy(c => c.Name).ToList();
    }

    public Country GetCountry(int countryId)
    {
      return _context.Countries.Where(c => c.Id == countryId).FirstOrDefault();
    }

    public Country GetCountryOfAUser(int userId)
    {
      return _context.Users.Where(u => u.Id == userId).Select(c => c.Country).FirstOrDefault();
    }

    public ICollection<User> GetUsersFromACountry(int countryId)
    {
      return _context.Users.Where(a => a.Country.Id == countryId).ToList();
    }
  }
}