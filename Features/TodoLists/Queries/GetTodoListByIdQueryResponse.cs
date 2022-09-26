namespace CQRSWithMediatRSampleDemo.Features.TodoLists.Queries;

public class GetTodoListByIdQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public  string Status { get; set; }
    public string StartDateTimeStr { get; set; }
    public string EndDateTimeStr { get; set; }
}
