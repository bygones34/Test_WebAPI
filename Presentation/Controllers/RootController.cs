﻿using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api")]
    [ApiExplorerSettings(GroupName = "v1")]

    public class RootController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public RootController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        [HttpGet(Name = "GetRootAsync")]
        public async Task<IActionResult> GetRootAsync([FromHeader(Name = "Accept")]string mediaType)
        {
            if (mediaType.Contains("application/vnd.btkakademi.apiroot"))
            {
                var list = new List<Link>()
                {
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRootAsync), new{}),
                        Rel = "_self",
                        Method = "GET"
                    },
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(BooksController.GetAllBooksAsync), new{}),
                        Rel = "books",
                        Method = "GET"
                    },
                    new Link()
                    {
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(BooksController.CreateOneBookAsync), new{}),
                        Rel = "books",
                        Method = "POST"
                    }
                };

                return Ok(list);
            }
            return NoContent(); // 204
        }
    }
}
