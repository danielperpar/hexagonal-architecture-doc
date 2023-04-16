#pragma warning disable SA1600

using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct TradeMark
    {
        public TradeMark(string tradeMark)
        {
            if (string.IsNullOrWhiteSpace(tradeMark))
            {
                throw new DomainException("TradeMark cannot be empty");
            }

            TradeMarkValue = tradeMark.Trim().ToUpperInvariant();
        }

        public string TradeMarkValue { get; }

        public static TradeMark Create(string input)
        {
            return new TradeMark(input);
        }
    }
}
