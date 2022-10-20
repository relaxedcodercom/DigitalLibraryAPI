using DigitalLibraryAPI.Domain.Entities;
using DigitalLibraryAPI.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibraryAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await booksRepository.GetAll());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await booksRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            await booksRepository.Add(book);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Book book)
        {
            await booksRepository.Edit(book);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await booksRepository.Delete(id);

            return Ok();
        }
    }
}
