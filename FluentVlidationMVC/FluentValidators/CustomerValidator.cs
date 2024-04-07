using FluentValidation;
using FluentVlidationMVC.Models;

namespace FluentVlidationMVC.FluentValidators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz...";
    public CustomerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
        RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress()
            .WithMessage("Email alanını doğru formatta olmalıdır...");
        RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60)
            .WithMessage("Age alanının değeri 18 ile 60 arasında olmalıdır...");
        RuleFor(x => x.BirthDate).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
        {
            return DateTime.Now.AddYears(-18) >= x;
        }).WithMessage("Yaşınız 18 den büyük olmalıdır...");
        RuleForEach(x => x.Addresses).SetValidator(new AddressesValidator());
        RuleFor(x => x.Gender).NotEmpty().WithMessage(NotEmptyMessage).IsInEnum().WithMessage("{PropertyName} alanı erkek için 1, kadın için 2 olmalıdır...");
    }
}
