using System.ComponentModel.DataAnnotations;

namespace DijkstraImplementation.Utility
{
    public class ArrivalTimeVsDepartureTime: ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public ArrivalTimeVsDepartureTime(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value is not DateTime ArrivalTime)
            {
                return new ValidationResult("Invalid time format");
            }

            var departureProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (departureProperty is null)
            {
                return new ValidationResult($"Unknown property: {_comparisonProperty}");
            }

            var departureTime = (DateTime?)departureProperty.GetValue(validationContext.ObjectInstance);
            if (departureTime.HasValue && ArrivalTime <= departureTime.Value)
            {
                return new ValidationResult("Arrival time must be after departure time!");
            }

            return ValidationResult.Success!;
;
        }
    }
}
