using Application.Guest.Requests;
using Application.Guest.Responses;

namespace Application.Guest.Port;

public interface IGuestManager
{
    Task<GuestResponse> SaveAsync(GuestRequest request);
}
