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
            if (string.IsNullOrWhiteSpace(rawCnpj))
            {
                return Result.Failure<Cnpj>("CNPJ cannot be null or empty.");
            }
            var digitsOnlyCnpj = new string(rawCnpj.Where(char.IsDigit).ToArray());

            if (digitsOnlyCnpj.Length != 14)
            {
                return Result.Failure<Cnpj>("CNPJ must have exactly 14 digits.");
            }

            if (Enumerable.Range(0, 10).Any(d => digitsOnlyCnpj == new string((char)('0' + d), 14)))
                return Result.Failure<Cnpj>("CNPJ cannot have identical numbers.");

            int[] mult1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum = 0;
            for (int i = 0; i < 12; i++)
                sum += (digitsOnlyCnpj[i] - '0') * mult1[i];

            int remains = sum % 11;
            int digit1 = remains < 2 ? 0 : 11 - remains;

            if ((digitsOnlyCnpj[12] - '0') != digit1)
                return Result.Failure<Cnpj>("CNPJ invalid."); ;

            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += (digitsOnlyCnpj[i] - '0') * mult2[i];

            remains = sum % 11;
            int digit2 = remains < 2 ? 0 : 11 - remains;

            if ((digitsOnlyCnpj[13] - '0') != digit2)
                return Result.Failure<Cnpj>("CNPJ invalid.");

            return Result.Success(new Cnpj(digitsOnlyCnpj));
        }

    }
}
