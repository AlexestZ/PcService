using FluentValidation;
using PcService.Models.Requests;

namespace PcService.Host.Validators
{
    public class BuyerRequestValidator : AbstractValidator<BuyerRequest>
    {
        public BuyerRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Interests).NotEmpty();
            RuleFor(x => x.Budget).GreaterThan(800);
        }

    }
}
