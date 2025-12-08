using Establishment.Application.DTO.Establishment;
using Establishment.Domain.Common;
using Establishment.Domain.Request.Establishment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Application.Interface.Establishment
{
    public interface IEstablishmentService
    {
        Task<Result> CreateEstablishment(EstablishmentCreateOrUpdateDTO establishment);
        Task<Result> UpdateEstablishment(EstablishmentCreateOrUpdateDTO establishment);
        Task<Result> DeleteEstablishment(int id);
        Task<Result> SelectEstablishment(EstablishmentRequest request);
    }
}
