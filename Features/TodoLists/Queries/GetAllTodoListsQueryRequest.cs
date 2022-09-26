using CQRSWithMediatRSampleDemo.Models.Enums;
using MediatR;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Queries;

public class GetAllTodoListsQueryRequest : IRequest<List<GetAllTodoListsQueryResponse>>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public  TodoStatus Status { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime{ get; set; }
}
