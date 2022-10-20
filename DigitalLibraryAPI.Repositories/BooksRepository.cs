using DigitalLibraryAPI.DataAccess;
using DigitalLibraryAPI.Repositories.Contracts;
using DigitalLibraryAPI.Repositories.Contracts.Mappers;
using Microsoft.EntityFrameworkCore;
using Book = DigitalLibraryAPI.Domain.Entities.Book;

namespace DigitalLibraryAPI.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly MySqlDataContext dataContext;
        private readonly IBookMapper bookMapper;

        public BooksRepository(MySqlDataContext dataContext, IBookMapper bookMapper)
        {
            this.dataContext = dataContext;
            this.bookMapper = bookMapper;
        }

        public async Task<IList<Book>> GetAll()
        {
            return await dataContext.Books.OrderBy(a => a.Title)
                .Select(book => bookMapper.GetFromDataAccess(book))
                .ToListAsync();
        }

        public async Task<Book> GetById(Guid bookId)
        {
            var book = await dataContext.Books.FirstAsync(b => b.BookId == bookId);

            return bookMapper.GetFromDataAccess(book);
        }

        public async Task Add(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            book.ValidateAndThrow();

            await dataContext.Books.AddAsync(bookMapper.GetFromDomain(book));

            await dataContext.SaveChangesAsync();
        }

        public async Task Edit(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            book.ValidateAndThrow();

            var bookToEdit = await dataContext.Books.FirstAsync(b => b.BookId == book.BookId);
            bookMapper.Update(bookToEdit, book);

            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(Guid bookId)
        {
            dataContext.Books.Remove(await dataContext.Books.FirstAsync(b => b.BookId == bookId));

            await dataContext.SaveChangesAsync();
        }
    }
}
