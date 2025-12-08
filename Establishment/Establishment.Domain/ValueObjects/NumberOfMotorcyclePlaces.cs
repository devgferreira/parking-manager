using Establishment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Establishment.Domain.ValueObjects
{
    public sealed record NumberOfMotorcyclePlaces
    {
        private int Value { get; }
        private NumberOfMotorcyclePlaces(int value)
        {
            Value = value;
        }
        public static Result<NumberOfMotorcyclePlaces> Create(int rawNumberOfMotorcyclePlaces)
        {
            if (rawNumberOfMotorcyclePlaces < 0)
            {
                return Result.Failure<NumberOfMotorcyclePlaces>("Number of motorcycle places cannot be negative.");
            }
            return Result.Success(new NumberOfMotorcyclePlaces(rawNumberOfMotorcyclePlaces));
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
