using Domain.Entities;

namespace Domain.Ports;

public interface IGuestRepository
{
    Task<Guest> GetAsync(int id);
    Task<Guest> GetByIdAsync(int id);
    Task<Guest> GetByEmailAsync(string email);
    Task AddAsync(Guest guest);
    Task UpdateAsync(Guest guest);
    Task DeleteAsync(int id);
    Task<int> Save(Guest guest);
}
