using Application.Models.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Models.Asset
{
    public class AddAssetPayloadValidation : AbstractValidator<AddAssetPayload>
    {
        public AddAssetPayloadValidation()
        {
            RuleFor(c => c.MacAddress).NotNull().NotEmpty().WithMessage("Mac Address must have a value").Must(ValidateMacAddress).WithMessage("Mac Address is not valid.");
        }

        private bool ValidateMacAddress(string macAddress)
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
