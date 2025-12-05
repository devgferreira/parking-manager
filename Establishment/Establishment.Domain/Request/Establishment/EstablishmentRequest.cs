using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Domain.Request.Establishment
{
    public class EstablishmentRequest
    {
        public int? Id { get; private set; }
        public string? Name { get; private set; }
        public string? Cnpj { get; private set; }
        public string? Phone { get; private set; }
    }
}
