using Microsoft.AspNetCore.Mvc;

using API.Controllers.Contract;

using Application.Handlers;
using Application.Dictionary;

namespace API.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class BooksController : BaseController
    {
        public BooksController(DefaultDictionary defaultDictionary) : base(defaultDictionary) { }

        [HttpPost]
        public async Task<IActionResult> CheckIfExist([FromBody] string nameBook, [FromServices] BooksHandler handler)
        {
            var handle = await handler.HandleChecker(nameBook);

            return Ok(handle);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromServices] BooksHandler handler)
        {
            var handle = await handler.Handle();

            return Ok(handle);
        }

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] string nameBook, [FromServices] BooksHandler handler)
        {
            var handle = await handler.Handle(nameBook);

            return Ok(handle);
        }

        [HttpPut] //TESTE
        public async Task<IActionResult> UpdateBook([FromBody] string nameBook, [FromServices] BooksHandler handler)
        {
            var handle = await handler.HandlePut(nameBook);

            return Ok(handle);
        }

        [HttpDelete] //Alterar para PUT, pois deve atualizar o estado do livro para "Desativado"
        public async Task<IActionResult> RemoveBook([FromBody] string nameBook, [FromServices] BooksHandler handler)
        {
            var handle = await handler.HandleRemove(nameBook);

            return Ok(handle);
        }
    }
}