#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct TradeMark
    {
        private readonly string _tradeMark;

        public TradeMark(string tradeMark)
        {
            _tradeMark = tradeMark;
        }

        public override string ToString()
        {
            return _tradeMark;
        }
    }
}
