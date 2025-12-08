using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Application.DTO.Establishment
{
    public class EstablishmentCreateOrUpdateDTO
    {
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public int NumberOfCarPlaces { get; private set; }
        public int NumberOfMotorcyclelaces { get; private set; }
    }
}
