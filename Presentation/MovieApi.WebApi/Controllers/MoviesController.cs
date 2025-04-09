using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MoviApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MoviApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MoviApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handler();
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handler(command);
            return Ok("Film Ekleme İşlemi Başarılı");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteMovie(int Id)
        {
            await _removeMovieCommandHandler.Handler(new RemoveMovieCommand(Id));
            return Ok("Film Silme İşlemi Başarılı");
        }

        [HttpGet("GetMovie")]

        public async Task<IActionResult> GetMovie(int Id)
        {
            var value = await _getMovieByIdQueryHandler.Handler(new GetMovieByIdQuery(Id));
            return Ok(value);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handler(command);
            return Ok("Film Güncelleme İşlemi Başarılı");
        }
    }
}
