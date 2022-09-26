using CQRSWithMediatRSampleDemo.Contexts;
using CQRSWithMediatRSampleDemo.Entities;
using MediatR;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Commands;

public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommandRequest, bool>
{
    private readonly ITodoDbContext _context;
    public CreateTodoListCommandHandler(ITodoDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(CreateTodoListCommandRequest request, CancellationToken cancellationToken)
    {
        TodoList todoList = new TodoList
        {
            Title = request.Title,
            Content = request.Content,
            StartDateTimeOffset = request.StartDateTimeOffset,
            EndDateTimeOffset = request.EndDateTimeOffset,
            IsDeleted = false,
            Status = 0
        };

        await _context.TodoLists.AddAsync(todoList);
        var result = await _context.SaveChangeAsync();

        return result > 0 ? true : false;
    }
}
