using CulinaryRecipes.Api.Models;
using CulinaryRecipes.Aplication.Queries;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryRecipes.Api.Controllers
{
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

        [HttpGet]
        public async Task<IEnumerable<RecipeModel>> Get(QueryModel query)
        {
            var client = _mediator.CreateRequestClient<IGetRecipeQuery>();
            Response<IEnumerable<RecipeModel>> response = await client.GetResponse<IEnumerable<RecipeModel>>(new { Query = query.Query, Page = query.Page, PageSize = query.PageSize });
            return response.Message;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(RecipeModel recipe)
        {
            await _mediator.Send(new { Recipe = recipe });
            return Ok();
        }
        [Route("/search")]
        public async Task<IActionResult> Find(string query, int page = 1, int pageSize = 5)
        {
            //    var response = await _elasticClient.SearchAsync<Product>
            //(
            //        s => s.Query(q => q.QueryString(d => d.Query(query)))
            //            .From((page - 1) * pageSize)
            //            .Size(pageSize));

            //    if (!response.IsValid)
            //    {
            //        // We could handle errors here by checking response.OriginalException 
            //        //or response.ServerError properties
            //        _logger.LogError("Failed to search documents");
            //        return View("Results", new Product[] { });
            //    }

            //    if (page > 1)
            //    {
            //        ViewData["prev"] = GetSearchUrl(query, page - 1, pageSize);
            //    }

            //    if (response.IsValid && response.Total > page * pageSize)
            //    {
            //        ViewData["next"] = GetSearchUrl(query, page + 1, pageSize);
            //    }

            //    return View("Results", response.Documents);
        }

        public async Task DeleteAsync(RecipeModel recipe)
        {
            await _mediator.Send(new { Recipe = recipe });
        }
    }
}