#pragma warning disable SA1600 // Elements should be documented

using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos.Attributes
{
    [AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]

    public sealed class NotEmptyAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";

        public NotEmptyAttribute()
            : base(DefaultErrorMessage)
        {
        }

        public override bool IsValid(object value)
        {
#pragma warning disable IDE0046 // Convert to conditional expression
            if (value is null)
            {
                return true;
            }
#pragma warning restore IDE0046 // Convert to conditional expression

            return value switch
            {
                Guid guid => guid != Guid.Empty,
                _ => true,
            };
        }
    }
}
