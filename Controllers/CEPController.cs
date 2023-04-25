using Microsoft.AspNetCore.Mvc;
using NUnit.Core.Concrats.Services;

namespace Nunit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CEPController : ControllerBase
    {
        private readonly IHttpClientViaCEPService _httpClientViaCEPService;
        public CEPController(IHttpClientViaCEPService httpClientViaCEPService)
        {
            _httpClientViaCEPService = httpClientViaCEPService;
        }
        [HttpGet(Name = "GetCep")]
        public async Task<IActionResult> Get(string cep)
        {
            var result = await _httpClientViaCEPService.GetAsync(cep);

            if(result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
