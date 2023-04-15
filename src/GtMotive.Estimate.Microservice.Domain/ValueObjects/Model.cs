#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct Model
    {
        private readonly string _model;

        public Model(string model)
        {
            _model = model;
        }

        public override string ToString()
        {
            return _model;
        }
    }
}
