using System.Globalization;
using System.Windows.Controls;

namespace ProjectWeekendPuzzles.ValidationRules
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
                return ValidationResult.ValidResult;
            return string.IsNullOrWhiteSpace(value.ToString())
                ? new ValidationResult(false, "Field is required.")
                : ValidationResult.ValidResult;
        }
    }
}
