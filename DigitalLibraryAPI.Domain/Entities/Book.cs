using DigitalLibraryAPI.Domain.Validators;
using FluentValidation;

namespace DigitalLibraryAPI.Domain.Entities
{
    public class Book
    {
        private static readonly BookValidator bookValidator = new();

        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public void ValidateAndThrow()
        {
            bookValidator.ValidateAndThrow(this);
        }
    }
}