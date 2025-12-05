using Establishment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Establishment.Domain.ValueObjects
{
    public sealed record NumberOfCarPlaces
    {
        private int Value { get; }
        private NumberOfCarPlaces(int value)
        {
            Value = value;
        }
        public static Result<NumberOfCarPlaces> Create(int rawNumberOfCarSeats)
        {
            if (rawNumberOfCarSeats < 0)
            {
                return Result.Failure<NumberOfCarPlaces>("Number of car seats cannot be negative.");
            }
            return Result.Success(new NumberOfCarPlaces(rawNumberOfCarSeats));
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
