using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Guest;

public class GuestRepository(HotelDbContext hotelDbContext) : IGuestRepository
{
    private readonly HotelDbContext _hotelDbContext = hotelDbContext;

    public async Task<int> Save(Domain.Entities.Guest guest)
    {
        _hotelDbContext.Guests.Add(guest);
        await _hotelDbContext.SaveChangesAsync();
        return guest.Id;
    }
    public Task AddAsync(Domain.Entities.Guest guest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Guest> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Guest> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Guest> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Domain.Entities.Guest guest)
    {
        throw new NotImplementedException();
    }
}
