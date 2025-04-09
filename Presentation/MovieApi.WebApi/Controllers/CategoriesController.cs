using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MoviApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MoviApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;


        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var value = _getCategoryQueryHandler.Handler();
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handler(command);
            return Ok("Kategori Ekleme İşlemi Başarılı");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(int Id)
        {
            await _removeCategoryCommandHandler.Handler(new RemoveCategoryCommand(Id));
            return Ok("Kategori Silme İşlemi Başarılı");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handler(command);
            return Ok("Kategori Güncelleme İşlemi Başarılı");
        }

        [HttpGet("GetCategory")]

        public async Task<IActionResult> GetCategory(int Id)
        {
            var value = await _getCategoryByIdQueryHandler.Handler(new GetCategoryByIdQuery(Id));
            return Ok(value);
        }
    }
}
