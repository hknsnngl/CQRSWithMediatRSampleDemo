using MediatR;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Commands;

public class DeleteTodoListByIdCommandRequest : IRequest<bool>
{
    public Guid Id { get; set; }
}