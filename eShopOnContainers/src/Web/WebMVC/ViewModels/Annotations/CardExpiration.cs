namespace Microsoft.eShopOnContainers.WebMVC.ViewModels.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class CardExpirationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string monthString = value.ToString().Split('/')[0];
            var yearString = $"20{value.ToString().Split('/')[1]}";
            // Use the 'out' variable initializer to simplify 
            // the logic of validating the expiration date
            if (int.TryParse(monthString, out int month) &&
                int.TryParse(yearString, out int year))
            {
                var d = new DateTime(year, month, 1);

                return d > DateTime.UtcNow;
            }
            return false;
        }
    }
}
