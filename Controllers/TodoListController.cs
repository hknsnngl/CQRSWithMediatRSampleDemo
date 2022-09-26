using CQRSWithMediatRSampleDemo.Features.TodoLists.Commands;
using CQRSWithMediatRSampleDemo.Features.TodoLists.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatRSampleDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoListController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTodoListsQueryRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await _mediator.Send(new GetTodoListByIdQueryRequest { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoListCommandRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTodoListCommandRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }
        return Ok(await _mediator.Send(request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        return Ok(await _mediator.Send(new DeleteTodoListByIdCommandRequest { Id = id }));
    }
}
