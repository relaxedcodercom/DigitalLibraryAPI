using DigitalLibraryAPI.Domain.Entities;

namespace DigitalLibraryAPI.Repositories.Contracts.Mappers;

public interface IBookMapper
{
    Book GetFromDataAccess(DataAccess.Book book);
    DataAccess.Book GetFromDomain(Book book);
    void Update(DataAccess.Book dataAccessBook, Book book);
}