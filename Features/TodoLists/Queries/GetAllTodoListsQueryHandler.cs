using CQRSWithMediatRSampleDemo.Contexts;
using CQRSWithMediatRSampleDemo.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Queries;

public class GetAllTodoListQueryHandler : IRequestHandler<GetAllTodoListsQueryRequest, List<GetAllTodoListsQueryResponse>>
{
    private readonly ITodoDbContext _context;

    public GetAllTodoListQueryHandler(ITodoDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllTodoListsQueryResponse>> Handle(GetAllTodoListsQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _context.TodoLists.AsQueryable().Where(x => !x.IsDeleted);

        if (!string.IsNullOrEmpty(request.Title))
            query = query.Where(x => x.Title.Contains(request.Title));

        if (!string.IsNullOrEmpty(request.Content))
            query = query.Where(x => x.Content.Contains(request.Content));

        if ((int)request.Status > 0)
            query = query.Where(x => x.Status == request.Status);

        if (request.StartDateTime.HasValue)
        {
            var requestStartDateTimeOffsetnew = new DateTimeOffset(request.StartDateTime.Value,
                                                                   TimeZoneInfo.Local.GetUtcOffset(request.StartDateTime.Value));
            query = query.Where(x => x.StartDateTimeOffset >= requestStartDateTimeOffsetnew);
        }

        if (request.EndDateTime.HasValue)
        {
            var requestEndDateTimeOffsetnew = new DateTimeOffset(request.EndDateTime.Value,
                                                                   TimeZoneInfo.Local.GetUtcOffset(request.EndDateTime.Value));
            query = query.Where(x => x.EndDateTimeOffset <= requestEndDateTimeOffsetnew);
        }

        var todoLists = await query.OrderByDescending(x => x.StartDateTimeOffset)
            .Select(t => new GetAllTodoListsQueryResponse
            {
                Id = t.Id,
                Title = t.Title,
                Content = t.Content,
                Status = t.Status.GetDescription(),
                StartDateTimeStr = t.StartDateTimeOffset.ToLocalTime().ToString("g"),
                EndDateTimeStr =  t.EndDateTimeOffset.ToLocalTime().ToString("g")
            }).ToListAsync();

        return todoLists;
    }
}
