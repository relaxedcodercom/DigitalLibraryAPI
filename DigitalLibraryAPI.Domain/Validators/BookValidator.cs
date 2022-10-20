using DigitalLibraryAPI.Domain.Entities;
using FluentValidation;

namespace DigitalLibraryAPI.Domain.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Title)
            .NotEmpty()
            .Length(1, 200);
            RuleFor(b => b.Author)
            .Length(0, 200);
        }
    }
}