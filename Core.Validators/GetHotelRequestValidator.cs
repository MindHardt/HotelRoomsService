using Core.Requests;
using FluentValidation;

namespace Core.Validators;

public class GetHotelRequestValidator : AbstractValidator<GetHotelRequest>
{
    public GetHotelRequestValidator()
    {
        RuleFor(x => x.Address).NotNull().When(x => x.Id is null);
        RuleFor(x => x.Id).NotNull().When(x => x.Address is null);
    }
}