using Establishment.Domain.Entities.Establishment;
using Establishment.Domain.Request.Establishment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Domain.Interface.Establishment
{
    public interface IEstablishmentRepository
    {
        Task<int> CreateEstablishment(EstablishmentInfo establishment);
        Task UpdateEstablishment(int id, EstablishmentInfo establishment);
        Task DeleteEstablishment(int id);
        Task<List<EstablishmentInfo>> SelectEstablishment(EstablishmentRequest request);

    }
}
