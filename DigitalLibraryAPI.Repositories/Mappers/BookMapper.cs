using DigitalLibraryAPI.Domain.Entities;
using DigitalLibraryAPI.Repositories.Contracts.Mappers;

namespace DigitalLibraryAPI.Repositories.Mappers
{
    public class BookMapper : IBookMapper
    {
        public Book GetFromDataAccess(DataAccess.Book book)
        {
            return new Book
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description
            };
        }

        public DataAccess.Book GetFromDomain(Book book)
        {
            return new DataAccess.Book
            {
                BookId = Guid.NewGuid(),
                Title = book.Title,
                Author = book.Author,
                Description = book.Description
            };
        }

        public void Update(DataAccess.Book dataAccessBook, Book book)
        {
            dataAccessBook.Title = book.Title;
            dataAccessBook.Author = book.Author;
            dataAccessBook.Description = book.Description;
        }
    }
}
