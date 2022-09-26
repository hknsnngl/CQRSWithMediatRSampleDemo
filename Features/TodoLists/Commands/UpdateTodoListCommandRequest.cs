using CQRSWithMediatRSampleDemo.Models.Enums;
using MediatR;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Commands;

public class UpdateTodoListCommandRequest : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public TodoStatus Status { get; set; }
    public DateTimeOffset? StartDateTimeOffset { get; set; }
    public DateTimeOffset? EndDateTimeOffset { get; set; }
    public bool IsDeleted { get; set; }
}