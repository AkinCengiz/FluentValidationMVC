using FluentValidation;
using FluentVlidationMVC.Models;

namespace FluentVlidationMVC.FluentValidators;

public class AddressesValidator : AbstractValidator<Address>
{
    public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz...";
    public AddressesValidator()
    {
        RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);
        RuleFor(x => x.PostalCode).NotEmpty().WithMessage(NotEmptyMessage).Length(5).WithMessage("{PropertyName} alanı 5 kaakter olmalıdır...");
        RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMessage);
    }
}
