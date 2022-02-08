using FluentValidation;
using PcService.Models.Requests;

namespace PcService.Host.Validators
{
    public class PersonalComputerRequestValidator : AbstractValidator<PersonalComputerRequest>
    {
        public PersonalComputerRequestValidator()
        {
            RuleFor(x =>x.Name).NotEmpty();
            RuleFor(x => x.RatingPricePerformance).IsInEnum();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(900).LessThanOrEqualTo(2900);
        }
    }
}
