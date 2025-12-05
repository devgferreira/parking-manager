using Establishment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Domain.ValueObjects
{
    public sealed record Cnpj
    {
        private Cnpj(string value)
        {
            Value = value;
        }
        private string Value { get; }

        public static Result<Cnpj> Create(string rawCnpj)
        {
            if(string.IsNullOrWhiteSpace(rawCnpj))
            {
                return Result.Failure<Cnpj>("CNPJ cannot be null or empty.");
            }
            var digitsOnlyCnpj = new string(rawCnpj.Where(char.IsDigit).ToArray());

            if(digitsOnlyCnpj.Length != 14)
            {
                return Result.Failure<Cnpj>("CNPJ must have exactly 14 digits.");
            }

            return Result.Success(new Cnpj(digitsOnlyCnpj));
        }

    }
}
