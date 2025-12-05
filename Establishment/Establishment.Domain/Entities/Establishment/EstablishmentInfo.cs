using Establishment.Domain.Common;
using Establishment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Domain.Entities.Establishment
{
    public class EstablishmentInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public string Address { get; private set; }
        public Phone Phone { get; private set; }
        public NumberOfCarPlaces NumberOfCarPlaces { get; private set; }
        public NumberOfMotorcyclePlaces NumberOfMotorcyclelaces { get; private set; }

        public EstablishmentInfo(int id, string name, Cnpj cnpj, string address, Phone phone, NumberOfCarPlaces numberOfCarPlaces, NumberOfMotorcyclePlaces numberOfMotorcyclelaces)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            Address = address;
            Phone = phone;
            NumberOfCarPlaces = numberOfCarPlaces;
            NumberOfMotorcyclelaces = numberOfMotorcyclelaces;
        }

        public EstablishmentInfo(string name, Cnpj cnpj, string address, Phone phone, NumberOfCarPlaces numberOfCarPlaces, NumberOfMotorcyclePlaces numberOfMotorcyclelaces)
        {
            Name = name;
            Cnpj = cnpj;
            Address = address;
            Phone = phone;
            NumberOfCarPlaces = numberOfCarPlaces;
            NumberOfMotorcyclelaces = numberOfMotorcyclelaces;
        }

        public static Result<EstablishmentInfo> Create(string name, Cnpj cnpj, string address, Phone phone, NumberOfCarPlaces numberOfCarPlaces, NumberOfMotorcyclePlaces numberOfMotorcyclelaces)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<EstablishmentInfo>("Name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                return Result.Failure<EstablishmentInfo>("Address cannot be null or empty.");
            }
            return Result.Success(new EstablishmentInfo(name, cnpj, address, phone, numberOfCarPlaces, numberOfMotorcyclelaces));
        }

    }
}
