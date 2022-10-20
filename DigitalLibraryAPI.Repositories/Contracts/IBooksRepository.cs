using DigitalLibraryAPI.Domain.Entities;

namespace DigitalLibraryAPI.Repositories.Contracts;

public interface IBooksRepository
{
    Task<IList<Book>> GetAll();
    Task<Book> GetById(Guid bookId);
    Task Add(Book book);
    Task Edit(Book book);
    Task Delete(Guid bookId);
}