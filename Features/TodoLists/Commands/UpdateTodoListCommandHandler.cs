using CQRSWithMediatRSampleDemo.Contexts;
using CQRSWithMediatRSampleDemo.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Commands;

public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommandRequest, bool>
{
    private readonly ITodoDbContext _context;
    public UpdateTodoListCommandHandler(ITodoDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTodoListCommandRequest request, CancellationToken cancellationToken)
    {
        TodoList todoList = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

        if(todoList == null)
            return false;

        if (!string.IsNullOrEmpty(request.Title))
            todoList.Title = request.Title;
        if (!string.IsNullOrEmpty(request.Content))
            todoList.Content = request.Content;
        if (request.StartDateTimeOffset.HasValue)
            todoList.StartDateTimeOffset = request.StartDateTimeOffset.Value;
        if (request.EndDateTimeOffset.HasValue)
            todoList.EndDateTimeOffset = request.EndDateTimeOffset.Value;
        if ((int)request.Status > 0)
        {
            todoList.Status = request.Status;
        }

        _context.TodoLists.Update(todoList); //?
        // _context.Todos.Attach(todo);
        // _context.Entry(todo).State = EntityState.Modified;
        var result = await _context.SaveChangeAsync();
        
        return result > 0 ? true : false;
    }
}
