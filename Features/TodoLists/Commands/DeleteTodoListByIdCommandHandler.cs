using CQRSWithMediatRSampleDemo.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Commands;

public class DeleteTodoListByIdCommandHandler : IRequestHandler<DeleteTodoListByIdCommandRequest, bool>
{
    private readonly ITodoDbContext _context;
    public DeleteTodoListByIdCommandHandler(ITodoDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTodoListByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var todoList = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (todoList == null) 
            return false; //default

        _context.TodoLists.Remove(todoList);
        var result = await _context.SaveChangeAsync();

        return result > 0 ? true : false;
    }
}