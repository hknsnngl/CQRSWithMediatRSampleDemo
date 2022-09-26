using MediatR;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Commands;

public class CreateTodoListCommandRequest : IRequest<bool>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTimeOffset StartDateTimeOffset { get; set; }
    public DateTimeOffset EndDateTimeOffset { get; set; }
}