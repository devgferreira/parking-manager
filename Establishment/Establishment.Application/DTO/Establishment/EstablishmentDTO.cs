using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Establishment.Application.DTO.Establishment
{
    public class EstablishmentDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public int NumberOfCarPlaces { get; private set; }
        public int NumberOfMotorcyclelaces { get; private set; }

        public EstablishmentDTO(int id, string name, string cnpj, string address, string phone, int numberOfCarPlaces, int numberOfMotorcyclelaces)
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
