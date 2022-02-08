using FluentValidation;
using PcService.Models.DTO;
using PcService.Models.Requests;

namespace PcService.Host.Validators
{
    public class LaptopRequestValidator : AbstractValidator<LaptopRequest>
    {
        public LaptopRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Weight).GreaterThan(1);
            RuleFor(x => x.RatingPricePerformance).IsInEnum();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(800).LessThanOrEqualTo(2750);
        }
    }
}
