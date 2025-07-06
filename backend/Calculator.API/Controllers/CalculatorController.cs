using Calculator.API.Models;
using Calculator.Domain.UseCases.CalculateSum;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{
    [HttpPost("sum")]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Sum([FromBody] CalculateSum request, [FromServices] ICalculateSumUseCase useCase, CancellationToken cancellationToken)
    {
        var query = new CalculateSumQuery(request.A, request.B);
        var sum = await  useCase.Execute(query, cancellationToken);
        return Ok(sum);
    }
}
