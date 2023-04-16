#pragma warning disable SA1600

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    public readonly struct Model
    {
        public Model(string modelValue)
        {
            ModelValue = modelValue;
        }

        public string ModelValue { get; }
    }
}
