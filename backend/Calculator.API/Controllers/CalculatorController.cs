using Calculator.API.Models;
using Calculator.Domain.UseCases.CalculateSum;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{
    [HttpPost("sum")]
    public IActionResult Sum([FromBody] CalculateSum request, [FromServices] ICalculateSumUseCase useCase)
    {
        var query = new CalculateSumQuery(request.A, request.B);
        var sum =  useCase.Execute(query);
        return Ok(sum);
    }
}
