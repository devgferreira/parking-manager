using Establishment.Application.DTO.Establishment;
using Establishment.Domain.Request.Establishment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Application.Interface.Establishment
{
    public interface IEstablishmentService
    {
        Task CreateEstablishment(EstablishmentCreateOrUpdateDTO establishment);
        Task UpdateEstablishment(EstablishmentCreateOrUpdateDTO establishment);
        Task DeleteEstablishment(int id);
        Task<List<EstablishmentDTO>> SelectEstablishment(EstablishmentRequest request);
    }
}
