using Calculator.API.Models;
using Calculator.Domain.UseCases.CalculateDivide;
using Calculator.Domain.UseCases.CalculateExpression;
using Calculator.Domain.UseCases.CalculateMultiply;
using Calculator.Domain.UseCases.CalculatePow;
using Calculator.Domain.UseCases.CalculateSqrt;
using Calculator.Domain.UseCases.CalculateSubtract;
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
    public async Task<IActionResult> Sum([FromBody] CalculateSum request, [FromServices] ICalculateSumUseCase useCase,
        CancellationToken cancellationToken)
    {
        var query = new CalculateSumQuery(request.A, request.B);
        var sum = await useCase.Execute(query, cancellationToken);
        return Ok(sum);
    }

    [HttpPost("subtract")]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Subtract([FromBody] CalculateSubtract request,
        [FromServices] ICalculateSubtractUseCase useCase, CancellationToken cancellationToken)
    {
        var query = new CalculateSubtractQuery(request.A, request.B);
        var subtract = await useCase.Execute(query, cancellationToken);
        return Ok(subtract);
    }

    [HttpPost("multiply")]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Multiply([FromBody] CalculateMultiply request,
        [FromServices] ICalculateMultiplyUseCase useCase, CancellationToken cancellationToken)
    {
        var query = new CalculateMultiplyQuery(request.A, request.B);
        var multiply = await useCase.Execute(query, cancellationToken);
        return Ok(multiply);
    }

    [HttpPost("divide")]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Divide([FromBody] CalculateDivide request,
        [FromServices] ICalculateDivideUseCase useCase, CancellationToken cancellationToken)
    {
        var query = new CalculateDivideQuery(request.A, request.B);
        var divide = await useCase.Execute(query, cancellationToken);
        return Ok(divide);
    }

    [HttpPost("pow")]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Pow([FromBody] CalculatePow request, [FromServices] ICalculatePowUseCase useCase,
        CancellationToken cancellationToken)
    {
        var query = new CalculatePowQuery(request.A, request.B);
        var pow = await useCase.Execute(query, cancellationToken);
        return Ok(pow);
    }

    [HttpPost("sqrt")]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Sqrt([FromBody] CalculateSqrt request,
        [FromServices] ICalculateSqrtUseCase useCase, CancellationToken cancellationToken)
    {
        var query = new CalculateSqrtQuery(request.A, request.B);
        var sqrt = await useCase.Execute(query, cancellationToken);
        return Ok(sqrt);
    }

    [HttpPost("expression")]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Expression([FromBody] CalculateExpression request,
        [FromServices] ICalculateExpressionUseCase useCase, CancellationToken cancellationToken)
    {
        var query = new CalculateExpressionQuery(request.Expression);
        var result = await useCase.Execute(query, cancellationToken);
        return Ok(result);
    }
}
