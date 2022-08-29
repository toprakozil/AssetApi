using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Models.Asset
{
    public class UpdateAssetPayloadValidation : AbstractValidator<UpdateAssetPayload>
    {
        public UpdateAssetPayloadValidation()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().WithMessage("Asset Id must have a value");
            When(c => c.StatusId != null, () =>
            {
                RuleFor(c => c.StatusId).InclusiveBetween(1,4).WithMessage("Status is not valid. Status Id must be inclusive between 1 and 4");
            });
            When(c => !string.IsNullOrEmpty(c.MacAddress), () =>
            {
                RuleFor(c => c.MacAddress).Must(ValidateMacAddress).WithMessage("Mac Address is not valid.");
            });
        }
        private bool ValidateMacAddress(string? macAddress)
        {         
            macAddress = macAddress.Replace(" ", "").Replace(":", "").Replace("-", "");
            Regex r = new Regex("^[a-fA-F0-9]{12}$");
            if (r.IsMatch(macAddress))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
