using CulinaryRecipes.Api.Models;
using CulinaryRecipes.Aplication.Queries;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryRecipes.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IMediator _mediator;

        public RecipeController(ILogger<RecipeController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetRecipe")]
        public async Task<IEnumerable<RecipeModel>> Get([FromQuery] QueryModel query)
        {
            var client = _mediator.CreateRequestClient<IGetRecipeQuery>();
            Response<IEnumerable<RecipeModel>> response = await client.GetResponse<IEnumerable<RecipeModel>>(new { Query = query.Query, Page = query.Page, PageSize = query.PageSize });
            return response.Message;
        }
    }
}