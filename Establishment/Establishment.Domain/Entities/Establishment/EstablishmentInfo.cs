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
        public NumberOfMotorcyclelaces NumberOfMotorcyclelaces { get; private set; }

        public EstablishmentInfo(int id, string name, Cnpj cnpj, string address, Phone phone, NumberOfCarPlaces numberOfCarPlaces, NumberOfMotorcyclelaces numberOfMotorcyclelaces)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            Address = address;
            Phone = phone;
            NumberOfCarPlaces = numberOfCarPlaces;
            NumberOfMotorcyclelaces = numberOfMotorcyclelaces;
        }
    }
}
