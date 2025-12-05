using Establishment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Domain.ValueObjects
{
    public sealed record Phone
    {
        private string Value { get; }

        private Phone(string value)
        {
            Value = value;
        }

        public static Result<Phone> Create(string rawPhone)
        {
            if (string.IsNullOrWhiteSpace(rawPhone))
            {
                return Result.Failure<Phone>("Phone number cannot be null or empty.");
            }
            var digitsOnlyPhone = new string(rawPhone.Where(char.IsDigit).ToArray());
            if (digitsOnlyPhone.Length < 10 || digitsOnlyPhone.Length > 11)
            {
                return Result.Failure<Phone>("Phone number must have 10 or 11 digits.");
            }
            return Result.Success(new Phone(digitsOnlyPhone));
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
