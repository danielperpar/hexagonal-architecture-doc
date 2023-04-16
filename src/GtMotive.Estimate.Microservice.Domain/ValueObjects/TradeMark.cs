#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct TradeMark
    {
        public TradeMark(string tradeMark)
        {
            TradeMarkValue = tradeMark;
        }

        public string TradeMarkValue { get; }
    }
}
