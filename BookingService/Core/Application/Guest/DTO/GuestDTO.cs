using Application.Guest.Requests;
using Domain.Enums;
using Domain.ValueObjects;
using Entities = Domain.Entities;

namespace Application.Guest.DTO;

public class GuestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public int IdTypeCode { get; set; }

    public static Entities.Guest MapToEntity(GuestRequest dto)
    {
        return new Entities.Guest
        {
            Id = dto.guestDTO.Id,
            Name = dto.guestDTO.Name,
            Surname = dto.guestDTO.Surname,
            Email = dto.guestDTO.Email,
            DocumentId = new PersonId
            {
                IdNumber = dto.guestDTO.IdNumber,
                DocumentType = (DocumentType)dto.guestDTO.IdTypeCode
            }
        };
    }
}
