using Application.Guest.DTO;
using Application.Guest.Port;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Ports;

namespace Application.Guest;

public class GuestManager(IGuestRepository guestRepository) : IGuestManager
{
    private IGuestRepository _guestRepository = guestRepository;

    public async Task<GuestResponse> SaveAsync(GuestRequest request)
    {
		try
		{
            var guest = GuestDTO.MapToEntity(request);
            request.guestDTO.Id = await _guestRepository.Save(guest);

            return new GuestResponse
            {
                guestDTO = request.guestDTO,
                Success = true,
                Message = "Guest saved successfully"
            };
        }
		catch (Exception)
		{
            return new GuestResponse
            {
                Success = false,
                ErrorCode = ErrorCodes.COLD_NOT_STORE_DATA,
                Message = "Could not store guest data"
            };
        }
    }
}
