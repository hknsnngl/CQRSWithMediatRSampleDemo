using CQRSWithMediatRSampleDemo.Contexts;
using CQRSWithMediatRSampleDemo.Entities;
using CQRSWithMediatRSampleDemo.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Queries;
public class GetTodoListByIdQueryHandler : IRequestHandler<GetTodoListByIdQueryRequest, GetTodoListByIdQueryResponse>
{
     private readonly ITodoDbContext _context;

    public GetTodoListByIdQueryHandler(ITodoDbContext context)
    {
        _context = context;
    }

    public async Task<GetTodoListByIdQueryResponse> Handle(GetTodoListByIdQueryRequest request, CancellationToken cancellationToken)
    {
        TodoList todoList = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);
        if (todoList == null )
           return new GetTodoListByIdQueryResponse();

        GetTodoListByIdQueryResponse response = new GetTodoListByIdQueryResponse {
            Id = todoList.Id,
            Title = todoList.Title,
            Content = todoList.Content,
            Status = todoList.Status.GetDescription(),
            StartDateTimeStr = todoList.StartDateTimeOffset.ToLocalTime().ToString("g"),
            EndDateTimeStr =  todoList.EndDateTimeOffset.ToLocalTime().ToString("g")
        };

        return response;
    }
}
