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

        public EstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            this.establishmentRepository = establishmentRepository;
        }

        public async Task<Result> CreateEstablishment(EstablishmentCreateOrUpdateDTO establishment)
        {
            var result = ValidateEstablishmentCreateOrUpdate(establishment);

            await establishmentRepository.CreateEstablishment(result.Value);


            return result;
        }

        public async Task<Result> DeleteEstablishment(int id)
        {
            await establishmentRepository.DeleteEstablishment(id);
            return Result.Success();
        }

        public async Task<Result> SelectEstablishment(EstablishmentRequest request)
        {

            var result = await establishmentRepository.SelectEstablishment(request);

            return Result.Success(result.Select(e => new EstablishmentDTO(e.Id, e.Cnpj.ToString(), e.Name, e.Address, e.Phone.ToString(), int.Parse(e.NumberOfCarPlaces.ToString()), int.Parse(e.NumberOfMotorcyclelaces.ToString())))); // ajsuta isso futuramente
        }

        public async Task<Result> UpdateEstablishment(int id, EstablishmentCreateOrUpdateDTO establishment)
        {
            var result = ValidateEstablishmentCreateOrUpdate(establishment);
            await establishmentRepository.UpdateEstablishment(id, result.Value);
            return result;
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
