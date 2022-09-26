using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Queries;

public class GetTodoListByIdQueryRequest : IRequest<GetTodoListByIdQueryResponse> 
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}
