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
    }
}
