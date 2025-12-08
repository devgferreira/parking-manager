using Establishment.Application.DTO.Establishment;
using Establishment.Application.Interface.Establishment;
using Establishment.Domain.Common;
using Establishment.Domain.Entities.Establishment;
using Establishment.Domain.Interface.Establishment;
using Establishment.Domain.Request.Establishment;
using Establishment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Application.Service.Establishment
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IEstablishmentRepository establishmentRepository;



        public async Task<Result> CreateEstablishment(EstablishmentCreateOrUpdateDTO establishment)
        {
            var result = ValidateEstablishmentCreateOrUpdate(establishment);

            await establishmentRepository.CreateEstablishment(result.Value);


            return result;
        }

        public Task<Result> DeleteEstablishment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> SelectEstablishment(EstablishmentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateEstablishment(EstablishmentCreateOrUpdateDTO establishment)
        {
            throw new NotImplementedException();
        }


        private Result<EstablishmentInfo> ValidateEstablishmentCreateOrUpdate(EstablishmentCreateOrUpdateDTO dto)
        {
            var cnpjResult = Cnpj.Create(dto.Cnpj);
            if (cnpjResult.IsFailure)
                return Result.Failure<EstablishmentInfo>(cnpjResult.Error);

            var phoneResult = Phone.Create(dto.Phone);
            if (phoneResult.IsFailure)
                return Result.Failure<EstablishmentInfo>(phoneResult.Error);

            var carPlacesResult = NumberOfCarPlaces.Create(dto.NumberOfCarPlaces);
            if (carPlacesResult.IsFailure)
                return Result.Failure<EstablishmentInfo>(carPlacesResult.Error);

            var motoPlacesResult = NumberOfMotorcyclePlaces.Create(dto.NumberOfMotorcyclePlaces);
            if (motoPlacesResult.IsFailure)
                return Result.Failure<EstablishmentInfo>(motoPlacesResult.Error);

            var establishmentInfoResult = EstablishmentInfo.Create(
                dto.Name,
                cnpjResult.Value,
                dto.Address,
                phoneResult.Value,
                carPlacesResult.Value,
                motoPlacesResult.Value
            );

            if (establishmentInfoResult.IsFailure)
                return Result.Failure<EstablishmentInfo>(establishmentInfoResult.Error);

            return establishmentInfoResult; 
        }

    }
}
